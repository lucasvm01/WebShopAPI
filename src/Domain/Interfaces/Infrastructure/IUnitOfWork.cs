namespace WebShopAPI.Domain.Interfaces.Infrastructure;

public interface IUnitOfWork : IDisposable
{
    IBaseRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

    Task<int> CommitAsync();
}