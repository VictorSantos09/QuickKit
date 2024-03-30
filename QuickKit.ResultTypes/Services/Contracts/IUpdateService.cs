using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

public interface IUpdateService<TEntity>
    where TEntity : IEntity
{
    public Task<Final> UpdateAsync(TEntity entity);
}
