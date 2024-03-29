using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

public interface IAddRepository<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    Task<int> AddAsync(TEntity entity);
}
