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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AccountConfiguration());
    }
}