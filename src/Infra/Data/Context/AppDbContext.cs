using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebShopAPI.Domain.Entities.Pedidos;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Entities.Produtos;
using WebShopAPI.Infra.Data.Configurations;
namespace WebShopAPI.Infra.Data.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opcoes) : base(opcoes)
    {
    }

    public AppDbContext()
    {
    }

    // TODO DbSet
    DbSet<Pessoa> Pessoa { get; set; }

    DbSet<Produto> Produto { get; set; }

    DbSet<Pedido> Pedido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pessoa>(new PessoaConfiguration().Configure);
        modelBuilder.Entity<Produto>(new ProdutoConfiguration().Configure);
        modelBuilder.Entity<Pedido>(new PedidoConfiguration().Configure);
    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(); // TODO Connection string

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}