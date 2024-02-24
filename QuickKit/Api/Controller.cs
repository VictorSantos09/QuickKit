using Microsoft.AspNetCore.Mvc;
using QuickKit.Shared.Entities;

namespace QuickKit.Api;

public interface IController<TEntity, TKey> 
    where TKey : struct 
    where TEntity : IEntityBase
{
    IActionResult TestEndPoint();
    Task<IActionResult> GetAllAsync();
    Task<IActionResult> GetByIdAsync(TKey id);
    Task<IActionResult> AddAsync(TEntity entity);
    Task<IActionResult> UpdateAsync(TEntity entity);
    Task<IActionResult> DeleteAsync(TKey id);
}

public abstract class Controller<TEntity, TKey> : ControllerBase, IController<TEntity, TKey>
    where TEntity : IEntityBase
    where TKey : struct
{
    public abstract IActionResult TestEndPoint();
    public abstract Task<IActionResult> GetAllAsync();
    public abstract Task<IActionResult> GetByIdAsync(TKey id);
    public abstract Task<IActionResult> AddAsync(TEntity entity);
    public abstract Task<IActionResult> UpdateAsync(TEntity entity);
    public abstract Task<IActionResult> DeleteAsync(TKey id);
}
