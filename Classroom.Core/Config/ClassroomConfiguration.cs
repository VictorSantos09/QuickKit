using Classroom.Core.Config.Context;
using Classroom.Core.Controllers;
using Classroom.Core.GraphQL.Queries;
using Classroom.Core.GraphQL.Queries.Base;
using Classroom.Core.Repositories;
using Classroom.Core.Services;
using FluentValidation;
using QuickKit.Configuration;
using QuickKit.ResultTypes.Configuration;
using QuickKit.ResultTypes.Exceptions;
using QuickKit.Security.Configuration;
using QuickKit.Shared.Exceptions;
using QuickKit.Shared.Exceptions.Base;

namespace Classroom.Core.Config;

public static class ClassroomConfiguration
{
    public static IServiceCollection AddClassroomAPI(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();
        ConfigureDbContext(services);
        ConfigureGraphQL(services);
        ConfigureDefaultExceptionsMessages(services);
        ConfigureServices(services);

        services.AddJwtBearerKit(TokenInfo.Key, TokenInfo.Issuer, TokenInfo.Audience);

        services.AddQuickKit("Server=localhost;Database=quickkit_demo;Uid=root;Pwd=root;");
        return services;
    }

    private static void ConfigureDefaultExceptionsMessages(IServiceCollection services)
    {
        services.CustomDefaultMessageFor<EntityNotFoundException>("entidade não encontrada");
        services.CustomDefaultMessageFor<NotFoundException>("conteúdo não encontrado");
        services.CustomDefaultMessageFor<SnapshotNullException>("snapshot inválida");
        services.CustomDefaultMessageFor<InvalidArgumentResultException>("resultado fornecido é inválido");
    }

    private static void ConfigureDbContext(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();
    }

    private static void ConfigureGraphQL(IServiceCollection services)
    {
        services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddTypeExtension<ClassroomQuery>()
            .AddTypeExtension<TeacherQuery>()
            .AddFiltering()
            .AddSorting();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddTransient<IClassroomService, ClassroomService>();
        services.AddTransient<IClassroomServiceValueObject, ClassroomServiceValueObject>();
        services.AddTransient<IClassroomRepository, ClassroomRepository>();
    }
}
