using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LINDE.Registro.Api.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ci = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Predios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Municipio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SuperficieHa = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: false),
                    DesmonteDeclaradoHa = table.Column<decimal>(type: "decimal(10,2)", precision: 10, scale: 2, nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Predios", x => x.Id);
                    table.CheckConstraint("CK_Predios_Desmonte", "[DesmonteDeclaradoHa] IS NULL OR ([DesmonteDeclaradoHa] >= 0 AND [DesmonteDeclaradoHa] <= [SuperficieHa])");
                    table.CheckConstraint("CK_Predios_Superficie", "[SuperficieHa] > 0");
                    table.ForeignKey(
                        name: "FK_Predios_Productores_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Productores",
                columns: new[] { "Id", "Apellido", "Ci", "FechaRegistro", "Nombre", "Telefono" },
                values: new object[,]
                {
                    { 1, "Mendoza", "4567891", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Ana", "70011223" },
                    { 2, "Justiniano", "5678912", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Luis", "70022334" },
                    { 3, "Vargas", "6789123", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Rosa", null }
                });

            migrationBuilder.InsertData(
                table: "Predios",
                columns: new[] { "Id", "DesmonteDeclaradoHa", "Estado", "FechaRegistro", "Municipio", "Nombre", "ProductorId", "SuperficieHa" },
                values: new object[,]
                {
                    { 1, 0m, "Registrado", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "San Julián", "El Algarrobo", 1, 120.50m },
                    { 2, 10.00m, "Registrado", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Cuatro Cañadas", "La Esperanza", 1, 45.00m },
                    { 3, null, "Aprobado", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Pailón", "Santa Rosa", 2, 300.00m },
                    { 4, null, "Registrado", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Okinawa Uno", "Los Tajibos", 3, 3.50m },
                    { 5, 20.00m, "Observado", new DateTime(2026, 11, 1, 12, 0, 0, 0, DateTimeKind.Utc), "Mineros", "San Antonio", 3, 80.25m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Predios_ProductorId",
                table: "Predios",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Productores_Ci",
                table: "Productores",
                column: "Ci",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Predios");

            migrationBuilder.DropTable(
                name: "Productores");
        }
    }
}
