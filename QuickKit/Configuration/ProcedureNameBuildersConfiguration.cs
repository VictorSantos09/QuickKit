using Microsoft.Extensions.DependencyInjection;
using QuickKit.Builders.ProcedureName.Add;
using QuickKit.Builders.ProcedureName.Delete;
using QuickKit.Builders.ProcedureName.GetAll;
using QuickKit.Builders.ProcedureName.GetById;
using QuickKit.Builders.ProcedureName.Update;
using QuickKit.Shared.Entities;
using QuickKit.Shared.Services;
using System.Reflection;

namespace QuickKit.Configuration;
public static class ProcedureNameBuildersConfiguration
{
    public const ServiceLifetime DefaultLifetime = SERVICE_DESCRIPTOR.DEFAULT_LIFETIME;

    public static IServiceCollection AddProcedureNameBuilders<TEntity>(this IServiceCollection services,
                                                                       TEntity entity,
                                                                       ServiceLifetime lifetime = DefaultLifetime) where TEntity : Type, IEntity
    {
        var descriptor = GetServiceDescriptors(entity, lifetime);
        AddDescriptorToServices(services, descriptor);
        return services;
    }

    public static IServiceCollection AddProcedureNameBuildersFromAssembly(this IServiceCollection services,
                                                                                   Assembly assembly,
                                                                                   bool onlyPublic = true,
                                                                                   ServiceLifetime lifetime = DefaultLifetime)
    {
        var entities = FindEntitiesOnAssembly(assembly, onlyPublic);

        List<ServiceDescriptor> descriptors = new();

        foreach (var entity in entities)
        {
            descriptors.AddRange(GetServiceDescriptors(entity, lifetime));
        }

        AddDescriptorToServices(services, descriptors);

        return services;
    }

    private static IEnumerable<Type> FindEntitiesOnAssembly(Assembly assembly, bool onlyPublic)
    {
        var entityInterfaceType = typeof(IEntity);

        var types = assembly.GetTypes().Where(type =>
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
        var dictionary = new Dictionary<Type, Type>
        {
            { typeof(IProcedureNameBuilderAddStrategy), typeof(ProcedureNameBuilderAddStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderDeleteStrategy), typeof(ProcedureNameBuilderDeleteStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderGetAllStrategy), typeof(ProcedureNameBuilderGetAllStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderGetByIdStrategy), typeof(ProcedureNameBuilderGetByIdStrategy<>).MakeGenericType(entity) },
            { typeof(IProcedureNameBuilderUpdateStrategy), typeof(ProcedureNameBuilderUpdateStrategy<>).MakeGenericType(entity) }
        };

        var services = new List<ServiceDescriptor>();

        foreach (var type in dictionary)
        {
            ServiceDescriptor service = new(type.Key, type.Value, lifetime);
            services.Add(service);
        }

        return services;
    }

    private static void AddDescriptorToServices(IServiceCollection services, IEnumerable<ServiceDescriptor> descriptors)
    {
        foreach (var descriptor in descriptors)
        {
            services.Add(descriptor);
        }
    }
}
