using QuickKit.ResultTypes.Services.Contracts;
using QuickKit.Shared.Entities;
using QuickKit.Shared.Services.Contracts;

namespace Classroom.Core.Services.Common;

public interface IDomainSelfContainedValueObjectService<TEntity, TKey>
    : IAddValueObjectService<TEntity>
    , IDeleteValueObjectService<TKey>
    , IGetAllValueObjectService<TEntity>
    , IGetByIdValueObjectService<TEntity, TKey>
    , IUpdateValueObjectService<TEntity>
    where TEntity : IEntity
    where TKey: IConvertible
{
}

public interface IDomainSelfContainedService<TEntity, TKey>
    : IAddService<TEntity>
    , IDeleteService<TEntity, TKey>
    , IGetAllService<TEntity>
    , IGetByIdService<TEntity, TKey>
    , IUpdateService<TEntity>
    where TEntity : IEntity
    where TKey : IConvertible
{
}
