namespace LINDE.Registro.Api.Models;

/// <summary>
/// Estado de un predio dentro del proceso de certificación de LINDE.
/// En esta API solo se consulta; lo cambia el flujo de validación.
/// </summary>
public enum EstadoPredio
{
    Registrado,
    EnRevision,
    Observado,
    Aprobado
}
