using QuickKit.Shared.Entities;

namespace QuickKit.ResultTypes.Services.Contracts;

public interface IGetAllValueObjectService<TEntity>
    where TEntity : IEntity
{
    public Task<Final<IEnumerable<TEntity>>> GetAllAsync();

}
