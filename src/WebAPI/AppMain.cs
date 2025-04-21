using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
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

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();