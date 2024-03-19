using Classroom.Core.Controllers;
using Classroom.Core.Repositories;
using Classroom.Core.Services;
using FluentValidation;
using QuickKit.Configuration;
using QuickKit.Security.Configuration;
using QuickKit.Shared.Exceptions;
using QuickKit.Shared.Exceptions.Base;

namespace Classroom.Core.Config
{
    public static class ClassroomConfiguration
    {
        public static IServiceCollection AddClassroomAPI(this IServiceCollection services)
        {
            ConfigureDefaultExceptionsMessages(services);

            services.AddValidatorsFromAssemblyContaining<Program>();

            services.AddTransient<IClassroomService, ClassroomService>();
            services.AddTransient<IClassroomServiceValueObject, ClassroomServiceValueObject>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();

            services.AddJwtBearerKit(TokenInfo.Key, TokenInfo.Issuer, TokenInfo.Audience);

            services.AddQuickKit("Server=localhost;Database=quickkit_demo;Uid=root;Pwd=root;");
            return services;
        }

        private static void ConfigureDefaultExceptionsMessages(this IServiceCollection services)
        {
            services.CustomDefaultMessageFor<EntityNotFoundException>("entidade não encontrada");
            services.CustomDefaultMessageFor<NotFoundException>("conteúdo não encontrado");
            services.CustomDefaultMessageFor<SnapshotNullException>("snapshot inválida");
            services.CustomDefaultMessageFor<InvalidArgumentResultException>("resultado fornecido é inválido");
        }
    }
}
