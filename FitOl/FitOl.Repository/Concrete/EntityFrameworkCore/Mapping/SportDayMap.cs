using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class SportDayMap : IEntityTypeConfiguration<SportDay>
    {
        public void Configure(EntityTypeBuilder<SportDay> builder)
        {
            builder.ToTable("FT_SportDay");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();

            builder.HasOne(x => x.SportList).WithMany(x => x.SportDays).HasForeignKey(x => x.FKSportListId);

            builder.HasMany(x => x.Areas).WithOne(x => x.SportDay).HasForeignKey(x => x.FKDayId);
        }
    }
}
