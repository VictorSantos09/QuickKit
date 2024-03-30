using Microsoft.Extensions.DependencyInjection;
using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;
using QuickKit.Shared.Entities;
using System.Reflection;

namespace QuickKit.Configuration;
public static class ProcedureNameBuildersConfiguration
{
    public const ServiceLifetime DefaultLifetime = ServiceLifetime.Transient;

    public static IServiceCollection AddProcedureNameBuilders<TEntity>(this IServiceCollection services,
                                                                       TEntity entity,
                                                                       ServiceLifetime lifetime = DefaultLifetime) where TEntity : Type, IEntity
    {
        List<ServiceDescriptor> descriptor = GetServiceDescriptors(entity, lifetime);
        AddDescriptorToServices(services, descriptor);
        return services;
    }

    public static IServiceCollection AddProcedureNameBuildersFromAssembly(this IServiceCollection services,
                                                                                   Assembly assembly,
                                                                                   bool onlyPublic = true,
                                                                                   ServiceLifetime lifetime = DefaultLifetime)
    {
        IEnumerable<Type> entities = FindEntitiesOnAssembly(assembly, onlyPublic);

        List<ServiceDescriptor> descriptors = new();

        foreach (Type entity in entities)
        {
            descriptors.AddRange(GetServiceDescriptors(entity, lifetime));
        }

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

    private static List<ServiceDescriptor> GetServiceDescriptors<TEntity>(TEntity entity, ServiceLifetime lifetime) where TEntity : Type
    {
        Dictionary<Type, Type> dictionary = new()
        {
            { typeof(IProcedureNameBuilderAddStrategy), typeof(ProcedureNameBuilderAddStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderDeleteStrategy), typeof(ProcedureNameBuilderDeleteStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderGetAllStrategy), typeof(ProcedureNameBuilderGetAllStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderGetByIdStrategy), typeof(ProcedureNameBuilderGetByIdStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderUpdateStrategy), typeof(ProcedureNameBuilderUpdateStrategy<>).MakeGenericType(entity) }
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
