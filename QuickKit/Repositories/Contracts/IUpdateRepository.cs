using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

/// <summary>
/// Represents a repository for updating entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IUpdateRepository<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    Task<int> UpdateAsync(TEntity entity);
}
