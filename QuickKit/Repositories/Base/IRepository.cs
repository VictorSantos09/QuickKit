using Dapper;
using QuickKit.Entities;

namespace QuickKit.Repositories.Base;

public interface IRepository {}

public interface IRepository<TEntity, TKey> : IRepository where TEntity : class, IEntityBase where TKey : struct
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(TKey id);
    Task<TEntity> GetByIdThrowAsync(TKey id, string notFoundExceptionMessage);
    Task<int> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TKey id);
}