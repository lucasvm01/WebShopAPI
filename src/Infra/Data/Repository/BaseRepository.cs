using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Infra.Data.Context;

namespace WebShopAPI.Infra.Data.Repository;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _dbContext;

    private readonly DbSet<T> _dbSet;

    public BaseRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public void Add<TEntity>(TEntity entity) where TEntity : T
    {
        _dbSet.Add(entity);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : T
    {
        _dbSet.Update(entity);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : T
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<T> GetAll()
    {
        return _dbSet;
    }

    public async Task<T> GetByIdAsync(long id)
    {
        return await _dbSet.FindAsync(id).ConfigureAwait(false);
    }

    public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken)
    {
        return _dbSet.AnyAsync(predicate, cancellationToken);
    }
}
