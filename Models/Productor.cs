namespace LINDE.Registro.Api.Models;

/// <summary>
/// Productor agrícola dueño de uno o más predios.
/// </summary>
public class Productor
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Apellido { get; set; } = string.Empty;

    /// <summary>Cédula de identidad, única por productor.</summary>
    public string Ci { get; set; } = string.Empty;

    public string? Telefono { get; set; }

    /// <summary>Fecha de registro en UTC, asignada por el servidor.</summary>
    public DateTime FechaRegistro { get; set; }

    public ICollection<Predio> Predios { get; set; } = new List<Predio>();
}
