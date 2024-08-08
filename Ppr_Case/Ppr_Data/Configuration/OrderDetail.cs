using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ppr_Data.Domain;

namespace Ppr_Data.Configuration;

public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
{
    public void Configure(EntityTypeBuilder<OrderDetail> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(128);

        builder.Property(x => x.OrderDetailId).IsRequired(true);
        builder.Property(x => x.OrderId).IsRequired(true);
        builder.Property(x => x.CustomerId).IsRequired(true);
        builder.Property(x => x.ProductId).IsRequired(true);
        builder.Property(x => x.Quantity).IsRequired(true);
    }
}