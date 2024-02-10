using QuickKit.Entities;

namespace QuickKit.Repositories.Base;

public interface IRepository {}

public interface IRepository<TEntity> : IRepository where TEntity : class, IEntityBase
{
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(int id);
    Task<TEntity> GetByIdThrowAsync(int id, string notFoundExceptionMessage);
    Task<int> AddAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(int id);
}