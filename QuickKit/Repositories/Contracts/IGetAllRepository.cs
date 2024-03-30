using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

/// <summary>
/// Represents a repository that provides the ability to retrieve all entities asynchronously.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IGetAllRepository<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of entities.</returns>
    Task<IEnumerable<TEntity>> GetAllAsync();
}
