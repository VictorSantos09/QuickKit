using QuickKit.Shared.Entities;

namespace QuickKit.Repositories.Contracts;

public interface IDeleteRepository<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Deletes an entity by its primary key asynchronously.
    /// </summary>
    /// <param name="id">The primary key of the entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected rows.</returns>
    Task<int> DeleteAsync(TKey id);
}
