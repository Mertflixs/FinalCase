using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Ppr_Base.Entity;
using Ppr_Data.Context;

namespace Ppr_Data.GenericRepository;

internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ParaDbContext dbContext;

    public GenericRepository(ParaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task Save()
    {
        await dbContext.SaveChangesAsync();
    }

    public async Task<T?> GetById(long Id, params string[] includes)
    {
        var query = dbContext.Set<T>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(query, x => x.Id == Id);
    }

    public async Task<T> Insert(T entity)
    {
        entity.IsActive = true;
        entity.InsertDate = DateTime.UtcNow;
        entity.InsertUser = "System";
        await dbContext.Set<T>().AddAsync(entity);
        return entity;
    }

    public void Update(T entity)
    {
        dbContext.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        dbContext.Set<T>().Remove(entity);
    }

    public async Task Delete(long Id)
    {
        var entity = await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(dbContext.Set<T>(), x => x.Id == Id);
        if (entity is not null)
            dbContext.Set<T>().Remove(entity);
    }

    public async Task<List<T>> Where(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = dbContext.Set<T>().Where(expression).AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.ToListAsync(query);
    }

    public async Task<T> FirstOrDefault(Expression<Func<T, bool>> expression, params string[] includes)
    {
        var query = dbContext.Set<T>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return query.Where(expression).FirstOrDefault();
    }

    public async Task<List<T>> GetAll(params string[] includes)
    {
        var query = dbContext.Set<T>().AsQueryable();
        query = includes.Aggregate(query, (current, inc) => EntityFrameworkQueryableExtensions.Include(current, inc));
        return await EntityFrameworkQueryableExtensions.ToListAsync(query);
    }
}