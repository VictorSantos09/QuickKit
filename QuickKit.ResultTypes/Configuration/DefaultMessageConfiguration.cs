using Microsoft.Extensions.DependencyInjection;
using QuickKit.ResultTypes.Exceptions;
using QuickKit.Shared.Exceptions;
using QuickKit.Shared.Exceptions.Base;

namespace QuickKit.ResultTypes.Configuration;

public static class DefaultMessageConfiguration
{
    public static IServiceCollection CustomDefaultMessageFor<TException>(this IServiceCollection services, string message)
        where TException : KitException, IException
    {
        switch (typeof(TException))
        {
            case Type exception when exception == typeof(EntityNotFoundException):
                EntityNotFoundException.DefaultMessage = message;
                break;
            case Type exception when exception == typeof(SnapshotNullException):
                SnapshotNullException.DefaultMessage = message;
                break;

            case Type exception when exception == typeof(NotFoundException):
                NotFoundException.DefaultMessage = message;
                break;
            case Type exception when exception == typeof(InvalidArgumentResultException):
                InvalidArgumentResultException.DefaultMessage = message;
                break;
            case Type exception when exception == typeof(ValidationFailureException):
                ValidationFailureException.DefaultMessage = message;
                break;
            default:
                throw new InvalidOperationException("exception wasn't identified");
        }
        return services;
    }
}