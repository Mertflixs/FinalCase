using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ppr_Data.Domain;

namespace Ppr_Data.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(128);

        builder.Property(x => x.CategoryId).IsRequired(true);

        builder.Property(x => x.CategoryName).IsRequired(true).HasMaxLength(50);

        builder.Property(x => x.CategoryUrl).IsRequired(true);

        builder.Property(x => x.CategoryTags).IsRequired(true);

        builder.HasMany(c => c.ProductCategory)
               .WithOne(pc => pc.Category)
               .HasForeignKey(pc => pc.CategoryId);
    }
}
