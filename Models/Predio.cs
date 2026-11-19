namespace LINDE.Registro.Api.Models;

/// <summary>
/// Predio agrícola que pertenece a un productor.
/// </summary>
public class Predio
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Municipio { get; set; } = string.Empty;

    /// <summary>Superficie total del predio en hectáreas.</summary>
    public decimal SuperficieHa { get; set; }

    /// <summary>Hectáreas de desmonte que declara el productor. No puede superar la superficie.</summary>
    public decimal? DesmonteDeclaradoHa { get; set; }

    public EstadoPredio Estado { get; set; } = EstadoPredio.Registrado;

    /// <summary>Fecha de registro en UTC, asignada por el servidor.</summary>
    public DateTime FechaRegistro { get; set; }

    public int ProductorId { get; set; }

    public Productor Productor { get; set; } = null!;
}
