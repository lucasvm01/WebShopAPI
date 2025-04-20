using Microsoft.EntityFrameworkCore;
using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Infra.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
}