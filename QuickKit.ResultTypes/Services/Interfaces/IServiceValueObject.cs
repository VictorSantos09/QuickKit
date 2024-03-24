namespace QuickKit.ResultTypes.Services.Interfaces;

public interface IServiceValueObject<TEntity, TKey>
{
    public Task<Final<IEnumerable<TEntity>>> GetAllAsync();
    public Task<Final<TEntity>> GetByIdAsync(TKey id);
    public Task<Final> AddAsync(TEntity entity);
    public Task<Final> UpdateAsync(TEntity entity);
    public Task<Final> DeleteAsync(TKey id);
}
