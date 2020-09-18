using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class ThatDayMap : IEntityTypeConfiguration<ThatDay>
    {
        public void Configure(EntityTypeBuilder<ThatDay> builder)
        {
            builder.ToTable("FT_ThatDay");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.EnumMealType).IsRequired();

            builder.HasMany(x => x.NutrientsInMeals).WithOne(x => x.ThatDay).HasForeignKey(x => x.FKThatDayId);

        }
    }
}
