using FitOl.Domain.Entities.MMRelation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class AreaMovementsMap : IEntityTypeConfiguration<AreaMovements>
    {
        public void Configure(EntityTypeBuilder<AreaMovements> builder)
        {
            builder.ToTable("FT_AreaMovements");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new { x.FKAreaId, x.FKMovementId }).IsUnique();
        }
    }
}
