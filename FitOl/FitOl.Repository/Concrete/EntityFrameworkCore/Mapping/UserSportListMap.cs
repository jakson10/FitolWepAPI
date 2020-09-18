using FitOl.Domain.Entities.MMRelation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class UserSportListsMap : IEntityTypeConfiguration<UserSportLists>
    {
        public void Configure(EntityTypeBuilder<UserSportLists> builder)
        {
            builder.ToTable("FT_UserSportLists");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new { x.FKUserId, x.FKSportListId }).IsUnique();
        }
    }
}
