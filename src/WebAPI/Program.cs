using DotNetEnv;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebShopAPI.Application.Pedidos.Queries.GetPedido;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Infra.Data.Context;
using WebShopAPI.Infra.Data.Management;


Env.Load();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Title = "",
            Version = "v1",
            Description = "",
        }
    );

    c.EnableAnnotations();

    c.DescribeAllParametersInCamelCase();
});

//Adiciona o contexto para gerar migration
string connectionString = Environment.GetEnvironmentVariable("APP_DB_CONNECTION_STRING");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("The connection string is not configured.");
}

builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(connectionString));

var assembly = typeof(GetPedidoQuery).Assembly;
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddValidatorsFromAssembly(assembly);


builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<AppDbContext>();
    if (context.Database.GetPendingMigrations().Any())
    {
        context.Database.Migrate();
    }
}

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();