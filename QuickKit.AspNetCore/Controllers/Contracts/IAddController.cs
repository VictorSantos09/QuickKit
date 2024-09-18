using Microsoft.AspNetCore.Mvc;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for adding entities.
/// </summary>
/// <typeparam name="TDTO">The type of DTO (Data Transfer Object) representing the entity.</typeparam>
public interface IAddController<TDTO>
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="dto">The DTO (Data Transfer Object) representing the entity to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> AddAsync(TDTO dto, CancellationToken cancellationToken = default);
}