using QuickKit.AspNetCore.Controllers.Contracts;
using QuickKit.Shared.Entities;

namespace Classroom.Core.Controllers;

public interface IController<TEntity, TKey> : IAddController<TEntity>,
    IGetAllController<TEntity>,
    IUpdateController<TEntity>,
    IDeleteController<TKey>,
    IGetByIdController<TKey>,
    ITestEndpointController
    where TEntity : IEntity
    where TKey : IConvertible
{
}
