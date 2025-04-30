# WebShopAPI

## WebAPI que permite gerenciar os pedidos de uma loja.

### Implementada utilizando .NET 9.0, Entity Framework Core e seguindo o padrão de design DDD, incluindo CQRS.

Para adicionar as migrations:
dotnet ef migrations add [NomeDaMigration] --project src/Infra/Data --startup-project src/WebAPI

Para criar o banco:
dotnet ef database update --project src/Infra/Data --startup-project src/WebAPI

URL do Swagger: https://localhost:7981/swagger/
