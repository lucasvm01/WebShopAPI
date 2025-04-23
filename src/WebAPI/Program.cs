using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WebShopAPI.Application.Common;
using WebShopAPI.Application.Pedidos;
using WebShopAPI.Application.Pessoas;
using WebShopAPI.Domain.Entities.Pessoas;
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
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("AppDbContext"),
        b => b.MigrationsAssembly("WebShopAPI.Infra.Data")
    );
});

var assembly = typeof(PedidoDto).Assembly;

builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(assembly);
});

builder.Services.AddValidatorsFromAssembly(assembly);

builder.Services.AddMappings(assembly); 
//builder.Services.AddMappings(typeof(PessoaDto).Assembly);

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

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