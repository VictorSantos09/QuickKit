using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for updating entities in a controller.
/// </summary>
/// <typeparam name="TDTO">The type of data object to update.</typeparam>
public interface IUpdateController<TDTO>
{
    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="dto">The data object to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> UpdateAsync(TDTO dto, CancellationToken cancellationToken = default);
}
