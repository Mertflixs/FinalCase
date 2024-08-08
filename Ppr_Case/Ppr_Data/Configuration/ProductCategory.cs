using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ppr_Data.Domain;

namespace Ppr_Data.Configuration;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
{
    public void Configure(EntityTypeBuilder<ProductCategory> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(128);
        
        builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

        builder.Property(x => x.AccountId).IsRequired(true);
        builder.HasIndex(x => x.AccountId);
    }
}