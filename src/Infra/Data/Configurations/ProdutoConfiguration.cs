using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShopAPI.Domain.Entities.Produtos;

namespace WebShopAPI.Infra.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.Descricao)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(p => p.Quantidade);

        builder.Property(p => p.IsAtivo)
            .IsRequired();

        builder.HasMany(p => p.Pedidos)
            .WithMany(x => x.Produtos);
    }
}