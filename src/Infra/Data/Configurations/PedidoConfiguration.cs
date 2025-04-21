using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShopAPI.Domain.Entities.Pedidos;

namespace WebShopAPI.Infra.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("Pedido");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.DataAbertura)
            .HasColumnType("datetime");

        builder.Property(p => p.DataFechamento)
            .HasColumnType("datetime");

        builder.HasOne(p => p.Pessoa)
            .WithMany(x => x.Pedidos)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasForeignKey(f => f.PessoaId)
            .HasConstraintName("FK_Pessoa_Produto_PessoaId");
    }
}