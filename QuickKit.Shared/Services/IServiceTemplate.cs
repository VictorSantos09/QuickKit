namespace QuickKit.Shared.Services;
public interface IServiceTemplate<TEntity, TKey>
{
    public Task<IEnumerable<TEntity>> GetAllAsync();
    public Task<TEntity> GetByIdAsync(TKey id);
    public Task AddAsync(TEntity entity);
    public Task UpdateAsync(TEntity entity);
    public Task DeleteAsync(TKey id);
}
