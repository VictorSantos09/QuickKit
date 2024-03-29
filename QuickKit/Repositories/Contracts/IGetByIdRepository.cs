using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

public interface IGetByIdRepository<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Retrieves an entity by its primary key asynchronously.
    /// </summary>
    /// <param name="id">The primary key of the entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity, or null if not found.</returns>
    Task<TEntity?> GetByIdAsync(TKey id);
}