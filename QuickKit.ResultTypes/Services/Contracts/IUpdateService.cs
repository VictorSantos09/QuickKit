namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for updating entities of type <typeparamref name="TDTO"/>.
/// </summary>
/// <typeparam name="TDTO">The type of the DTO (Data Transfer Object) used for updating.</typeparam>
public interface IUpdateService<TDTO>
{
    /// <summary>
    /// Updates an entity asynchronously using the provided DTO.
    /// </summary>
    /// <param name="dto">The DTO containing the updated data.</param>
    /// <returns>A task representing the asynchronous operation. The task result represents the final result of the update operation.</returns>
    public Task<IFinal> UpdateAsync(TDTO dto, CancellationToken cancellationToken);
}
