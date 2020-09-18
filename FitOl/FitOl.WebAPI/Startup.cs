using AutoMapper;
using FitOl.Domain.AutoMapper;
using FitOl.Domain.Entities;
using FitOl.Repository.Concrete.EntityFrameworkCore.Context;
using FitOl.Service.DiContainer;
using FitOl.Service.StringInfos;
using FitOl.WebAPI.CustomCollectionExtensions;
using FitOl.WebAPI.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace FitOl.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private MapperConfiguration _mapperConfiguration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddMvc();

            services.AddDistributedMemoryCache();
            services.AddSession();

            ////AUTOMAPPER CONFIGURATION
            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MappingProfile());
            //    mc.AddProfile(new ProfileUI());
            //});
            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddTransient<IMapper>(mapper);
            //services.AddScoped((System.Type)mapper);

            ////AUTOMAPPER CONFIGURATION
            _mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
                cfg.AddProfile(new ProfileUI());
            });
            services.AddTransient<IMapper>(sp => _mapperConfiguration.CreateMapper());


            services.AddControllers();
            services.AddContainerWithDependencies();
            services.AddDbContext<SportDatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddCustomIdentity();


            //dosya olusturma ýslemý yaparken hata verýyordu bu ayarý yapman lazýmki hata almayasýn
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });


            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                    {
                        options.SaveToken = true;
                        options.RequireHttpsMetadata = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidateAudience = true,
                            ValidAudience = JwtInfo.Audience,
                            ValidIssuer = JwtInfo.Issuer,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey))
                        };
                    })
              .AddCookie(opt =>
                {
                    //config.Cookie.Name = "login";
                    //config.LoginPath = "/Account/Login";
                    //config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                    opt.Cookie.Name = "FitOlCokkie";
                    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; //strict yaparsan baska sayfayla cookie paylasýlmaz
                    opt.Cookie.HttpOnly = true;  //cookie bilgisine ulasamaz document.write ile
                    opt.ExpireTimeSpan = TimeSpan.FromDays(20); //ne kadar süre ayakta kalýcak
                    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //istek neyse o sekýlde davran http yada https
                    opt.LoginPath = "/Security/Login";
                    opt.LogoutPath = "/Security/Logout";
                    opt.AccessDeniedPath = "/Security/AccessDenied";
                    opt.SlidingExpiration = true;
                });

           
        
            #region Authentication
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //})
            //    .AddJwtBearer(options =>
            //        {
            //            options.SaveToken = true;
            //            options.RequireHttpsMetadata = true;
            //            options.TokenValidationParameters = new TokenValidationParameters()
            //            {
            //                ValidateIssuer = true,
            //                ValidateAudience = true,
            //                ValidAudience = JwtInfo.Audience,
            //                ValidIssuer = JwtInfo.Issuer,
            //                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey))
            //            };
            //        })
            //  .AddCookie(opt =>
            //    {
            //        //config.Cookie.Name = "login";
            //        //config.LoginPath = "/Account/Login";
            //        //config.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            //        opt.Cookie.Name = "FitOlCokkie";
            //        opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; //strict yaparsan baska sayfayla cookie paylasýlmaz
            //        opt.Cookie.HttpOnly = true;  //cookie bilgisine ulasamaz document.write ile
            //        opt.ExpireTimeSpan = TimeSpan.FromDays(20); //ne kadar süre ayakta kalýcak
            //        opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //istek neyse o sekýlde davran http yada https
            //        opt.LoginPath = "/Security/Login";
            //        opt.LogoutPath = "/Security/Logout";
            //        opt.AccessDeniedPath = "/Security/AccessDenied";
            //        opt.SlidingExpiration = true;
            //    });

            //ayrý bir cookie
            //services.ConfigureApplicationCookie(opt =>
            //{
            //    opt.Cookie.Name = "FitOlCokkie";
            //    opt.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict; //strict yaparsan baska sayfayla cookie paylasýlmaz
            //    opt.Cookie.HttpOnly = true;  //cookie bilgisine ulasamaz document.write ile
            //    opt.ExpireTimeSpan = TimeSpan.FromDays(20); //ne kadar süre ayakta kalýcak
            //    opt.Cookie.SecurePolicy = Microsoft.AspNetCore.Http.CookieSecurePolicy.SameAsRequest; //istek neyse o sekýlde davran http yada https
            //    opt.LoginPath = "/Security/Login";
            //    opt.LogoutPath = "/Security/Logout";
            //    opt.AccessDeniedPath = "/Security/AccessDenied";
            //    opt.SlidingExpiration = true;
            //});

            //jwtbeaber
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            //{
            //    opt.RequireHttpsMetadata = false; //httpse kapatýyoruz
            //    opt.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidIssuer = JwtInfo.Issuer,
            //        ValidAudience = JwtInfo.Audience,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtInfo.SecurityKey)),
            //        ValidateLifetime = true, //token zamaný býtýnce gecersýz sayýlsýn
            //        ValidateAudience = true, //audience ýssuer ise beným belýrledýgým yerden gelmedýyse token gecersýz sayýlcak
            //        ValidateIssuer = true,
            //        ClockSkew = TimeSpan.Zero  //zaman farký koyma
            //    };
            //});
            #endregion

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseHttpsRedirection();
            app.UseSession();
            //app.UseMiddleware<ApiKeyMiddleware>();

            IdentityInitializer.SeedData(userManager, roleManager).Wait();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
