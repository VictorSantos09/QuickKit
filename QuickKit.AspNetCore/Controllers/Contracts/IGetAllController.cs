using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for retrieving all entities asynchronously.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public interface IGetAllController<TEntity> where TEntity : IEntity
{
    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync(CancellationToken cancellationToken = default);
}

