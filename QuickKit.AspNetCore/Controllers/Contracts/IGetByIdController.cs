using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for retrieving an entity by its ID.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TKey">The type of the ID.</typeparam>
public interface IGetByIdController<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<ActionResult<TEntity?>> GetByIdAsync(TKey id);
}
