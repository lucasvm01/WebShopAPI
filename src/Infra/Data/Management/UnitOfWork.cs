using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Interfaces.Infrastructure;
using WebShopAPI.Infra.Data.Context;

namespace WebShopAPI.Infra.Data.Management;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private Dictionary<Type, object> _repositories;

    public UnitOfWork(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> CommitAsync()
    {
        var result = await _dbContext.SaveChangesAsync();

        return result;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class
    {
        _repositories ??= new Dictionary<Type, object>();

        var type = typeof(TEntity);

        if (_repositories.ContainsKey(type))
        {
            return (IBaseRepository<TEntity>)_repositories[type];
        }

        _repositories[type] = new BaseRepository<TEntity>(_dbContext);

        return (IBaseRepository<TEntity>)_repositories[type];
    }
}