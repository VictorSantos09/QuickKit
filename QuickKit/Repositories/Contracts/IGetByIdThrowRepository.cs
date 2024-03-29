using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

public interface IGetByIdThrowRepository<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Retrieves an entity by its primary key asynchronously, throwing an exception if not found.
    /// </summary>
    /// <param name="id">The primary key of the entity.</param>
    /// <param name="notFoundExceptionMessage">The exception message to throw if the entity is not found.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the entity.</returns>
    Task<TEntity> GetByIdThrowAsync(TKey id, string notFoundExceptionMessage);
}