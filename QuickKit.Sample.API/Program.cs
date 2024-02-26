using QuickKit.AspNetCore.Configuration;
using QuickKit.Configuration;
using QuickKit.Sample.API.Repositories;
using QuickKit.Sample.API.Services;
using QuickKit.Sample.API.Validatos;
using QuickKit.Security.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string key = "mysuperfantasticsecretkeythatissecure";
string issuer = "localhost";
string audience = "localhost";

builder.Services.AddJwtBearerKit(Encoding.UTF8.GetBytes(key), issuer, audience);
builder.Services.AddQuickKit("localhost");

builder.Services.AddScoped<ICargaService, CargaService>();
builder.Services.AddScoped<ICargaRepository, CargaRepository>();
builder.Services.AddScoped<CargaValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    _ = app.UseSwagger();
    _ = app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.AddDefaultGlobalExceptionMiddleware("um erro ocorreu ao processar sua solicitação.", true);
app.UseAuthorization();

app.MapControllers();

app.Run();
