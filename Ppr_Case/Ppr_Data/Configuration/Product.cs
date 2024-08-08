using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ppr_Data.Domain;

namespace Ppr_Data.Configuration;


public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(128);

        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.ProductName).IsRequired().HasMaxLength(255);
        builder.Property(x => x.ProductDescription).HasMaxLength(1000);
        builder.Property(x => x.IsActive).IsRequired();
        builder.Property(x => x.ProductFeatures).HasMaxLength(1000);
        builder.Property(x => x.RewardPercentage).IsRequired().HasPrecision(5, 2);
        builder.Property(x => x.MaxRewardAmount).IsRequired().HasPrecision(18, 2);
        builder.Property(x => x.CategoryId).IsRequired();
    }
}