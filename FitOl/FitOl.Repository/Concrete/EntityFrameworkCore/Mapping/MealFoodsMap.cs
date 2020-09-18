using FitOl.Domain.Entities.MMRelation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class MealFoodsMap : IEntityTypeConfiguration<MealFoods>
    {
        public void Configure(EntityTypeBuilder<MealFoods> builder)
        {
            builder.ToTable("FT_MealFoods");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new { x.FKFoodId, x.FKThatDayId }).IsUnique();
        }
    }
}
