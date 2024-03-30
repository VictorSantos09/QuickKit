using Microsoft.Extensions.DependencyInjection;
using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;
using QuickKit.Shared.Entities;
using System.Reflection;

namespace QuickKit.Configuration;
/// <summary>
/// Provides configuration methods for adding procedure name builders to the service collection.
/// </summary>
public static class ProcedureNameBuildersConfiguration
{
    /// <summary>
    /// The default lifetime for the service.
    /// </summary>
    public const ServiceLifetime DefaultLifetime = ServiceLifetime.Transient;

    /// <summary>
    /// Adds procedure name builders from the specified assembly to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the procedure name builders to.</param>
    /// <param name="assembly">The assembly containing the procedure name builders.</param>
    /// <param name="onlyPublic">A flag indicating whether to include only public entities.</param>
    /// <param name="lifetime">The lifetime of the registered services.</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddProcedureNameBuildersFromAssembly(this IServiceCollection services,
                                                                                   ServiceLifetime lifetime = DefaultLifetime)
    {
        List<ServiceDescriptor> descriptors = new();

        descriptors.AddRange(GetServiceDescriptors(lifetime));

        AddDescriptorToServices(services, descriptors);

        return services;
    }

    private static IEnumerable<Type> FindEntitiesOnAssembly(Assembly assembly, bool onlyPublic)
    {
        Type entityInterfaceType = typeof(IEntity);

        IEnumerable<Type> types = assembly.GetTypes().Where(type =>
        type.IsClass &&
        !type.IsAbstract &&
        !type.IsInterface &&
        entityInterfaceType.IsAssignableFrom(type));

        if (onlyPublic)
        {
            types = types.Where(type => type.IsPublic);
        }

        return types;
    }

    private static List<ServiceDescriptor> GetServiceDescriptors(ServiceLifetime lifetime)
    {
        Dictionary<Type, Type> dictionary = new()
        {
            { typeof(IProcedureNameBuilderAddStrategy), typeof(ProcedureNameBuilderAddStrategy) },
            { typeof(IProcedureNameBuilderDeleteStrategy), typeof(ProcedureNameBuilderDeleteStrategy) },
            { typeof(IProcedureNameBuilderGetAllStrategy), typeof(ProcedureNameBuilderGetAllStrategy)},
            { typeof(IProcedureNameBuilderGetByIdStrategy), typeof(ProcedureNameBuilderGetByIdStrategy) },
            { typeof(IProcedureNameBuilderUpdateStrategy), typeof(ProcedureNameBuilderUpdateStrategy) }
        };

        List<ServiceDescriptor> services = new();

        foreach (KeyValuePair<Type, Type> type in dictionary)
        {
            ServiceDescriptor service = new(type.Key, type.Value, lifetime);
            services.Add(service);
        }

        return services;
    }

    private static void AddDescriptorToServices(IServiceCollection services, IEnumerable<ServiceDescriptor> descriptors)
    {
        foreach (ServiceDescriptor descriptor in descriptors)
        {
            services.Add(descriptor);
        }
    }
}
