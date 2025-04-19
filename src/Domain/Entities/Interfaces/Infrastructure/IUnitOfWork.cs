namespace WebShopAPI.Domain.Entities.Interfaces.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    Task<int> CommitAsync();
}