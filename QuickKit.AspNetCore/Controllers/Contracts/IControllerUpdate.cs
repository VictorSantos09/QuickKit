using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

public interface IControllerUpdate<TEntity> where TEntity : IEntity
{
    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> UpdateAsync(TEntity entity);
}
