using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

public interface IGetByIdService<TEntity, TKey>
    where TEntity : IEntity
    where TKey : IConvertible
{
    public Task<Final<TEntity>> GetByIdAsync(TKey id);
}
