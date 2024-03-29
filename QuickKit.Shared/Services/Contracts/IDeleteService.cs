using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Services.Contracts;

public interface IDeleteService<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Deletes an entity by its primary key asynchronously.
    /// </summary>
    /// <param name="id">The primary key of the entity to delete.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public Task DeleteAsync(TKey id);
}