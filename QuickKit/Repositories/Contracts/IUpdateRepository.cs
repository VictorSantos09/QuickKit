using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

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
