using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

/// <summary>
/// Represents a repository contract for deleting entities by their primary key.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TKey">The type of the primary key.</typeparam>
public interface IDeleteRepository<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Deletes an entity by its primary key asynchronously.
    /// </summary>
    /// <param name="id">The primary key of the entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    Task<int> DeleteAsync(TKey id, CancellationToken cancellationToken);
}
