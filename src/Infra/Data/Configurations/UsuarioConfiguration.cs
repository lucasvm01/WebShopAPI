using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Data;
using WebShopAPI.Domain.Entities.Usuarios;

namespace WebShopAPI.Infra.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.ToTable("Usuario");

        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id);

        builder.Property(p => p.Login)
            .HasColumnName("Login")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Senha)
        .HasColumnName("Senha")
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Permissao)
            .IsRequired()
            .HasConversion<EnumToNumberConverter<Permissao, long>>();
    }
}