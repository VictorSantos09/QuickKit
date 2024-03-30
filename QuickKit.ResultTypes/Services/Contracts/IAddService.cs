using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

public interface IAddService<TEntity>
    where TEntity : IEntity
{
    public Task<Final> AddAsync(TEntity entity);
}
