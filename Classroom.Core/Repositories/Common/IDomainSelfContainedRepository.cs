using QuickKit.Repositories.Contracts;
using QuickKit.Shared.Entities;

namespace Classroom.Core.Repositories.Common;

public interface IDomainSelfContainedRepository<TEntity, TKey>
    : IAddRepository<TEntity>,
    IDeleteRepository<TEntity, TKey>,
    IGetAllRepository<TEntity>,
    IGetByIdRepository<TEntity, TKey>,
    IGetByIdThrowRepository<TEntity, TKey>,
    IUpdateRepository<TEntity>
    where TEntity : IEntity
    where TKey : IConvertible
{
}
