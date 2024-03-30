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
        _ = services.AddValidatorsFromAssemblyContaining<Program>();
        ConfigureDbContext(services);
        ConfigureGraphQL(services);
        ConfigureServices(services);

        _ = services.AddJwtBearerKit(TokenInfo.Key, TokenInfo.Issuer, TokenInfo.Audience);

        return services;
    }

    private static void ConfigureDbContext(IServiceCollection services)
    {
        _ = services.AddDbContext<AppDbContext>();
    }

    private static void ConfigureGraphQL(IServiceCollection services)
    {
        _ = services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddTypeExtension<ClassroomQuery>()
            .AddTypeExtension<TeacherQuery>()
            .AddFiltering()
            .AddSorting();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        _ = services.AddTransient<IClassroomService, ClassroomService>();
        _ = services.AddTransient<IClassroomRepository, ClassroomRepository>();
    }
}
