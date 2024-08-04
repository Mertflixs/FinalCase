using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Data.Context;
using Ppr_Data.Domain;
using Ppr_Data.GenericRepository;

namespace Ppr_Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ParaDbContext dbContext;
    public IGenericRepository<Account> AccountRepository { get; }

    public UnitOfWork(ParaDbContext dbContext)
    {
        this.dbContext = dbContext;

        AccountRepository = new GenericRepository<Account>(this.dbContext);
    }

    public void Dispose() { }

    public async Task Complete()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task CompleteWithTransaction()
    {
        using (var dbTransaction = await dbContext.Database.BeginTransactionAsync())
        {
            try
            {
                await dbContext.SaveChangesAsync();
                await dbTransaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await dbTransaction.RollbackAsync();
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}