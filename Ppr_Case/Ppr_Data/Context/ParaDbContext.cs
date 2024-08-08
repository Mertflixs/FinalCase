using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ppr_Data.Configuration;
using Ppr_Data.Domain;

namespace Ppr_Data.Context;

public class ParaDbContext : DbContext
{
    public ParaDbContext(DbContextOptions<ParaDbContext> options) : base(options)
    {

    }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set;}
    public DbSet<Order> Orders { get; set;}
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Coupon> Coupons { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
        modelBuilder.ApplyConfiguration(new CategoryConfiguration());
        modelBuilder.ApplyConfiguration(new ProductConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
        modelBuilder.ApplyConfiguration(new CouponConfiguration());
    }
}