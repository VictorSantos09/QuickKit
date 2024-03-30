namespace QuickKit.ResultTypes.Services.Contracts;

/// <summary>
/// Represents a service contract for deleting entities by their unique identifier.
/// </summary>
/// <typeparam name="TKey">The type of the unique identifier.</typeparam>
public interface IDeleteService<TKey>
    where TKey : IConvertible
{
    /// <summary>
    /// Deletes an entity by its unique identifier asynchronously.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task<Final> DeleteAsync(TKey id);
}