using Classroom.Core.Config.Context;
using Classroom.Core.Controllers;
using Classroom.Core.GraphQL.Queries;
using Classroom.Core.GraphQL.Queries.Base;
using Classroom.Core.Repositories;
using Classroom.Core.Services;
using FluentValidation;
using QuickKit.Security.Configuration;

namespace Classroom.Core.Config;

public static class ClassroomConfiguration
{
    public static IServiceCollection AddClassroomAPI(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<Program>();
        ConfigureDbContext(services);
        ConfigureGraphQL(services);
        ConfigureServices(services);

        services.AddJwtBearerKit(TokenInfo.Key, TokenInfo.Issuer, TokenInfo.Audience);

        return services;
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
        services.AddTransient<IClassroomRepository, ClassroomRepository>();
    }
}
