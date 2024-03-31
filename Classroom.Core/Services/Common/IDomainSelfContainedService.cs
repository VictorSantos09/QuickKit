using QuickKit.ResultTypes.Services.Contracts;
using QuickKit.Shared.Entities;

namespace Classroom.Core.Services.Common;

public interface IDomainSelfContainedService<TEntity, TKey>
    : IAddService<TEntity>
    , IDeleteService<TKey>
    , IGetAllService<TEntity>
    , IGetByIdService<TEntity, TKey>
    , IUpdateService<TEntity>
    where TEntity : IEntity
    where TKey : IConvertible
{
}
