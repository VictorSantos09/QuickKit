using Classroom.Core.Config;
using QuickKit.AspNetCore.Configuration;
using QuickKit.AspNetCore.Swagger.Configuration;
using QuickKit.AspNetCore.Swagger.Configuration.Requests;
using QuickKit.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerDocsFromXmlComments(Assembly.GetExecutingAssembly());
builder.Services.AddClassroomAPI();
builder.Services.AddProcedureNameBuildersFromAssembly(Assembly.GetExecutingAssembly());

var app = builder.Build();

app.UseAuthorization();

if (app.Environment.IsProduction())
{
    SwaggerBasicAuthRequest request = new("/swagger", "swagger", "swagger");
    app.UseSwaggerAuthorizationMiddleware(request);

    app.UseSwagger();
    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "Secure Swagger v1");
        x.DocumentTitle = "ClassroomCore";
        x.EnableFilter();
    });
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGraphQL();

app.AddDefaultGlobalExceptionMiddleware();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
