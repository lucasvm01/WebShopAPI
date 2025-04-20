using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebShopAPI.Domain.Entities.Pessoas;

namespace WebShopAPI.Infra.Data.Configurations;

public class PessoaConfiguration : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.ToTable("Pessoa");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id);

        builder.Property(p => p.Nome)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.CPF)
            .IsRequired()
            .HasMaxLength(11);

        builder.Property(p => p.Email)
            .IsRequired()
            .HasMaxLength(50);

        builder.OwnsOne(
            p => p.TipoPessoa, 
            tipoPessoa =>
            {
                tipoPessoa.Property(t => t.IsCliente)
                    .HasColumnName("IsCliente")
                    .IsRequired();

                tipoPessoa.Property(t => t.IsFuncionario)
                    .HasColumnName("IsFuncionario")
                    .IsRequired();
            }
        );
        builder.Navigation(p => p.TipoPessoa)
            .IsRequired();

        builder.Property(p => p.IsAtivo)
            .IsRequired();

        builder.HasMany(p => p.Pedidos)
            .WithOne(x => x.Pessoa);
    }
}