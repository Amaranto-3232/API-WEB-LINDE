using LINDE.Registro.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace LINDE.Registro.Api.Data;

/// <summary>
/// Contexto de EF Core de la API de registro de LINDE.
/// </summary>
public class LindeDbContext(DbContextOptions<LindeDbContext> options) : DbContext(options)
{
    public DbSet<Productor> Productores => Set<Productor>();

    public DbSet<Predio> Predios => Set<Predio>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Aplica todas las clases IEntityTypeConfiguration de la carpeta Configuraciones.
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(LindeDbContext).Assembly);
    }
}
