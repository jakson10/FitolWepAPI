using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class FoodMap : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("FT_Food");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.CaloriValue).IsRequired();
            builder.Property(x => x.CarbohydrateValue).IsRequired();
            builder.Property(x => x.ProteinValue).IsRequired();
            builder.Property(x => x.OilValue).IsRequired();
            builder.Property(x => x.FiberValue).IsRequired();

            builder.HasMany(x => x.MealsIncluded).WithOne(x => x.Food).HasForeignKey(x => x.FKFoodId);

        }
    }
}
