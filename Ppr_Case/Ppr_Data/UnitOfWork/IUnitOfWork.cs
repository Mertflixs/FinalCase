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
    IGenericRepository<Product> ProductRepository { get; }
    IGenericRepository<Order> OrderRepository { get; }
    IGenericRepository<OrderDetail> OrderDetailRepository { get; }
    IGenericRepository<Coupon> CouponRepository { get; }
    IGenericRepository<Point> PointRepository { get; }
}