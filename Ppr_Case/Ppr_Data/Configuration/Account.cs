using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ppr_Data.Domain;

namespace Ppr_Data.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x => x.InsertDate).IsRequired(true);
        builder.Property(x => x.IsActive).IsRequired(true);
        builder.Property(x => x.InsertUser).IsRequired(true).HasMaxLength(128);

        //builder.Property(x => x.AccountId).IsRequired(true);
        //builder.HasIndex(x => x.AccountId).IsUnique(); // IsUnique yerine HasIndex ve IsUnique kullanımı

        builder.Property(x => x.AccountName).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.AccountSurname).IsRequired(true).HasMaxLength(50);
        builder.Property(x => x.AccountEmail).IsRequired(true);
        builder.HasIndex(x => x.AccountEmail).IsUnique(); // IsUnique yerine HasIndex ve IsUnique kullanımı

        builder.Property(x => x.AccountRole).IsRequired(true);
        builder.Property(x => x.AccountPassword).IsRequired(true);
        builder.Property(x => x.AccountStatus).IsRequired(true); //bu kalkabilir
        builder.Property(x => x.AccountPoint); // bunlar degisgenlik gosterebilir
        builder.Property(x => x.AccountWallet);

        builder.HasMany(x => x.Order)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(x => x.ProductCategory)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(x => x.Point)
            .WithOne(x => x.Account)
            .HasForeignKey(x => x.AccountId)
            .IsRequired(true)
            .OnDelete(DeleteBehavior.Cascade);

    }
}
