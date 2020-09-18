using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class SportListMap : IEntityTypeConfiguration<SportList>
    {
        public void Configure(EntityTypeBuilder<SportList> builder)
        {
            builder.ToTable("FT_SportList");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.EnumSportType).IsRequired();

            builder.HasMany(x => x.UserSportLists).WithOne(x => x.SportList).HasForeignKey(x => x.FKSportListId);
        }
    }
}
