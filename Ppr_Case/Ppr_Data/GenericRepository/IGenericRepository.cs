using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Ppr_Data.GenericRepository;

public interface IGenericRepository<T> where T : class
{
    Task Save();
    Task<T?> GetById(long Id, params string[] includes);
    Task<T> Insert(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task Delete(long Id);
    Task<List<T>> GetAll(params string[] includes);
    Task<List<T>> Where(Expression<Func<T, bool>> expression, params string[] includes);
    Task<T> FirstOrDefault(Expression<Func<T, bool>> expression, params string[] includes);
}