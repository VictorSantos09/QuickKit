using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for updating entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IUpdateService<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Updates the specified entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A task representing the asynchronous update operation.</returns>
    public Task<Final> UpdateAsync(TEntity entity);
}
