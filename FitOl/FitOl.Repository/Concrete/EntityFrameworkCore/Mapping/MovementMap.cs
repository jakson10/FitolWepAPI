using FitOl.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class MovementMap : IEntityTypeConfiguration<Movement>
    {
        public void Configure(EntityTypeBuilder<Movement> builder)
        {
            builder.ToTable("FT_Movement");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MovementName).IsRequired();
            builder.Property(x => x.MovementDescription).IsRequired();
            builder.Property(x => x.EnumMovementType).IsRequired();


            builder.HasMany(x => x.AreaMovements).WithOne(x => x.Movement).HasForeignKey(x => x.FKMovementId);
        }
    }
}
