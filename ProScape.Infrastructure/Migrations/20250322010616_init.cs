using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProScape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Villas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Sqft = table.Column<int>(type: "int", nullable: false),
                    Occupancy = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Villas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VillaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amenities_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VillaNumbers",
                columns: table => new
                {
                    Villa_Number = table.Column<int>(type: "int", nullable: false),
                    VillaId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VillaNumbers", x => x.Villa_Number);
                    table.ForeignKey(
                        name: "FK_VillaNumbers_Villas_VillaId",
                        column: x => x.VillaId,
                        principalTable: "Villas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Occupancy", "Price", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 3, 22, 1, 6, 16, 179, DateTimeKind.Utc).AddTicks(3014), "A stunning villa with direct beach access and breathtaking ocean views.", "https://static.independent.co.uk/2024/01/09/12/FAO_83054_Villa_Mangas_Albufeira_0723_01_RGB-136-DPI-For-Web.jpg", "Luxury Beachfront Villa", 8, 500.0, 3500, new DateTime(2025, 3, 22, 1, 6, 16, 179, DateTimeKind.Utc).AddTicks(3018) },
                    { 2, new DateTime(2025, 3, 22, 1, 6, 16, 179, DateTimeKind.Utc).AddTicks(3021), "A cozy villa nestled in the mountains, perfect for a relaxing getaway.", "https://media.graphassets.com/kcqbCpucTbmzbM5yqelI", "Mountain Retreat", 6, 300.0, 2500, new DateTime(2025, 3, 22, 1, 6, 16, 179, DateTimeKind.Utc).AddTicks(3022) },
                    { 3, new DateTime(2025, 3, 22, 1, 6, 16, 179, DateTimeKind.Utc).AddTicks(3023), "A modern penthouse villa located in the heart of the city with skyline views.", "https://static.baranselgrup.com/nwm-248899-w1278-bavadi-villalari.png", "Urban Penthouse", 10, 700.0, 4000, new DateTime(2025, 3, 22, 1, 6, 16, 179, DateTimeKind.Utc).AddTicks(3024) }
                });

            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Description", "Name", "VillaId" },
                values: new object[,]
                {
                    { 10, null, "Private Pool", 1 },
                    { 11, null, "Microwave", 2 }
                });

            migrationBuilder.InsertData(
                table: "VillaNumbers",
                columns: new[] { "Villa_Number", "SpecialDetails", "VillaId" },
                values: new object[,]
                {
                    { 101, null, 1 },
                    { 102, null, 1 },
                    { 103, null, 1 },
                    { 201, null, 2 },
                    { 202, null, 2 },
                    { 301, null, 3 },
                    { 302, null, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenities_VillaId",
                table: "Amenities",
                column: "VillaId");

            migrationBuilder.CreateIndex(
                name: "IX_VillaNumbers_VillaId",
                table: "VillaNumbers",
                column: "VillaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "VillaNumbers");

            migrationBuilder.DropTable(
                name: "Villas");
        }
    }
}
