using FitOl.Domain.Entities;
using FitOl.Domain.Entities.MMRelation;
using FitOl.Repository.Concrete.EntityFrameworkCore.Mapping;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Context
{
    public class SportDatabaseContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public SportDatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AppUserMap());
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new AreaMovementsMap());
            modelBuilder.ApplyConfiguration(new FoodMap());
            modelBuilder.ApplyConfiguration(new MealFoodsMap());
            modelBuilder.ApplyConfiguration(new MovementMap());
            modelBuilder.ApplyConfiguration(new NutritionDayMap());
            modelBuilder.ApplyConfiguration(new NutritionListMap());
            modelBuilder.ApplyConfiguration(new SportDayMap());
            modelBuilder.ApplyConfiguration(new SportListMap());
            modelBuilder.ApplyConfiguration(new ThatDayMap());
            modelBuilder.ApplyConfiguration(new UserNutritionListsMap());
            modelBuilder.ApplyConfiguration(new UserSportListsMap());

            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<Movement> Movements { get; set; }
        public virtual DbSet<NutritionDay> NutritionDays { get; set; }
        public virtual DbSet<NutritionList> NutritionLists { get; set; }
        public virtual DbSet<SportDay> SportDays { get; set; }
        public virtual DbSet<SportList> SportLists { get; set; }
        public virtual DbSet<ThatDay> ThatDays { get; set; }
        public virtual DbSet<AreaMovements> AreaMovements { get; set; }
        public virtual DbSet<MealFoods> MealFoods { get; set; }
        public virtual DbSet<UserSportLists> UserSportLists { get; set; }
        public virtual DbSet<UserNutritionLists> UserNutritionLists { get; set; }


    }
}
