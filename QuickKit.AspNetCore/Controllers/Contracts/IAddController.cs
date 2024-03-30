using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for adding entities.
/// </summary>
/// <typeparam name="TEntity">The type of entity.</typeparam>
public interface IAddController<TEntity> where TEntity : IEntity
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> AddAsync(TEntity entity);
}