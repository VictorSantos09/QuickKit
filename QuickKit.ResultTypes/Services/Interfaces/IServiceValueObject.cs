using QuickKit.ResultTypes.ValueObjects;

namespace QuickKit.ResultTypes.Services.Interfaces;

public interface IServiceValueObject<TEntity, TKey>
{
    public Task<Result<IEnumerable<TEntity>>> GetAllAsync();
    public Task<Result<TEntity>> GetByIdAsync(TKey id);
    public Task<Result> AddAsync(TEntity entity);
    public Task<Result> UpdateAsync(TEntity entity);
    public Task<Result> DeleteAsync(TKey id);
}
