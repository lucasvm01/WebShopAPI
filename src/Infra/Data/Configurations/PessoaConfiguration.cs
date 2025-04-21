using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebShopAPI.Domain.Entities.Pessoas;
using WebShopAPI.Domain.Entities.Usuarios;

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

        builder.Property(p => p.TipoPessoa)
            .IsRequired()
            .HasConversion<EnumToNumberConverter<Permissao, long>>();

        builder.Property(p => p.IsAtivo)
            .IsRequired();

        builder.HasMany(p => p.Pedidos)
            .WithOne(x => x.Pessoa);
    }
}