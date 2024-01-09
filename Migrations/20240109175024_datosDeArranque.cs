using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiPrimeraApiRest.Migrations
{
    /// <inheritdoc />
    public partial class datosDeArranque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenidades", "Detalle", "FechaCreacion", "FechaModificacion", "ImagenUrl", "MetrosCuadrados", "Nombre", "Ocupantes", "Tarifa" },
                values: new object[,]
                {
                    { 1, "Amenidades 1", "Villa 1", new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1144), new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1158), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.villas.com%2Fespana%", 100, "Villa 1", 4, 100.0 },
                    { 2, "Amenidades 2", "Villa 2", new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1162), new DateTime(2024, 1, 9, 11, 50, 23, 591, DateTimeKind.Local).AddTicks(1163), "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.villas.com%2Fespana%", 100, "Villa 2", 4, 100.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
