using QuickKit.Shared.Entities;

namespace QuickKit.Shared.Services.Contracts;

public interface IGetAllService<TEntity>
    where TEntity : IEntity
{
    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of entities.</returns>
    public Task<IEnumerable<TEntity>> GetAllAsync();
}
