using Classroom.Core.Config;
using QuickKit.AspNetCore.Configuration;
using QuickKit.AspNetCore.Swagger.Configuration;
using QuickKit.AspNetCore.Swagger.Configuration.Requests;
using QuickKit.Configuration;
using System.Reflection;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocsFromXmlComments(Assembly.GetExecutingAssembly());
builder.Services.AddClassroomAPI();
builder.Services.AddProcedureNameBuildersFromAssembly();

WebApplication app = builder.Build();

app.UseAuthorization();

if (app.Environment.IsProduction())
{
    SwaggerBasicAuthRequest request = new("/swagger", "swagger", "swagger");
    _ = app.UseSwaggerAuthorizationMiddleware(request);

    _ = app.UseSwagger();
    _ = app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Secure Swagger v1");
        x.DocumentTitle = "ClassroomCore";
        x.EnableFilter();
    });
}
else
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.MapGraphQL();

app.AddDefaultGlobalExceptionMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
