using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for adding entities.
/// </summary>
/// <typeparam name="TDTO">The type of DTO (Data Transfer Object).</typeparam>
public interface IAddService<TDTO>
{
    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="dto">The DTO (Data Transfer Object) representing the entity to be added.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the final result.</returns>
    public Task<Final> AddAsync(TDTO dto);
}
