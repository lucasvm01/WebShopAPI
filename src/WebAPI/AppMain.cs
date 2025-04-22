using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebShopAPI.Application.Pedidos.Queries.GetPedido;
using WebShopAPI.Domain.Interfaces.Infrastructure;
using WebShopAPI.Infra.Data.Context;
using WebShopAPI.Infra.Data.Management;


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

    // TODO Adicionar Auth
});

//Adiciona o contexto para gerar migration
builder.Services.AddDbContext<AppDbContext>((_, options) =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbContext"), // TODO
        b => b.MigrationsAssembly("WebShopAPI.Infra.Data")
    );
});

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

var assembly = typeof(GetPedidoQuery).Assembly;
builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(assembly);
});
builder.Services.AddValidatorsFromAssembly(assembly);

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