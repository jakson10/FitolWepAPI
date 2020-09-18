using FitOl.Domain.Entities;
using FitOl.Repository.Concrete.EntityFrameworkCore.Context;
using FitOl.Service.StringInfos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitOl.WebAPI.CustomCollectionExtensions
{
    public static class CollectionExtension
    {
        public static void AddCustomIdentity(this IServiceCollection services)
        {

            //.AddRoleManager<RoleManager<AppRole>>()
            //.AddEntityFrameworkStores<SportDatabaseContext>()
            //.AddDefaultUI()
            //.AddDefaultTokenProviders();

            //.AddEntityFrameworkStores<SportDatabaseContext>().AddDefaultTokenProviders();

            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.Password.RequireDigit = false; //sayı olsun mu
                opt.Password.RequireLowercase = false; //
                opt.Password.RequiredLength = 6; // minimum uzunluk 6 olsun mu
                opt.Password.RequireNonAlphanumeric = false; //alfa numarik karakter olsun mu
                opt.Password.RequireUppercase = false; // büyük harf olsun mu

                opt.Lockout.MaxFailedAccessAttempts = 5; // kullanıcı 5 kez şifreyi yanlış girdiğinde hata versin
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);// 5 kez yanlış girince 5 dk sonra tekrar girebilsin
                opt.Lockout.AllowedForNewUsers = true;

                //opt.User.RequireUniqueEmail = true;
                //opt.SignIn.RequireConfirmedEmail = true;
                //opt.SignIn.RequireConfirmedPhoneNumber = false;

            }).AddEntityFrameworkStores<SportDatabaseContext>().AddDefaultTokenProviders();



        }
    }
}
