using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Infra.Data.Context;

namespace WebShopAPI.Infra.Data.Repository;

public class UnitOfWork(AppDbContext dbContext) : IUnitOfWork
{
    private Dictionary<Type, object> _repositories;

    public async Task<int> CommitAsync()
    {
        var result = await dbContext.SaveChangesAsync();

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

        _repositories[type] = new BaseRepository<TEntity>(dbContext);

        return (IBaseRepository<TEntity>)_repositories[type];
    }
}