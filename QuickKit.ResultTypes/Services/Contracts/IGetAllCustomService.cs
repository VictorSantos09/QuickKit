namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for retrieving all instances of a custom type.
/// </summary>
/// <typeparam name="TType">The type of the instances to retrieve.</typeparam>
public interface IGetAllCustomService<TType>
{
    /// <summary>
    /// Retrieves all instances of the specified type asynchronously.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the collection of instances.</returns>
    Task<IFinal<IEnumerable<TType>>> GetAllAsync(CancellationToken cancellationToken);
}