using QuickKit.Configuration;
using QuickKit.Sample.API.Repositories;
using QuickKit.Sample.API.Services;
using QuickKit.Sample.API.Validatos;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddQuickKit("localhost");

builder.Services.AddScoped<ICargaService, CargaService>();
builder.Services.AddScoped<ICargaRepository, CargaRepository>();
builder.Services.AddScoped<CargaValidator>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
