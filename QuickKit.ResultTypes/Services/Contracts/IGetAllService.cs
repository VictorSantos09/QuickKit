using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

public interface IGetAllService<TEntity>
    where TEntity : IEntity
{
    public Task<Final<IEnumerable<TEntity>>> GetAllAsync();

}
