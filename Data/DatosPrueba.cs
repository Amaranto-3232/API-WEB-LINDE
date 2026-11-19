using LINDE.Registro.Api.Models;

namespace LINDE.Registro.Api.Data;

/// <summary>
/// Datos de prueba ficticios que la migración inserta con HasData.
/// Las fechas son fijas porque HasData necesita valores constantes:
/// con DateTime.UtcNow cada migración nueva detectaría un cambio.
/// </summary>
public static class DatosPrueba
{
    private static readonly DateTime Fecha = new(2026, 11, 1, 12, 0, 0, DateTimeKind.Utc);

    public static readonly Productor[] Productores =
    [
        new() { Id = 1, Nombre = "Ana", Apellido = "Mendoza", Ci = "4567891", Telefono = "70011223", FechaRegistro = Fecha },
        new() { Id = 2, Nombre = "Luis", Apellido = "Justiniano", Ci = "5678912", Telefono = "70022334", FechaRegistro = Fecha },
        new() { Id = 3, Nombre = "Rosa", Apellido = "Vargas", Ci = "6789123", Telefono = null, FechaRegistro = Fecha }
    ];

    // Los predios se cargan solo con ProductorId, sin asignar la navegación Productor.
    public static readonly Predio[] Predios =
    [
        new() { Id = 1, Nombre = "El Algarrobo", Municipio = "San Julián", SuperficieHa = 120.50m, DesmonteDeclaradoHa = 0m, Estado = EstadoPredio.Registrado, FechaRegistro = Fecha, ProductorId = 1 },
        new() { Id = 2, Nombre = "La Esperanza", Municipio = "Cuatro Cañadas", SuperficieHa = 45.00m, DesmonteDeclaradoHa = 10.00m, Estado = EstadoPredio.Registrado, FechaRegistro = Fecha, ProductorId = 1 },
        new() { Id = 3, Nombre = "Santa Rosa", Municipio = "Pailón", SuperficieHa = 300.00m, DesmonteDeclaradoHa = null, Estado = EstadoPredio.Aprobado, FechaRegistro = Fecha, ProductorId = 2 },
        new() { Id = 4, Nombre = "Los Tajibos", Municipio = "Okinawa Uno", SuperficieHa = 3.50m, DesmonteDeclaradoHa = null, Estado = EstadoPredio.Registrado, FechaRegistro = Fecha, ProductorId = 3 },
        new() { Id = 5, Nombre = "San Antonio", Municipio = "Mineros", SuperficieHa = 80.25m, DesmonteDeclaradoHa = 20.00m, Estado = EstadoPredio.Observado, FechaRegistro = Fecha, ProductorId = 3 }
    ];
}
