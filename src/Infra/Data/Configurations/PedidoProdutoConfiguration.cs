using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShopAPI.Domain.Entities.Pedidos;

namespace WebShopAPI.Infra.Data.Configurations;

public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>
{
    public void Configure(EntityTypeBuilder<PedidoProduto> builder)
    {
        builder.ToTable("PedidoProduto");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.QuantidadeProduto);

        builder.HasOne(p => p.Produto)
            .WithMany(x => x.Pedidos)
            .HasForeignKey(f => f.ProdutoId)
            .HasConstraintName("FK_PedidoProduto_Produto_ProdutoId");

        builder.HasOne(p => p.Pedido)
            .WithMany(x => x.PedidoProdutos)
            .HasForeignKey(f => f.PedidoId)
            .HasConstraintName("FK_PedidoProduto_Pedido_PedidoId");
    }
}