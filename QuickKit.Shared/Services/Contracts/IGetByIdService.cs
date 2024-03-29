using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Services.Contracts;

public interface IGetByIdService<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Retrieves an entity by its primary key asynchronously.
    /// </summary>
    /// <param name="id">The primary key of the entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    public Task<TEntity> GetByIdAsync(TKey id);
}
