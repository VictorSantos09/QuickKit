using Microsoft.AspNetCore.Mvc;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for deleting entities by their ID.
/// </summary>
/// <typeparam name="TKey">The type of the entity ID.</typeparam>
public interface IDeleteController<TKey> where TKey : IConvertible
{
    /// <summary>
    /// Deletes an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> DeleteAsync(TKey id, CancellationToken cancellationToken = default);
}