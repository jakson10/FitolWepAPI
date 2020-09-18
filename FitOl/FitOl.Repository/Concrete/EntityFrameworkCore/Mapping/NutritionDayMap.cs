using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class NutritionDayMap : IEntityTypeConfiguration<NutritionDay>
    {
        public void Configure(EntityTypeBuilder<NutritionDay> builder)
        {
            builder.ToTable("FT_NutritionDay");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.NutritionList).WithMany(x => x.NutritionDays).HasForeignKey(x => x.FKNutritionListId);

            builder.HasMany(x => x.ThatDays).WithOne(x => x.NutritionDays).HasForeignKey(x => x.FKNutritionDayId);

        }
    }
}
