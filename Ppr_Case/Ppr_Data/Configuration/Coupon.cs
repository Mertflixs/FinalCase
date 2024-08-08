using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ppr_Data.Domain;

namespace Ppr_Data.Configuration;

public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(128);

        builder.Property(x => x.CouponId).IsRequired(true);
        builder.Property(x => x.CouponName).IsRequired(true).HasMaxLength(128);
        builder.Property(x => x.CouponAmount).IsRequired(true);
        builder.Property(x => x.CouponCode).IsRequired(true);
    }
}