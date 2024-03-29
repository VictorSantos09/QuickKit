using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

public interface IControllerGetAll<TEntity> where TEntity : IEntity
{

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<ActionResult<IEnumerable<TEntity>>> GetAllAsync();
}

