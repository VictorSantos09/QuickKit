using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for retrieving all entities of a specific type.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IGetAllService<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of entities.</returns>
    Task<IFinal<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken);
}
