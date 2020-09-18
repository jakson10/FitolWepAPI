using FitOl.Repository.Abstract;
using FitOl.Repository.Concrete.EntityFrameworkCore.Repositories;
using FitOl.Service.Abstract;
using FitOl.Service.Concrete.EntityFrameworkCore;
using FitOl.Service.Tool.JWTTool;
using Microsoft.Extensions.DependencyInjection;

namespace FitOl.Service.DiContainer
{
    public static class CustomExtensions
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {

            services.AddTransient(typeof(IGenericRepository<>), typeof(EfGenericRepository<>));

            services.AddTransient<IFoodRepository, EfFoodRepository>();
            services.AddTransient<IFoodService, EfFoodService>();
            services.AddTransient<INutritionListRepository, EfNutritionListRepository>();
            services.AddTransient<INutritionListService, EfNutritionListService>();
            services.AddTransient<IAreaRepository, EfAreaRepository>();
            services.AddTransient<IAreaService, EfAreaService>();
            services.AddTransient<IMovementRepository, EfMovementRepository>();
            services.AddTransient<IMovementService, EfMovementService>();
            services.AddTransient<INutritionDayRepository, EfNutritionDayRepository>();
            services.AddTransient<INutritionDayService, EfNutritionDayService>();
            services.AddTransient<ISportDayRepository, EfSportDayRepository>();
            services.AddTransient<ISportDayService, EfSportDayService>();
            services.AddTransient<ISportListRepository, EfSportListRepository>();
            services.AddTransient<ISportListService, EfSportListService>();
            services.AddTransient<IThatDayRepository, EfThatDayRepository>();
            services.AddTransient<IThatDayService, EfThatDayService>();
            services.AddTransient<IUserRepository, EfUserRepository>();
            services.AddTransient<IUserService, EfUserService>();

            services.AddTransient<IJwtService, JwtManager>();
     
        }
    }
}
