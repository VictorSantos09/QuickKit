using Microsoft.Extensions.DependencyInjection;
using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;

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


    public static IServiceCollection AddProcedureNameBuildersFromAssembly(this IServiceCollection services,
                                                                                   ServiceLifetime lifetime = DefaultLifetime)
    {
        List<ServiceDescriptor> descriptors = GetServiceDescriptors(lifetime);

        AddDescriptorToServices(services, descriptors);

        return services;
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
