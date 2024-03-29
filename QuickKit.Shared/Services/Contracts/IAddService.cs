using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Services.Contracts;

public interface IAddService<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task AddAsync(TEntity entity);
}
