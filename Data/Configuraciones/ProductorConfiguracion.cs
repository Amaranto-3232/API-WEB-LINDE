using LINDE.Registro.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LINDE.Registro.Api.Data.Configuraciones;

/// <summary>
/// Mapeo de la entidad Productor a la tabla Productores.
/// </summary>
public class ProductorConfiguracion : IEntityTypeConfiguration<Productor>
{
    public void Configure(EntityTypeBuilder<Productor> builder)
    {
        builder.ToTable("Productores");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Apellido)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.Ci)
            .IsRequired()
            .HasMaxLength(10);

        builder.HasIndex(p => p.Ci)
            .IsUnique();

        builder.Property(p => p.Telefono)
            .HasMaxLength(20);

        builder.HasData(DatosPrueba.Productores);
    }
}
