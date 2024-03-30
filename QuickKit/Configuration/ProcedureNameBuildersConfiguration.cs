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
    /// Adds procedure name builders for the specified entity to the service collection.
    /// </summary>
    /// <typeparam name="TEntity">The type of the entity.</typeparam>
    /// <param name="services">The service collection to add the procedure name builders to.</param>
    /// <param name="entity">The entity type.</param>
    /// <param name="lifetime">The lifetime of the registered services (default is <see cref="ServiceLifetime.Transient"/>).</param>
    /// <returns>The modified service collection.</returns>
    public static IServiceCollection AddProcedureNameBuilders<TEntity>(this IServiceCollection services,
                                                                       TEntity entity,
                                                                       ServiceLifetime lifetime = DefaultLifetime) where TEntity : Type, IEntity
    {
        List<ServiceDescriptor> descriptor = GetServiceDescriptors(entity, lifetime);
        AddDescriptorToServices(services, descriptor);
        return services;
    }

    /// <summary>
    /// Adds procedure name builders from the specified assembly to the service collection.
    /// </summary>
    /// <param name="services">The service collection to add the procedure name builders to.</param>
    /// <param name="assembly">The assembly containing the procedure name builders.</param>
    /// <param name="onlyPublic">A flag indicating whether to include only public entities.</param>
    /// <param name="lifetime">The lifetime of the registered services.</param>
    /// <returns>The modified service collection.</returns>
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
