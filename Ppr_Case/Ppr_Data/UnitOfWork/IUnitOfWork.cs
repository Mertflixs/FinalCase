using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ppr_Data.Domain;
using Ppr_Data.GenericRepository;

namespace Ppr_Data.UnitOfWork;

public interface IUnitOfWork {
    Task Complete();
    Task CompleteWithTransaction();
    IGenericRepository<Account> AccountRepository { get; }
    IGenericRepository<Category> CategoryRepository { get; } 
}