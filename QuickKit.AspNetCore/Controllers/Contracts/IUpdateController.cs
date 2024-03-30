using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for updating entities in a controller.
/// </summary>
/// <typeparam name="TEntity">The type of entity to update.</typeparam>
public interface IUpdateController<TEntity> where TEntity : IEntity
{
    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> UpdateAsync(TEntity entity);
}
