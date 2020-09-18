using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class NutritionListMap : IEntityTypeConfiguration<NutritionList>
    {
        public void Configure(EntityTypeBuilder<NutritionList> builder)
        {
            builder.ToTable("FT_NutritionList");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.TotalCaloriValue).IsRequired();
            builder.Property(x => x.EnumNutritionKind).IsRequired();
            builder.Property(x => x.EnumNutritionType).IsRequired();

            builder.HasMany(x => x.UserNutritionLists).WithOne(x => x.NutritionList).HasForeignKey(x => x.FKNutritionListId);
        }
    }
}
