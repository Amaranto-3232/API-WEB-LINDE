using LINDE.Registro.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LINDE.Registro.Api.Data.Configuraciones;

/// <summary>
/// Mapeo de la entidad Predio a la tabla Predios y su relación con Productor.
/// </summary>
public class PredioConfiguracion : IEntityTypeConfiguration<Predio>
{
    public void Configure(EntityTypeBuilder<Predio> builder)
    {
        // Las restricciones CHECK respaldan en la base las reglas que también validan los DTO.
        builder.ToTable("Predios", t =>
        {
            t.HasCheckConstraint("CK_Predios_Superficie", "[SuperficieHa] > 0");
            t.HasCheckConstraint(
                "CK_Predios_Desmonte",
                "[DesmonteDeclaradoHa] IS NULL OR ([DesmonteDeclaradoHa] >= 0 AND [DesmonteDeclaradoHa] <= [SuperficieHa])");
        });

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Nombre)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(p => p.Municipio)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(p => p.SuperficieHa)
            .HasPrecision(10, 2);

        builder.Property(p => p.DesmonteDeclaradoHa)
            .HasPrecision(10, 2);

        // El estado se guarda como texto ("Registrado", "Aprobado", ...) para que la tabla sea legible.
        builder.Property(p => p.Estado)
            .HasConversion<string>()
            .HasMaxLength(20);

        // Un productor tiene muchos predios. Restrict impide borrar un productor que todavía tiene predios.
        builder.HasOne(p => p.Productor)
            .WithMany(p => p.Predios)
            .HasForeignKey(p => p.ProductorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(DatosPrueba.Predios);
    }
}
