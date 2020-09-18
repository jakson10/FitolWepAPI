using FitOl.Domain.Entities.MMRelation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FitOl.Repository.Concrete.EntityFrameworkCore.Mapping
{
    public class UserNutritionListsMap : IEntityTypeConfiguration<UserNutritionLists>
    {
        public void Configure(EntityTypeBuilder<UserNutritionLists> builder)
        {
            builder.ToTable("FT_UserNutritionLists");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.HasIndex(x => new { x.FKUserId, x.FKNutritionListId }).IsUnique();
        }
    }
}
