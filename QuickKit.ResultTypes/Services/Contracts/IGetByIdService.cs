using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for retrieving an entity by its ID.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TKey">The type of the ID.</typeparam>
public interface IGetByIdService<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    public Task<Final<TEntity?>> GetByIdAsync(TKey id);
}
