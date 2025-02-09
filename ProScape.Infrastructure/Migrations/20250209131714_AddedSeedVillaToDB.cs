using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProScape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedSeedVillaToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 9, 13, 17, 14, 487, DateTimeKind.Utc).AddTicks(5264), "A stunning villa with direct beach access and breathtaking ocean views.", "https://static.independent.co.uk/2024/01/09/12/FAO_83054_Villa_Mangas_Albufeira_0723_01_RGB-136-DPI-For-Web.jpg", "Luxury Beachfront Villa", 8, 500.0, 3500, new DateTime(2025, 2, 9, 13, 17, 14, 487, DateTimeKind.Utc).AddTicks(5270) },
                    { 2, new DateTime(2025, 2, 9, 13, 17, 14, 487, DateTimeKind.Utc).AddTicks(5272), "A cozy villa nestled in the mountains, perfect for a relaxing getaway.", "https://media.graphassets.com/kcqbCpucTbmzbM5yqelI", "Mountain Retreat", 6, 300.0, 2500, new DateTime(2025, 2, 9, 13, 17, 14, 487, DateTimeKind.Utc).AddTicks(5272) },
                    { 3, new DateTime(2025, 2, 9, 13, 17, 14, 487, DateTimeKind.Utc).AddTicks(5274), "A modern penthouse villa located in the heart of the city with skyline views.", "https://static.baranselgrup.com/nwm-248899-w1278-bavadi-villalari.png", "Urban Penthouse", 10, 700.0, 4000, new DateTime(2025, 2, 9, 13, 17, 14, 487, DateTimeKind.Utc).AddTicks(5274) }
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

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
