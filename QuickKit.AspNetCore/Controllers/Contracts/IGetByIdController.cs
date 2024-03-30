using Microsoft.AspNetCore.Mvc;

namespace QuickKit.AspNetCore.Controllers.Contracts;

/// <summary>
/// Represents an interface for retrieving an entity by its ID.
/// </summary>
/// <typeparam name="TKey">The type of the ID.</typeparam>
public interface IGetByIdController<TKey> where TKey : IConvertible
{
    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> GetByIdAsync(TKey id);
}
