using QuickKit.AspNetCore.Controllers.Contracts;
using QuickKit.Shared.Entities;

namespace Classroom.Core.Controllers;

public interface IController<TEntity, TKey> : IControllerAdd<TEntity>,
    IControllerGetAll<TEntity>,
    IControllerUpdate<TEntity>,
    IControllerDelete<TKey>,
    IControllerGetById<TKey>,
    IControllerTestEndpoint
    where TEntity : IEntity
    where TKey : IConvertible
{
}
