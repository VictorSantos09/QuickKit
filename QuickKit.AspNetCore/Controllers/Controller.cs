using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.AspNetCore.Controllers;

#region IController Interface
/// <summary>
/// Represents a generic controller interface for CRUD operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TKey">The type of the entity's primary key.</typeparam>
public interface IController<TEntity, TKey>
    where TKey : IConvertible
    where TEntity : IEntity
{
    /// <summary>
    /// Tests the endpoint of the controller.
    /// </summary>
    /// <returns>An <see cref="IActionResult"/> representing the result of the test.</returns>
    IActionResult TestEndPoint();

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> GetAllAsync();

    /// <summary>
    /// Retrieves an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> GetByIdAsync(TKey id);

    /// <summary>
    /// Adds a new entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> AddAsync(TEntity entity);

    /// <summary>
    /// Updates an existing entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> UpdateAsync(TEntity entity);

    /// <summary>
    /// Deletes an entity by its ID asynchronously.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing an <see cref="IActionResult"/>.</returns>
    Task<IActionResult> DeleteAsync(TKey id);
}

#endregion

#region Abstract Implementation
/// <summary>
/// Represents a base controller for CRUD operations on entities.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
/// <typeparam name="TKey">The type of the entity's key.</typeparam>
public abstract class Controller<TEntity, TKey> : ControllerBase, IController<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    /// <inheritdoc/>
    public abstract IActionResult TestEndPoint();

    /// <inheritdoc/>
    public abstract Task<IActionResult> GetAllAsync();

    /// <inheritdoc/>
    public abstract Task<IActionResult> GetByIdAsync(TKey id);

    /// <inheritdoc/>
    public abstract Task<IActionResult> AddAsync(TEntity entity);

    /// <inheritdoc/>
    public abstract Task<IActionResult> UpdateAsync(TEntity entity);

    /// <inheritdoc/>
    public abstract Task<IActionResult> DeleteAsync(TKey id);
}

#endregion