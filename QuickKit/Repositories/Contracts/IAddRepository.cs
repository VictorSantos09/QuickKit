using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

/// <summary>
/// Represents a repository contract for adding entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IAddRepository<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);
}
