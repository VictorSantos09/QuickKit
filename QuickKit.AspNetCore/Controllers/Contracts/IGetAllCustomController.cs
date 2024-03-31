using Microsoft.AspNetCore.Mvc;

namespace QuickKit.AspNetCore.Controllers.Contracts
{
    /// <summary>
    /// Represents a controller interface for retrieving all instances of a custom type.
    /// </summary>
    /// <typeparam name="TType">The type of the instances to retrieve.</typeparam>
    public interface IGetAllCustomController<TType>
    {
        /// <summary>
        /// Retrieves all instances of the specified type.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the action result with the collection of instances.</returns>
        Task<ActionResult<IEnumerable<TType>>> GetAllAsync(CancellationToken cancellationToken = default);
    }
}

