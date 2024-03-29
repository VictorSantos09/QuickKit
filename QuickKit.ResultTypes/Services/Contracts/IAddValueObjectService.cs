using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

public interface IAddValueObjectService<TEntity>
    where TEntity : IEntity
{
    public Task<Final> AddAsync(TEntity entity);
}
