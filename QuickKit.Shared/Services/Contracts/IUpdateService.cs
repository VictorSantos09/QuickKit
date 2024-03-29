using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Services.Contracts;

public interface IUpdateService<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task UpdateAsync(TEntity entity);
}
