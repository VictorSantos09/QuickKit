using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for adding entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IAddService<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to be added.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the final result.</returns>
    public Task<Final> AddAsync(TEntity entity);
}
