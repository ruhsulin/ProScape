using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProScape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPropertiestoUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 20, 57, 44, 649, DateTimeKind.Utc).AddTicks(9927), new DateTime(2025, 3, 23, 20, 57, 44, 649, DateTimeKind.Utc).AddTicks(9932) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 20, 57, 44, 649, DateTimeKind.Utc).AddTicks(9934), new DateTime(2025, 3, 23, 20, 57, 44, 649, DateTimeKind.Utc).AddTicks(9935) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 20, 57, 44, 649, DateTimeKind.Utc).AddTicks(9936), new DateTime(2025, 3, 23, 20, 57, 44, 649, DateTimeKind.Utc).AddTicks(9937) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 20, 49, 31, 53, DateTimeKind.Utc).AddTicks(5414), new DateTime(2025, 3, 23, 20, 49, 31, 53, DateTimeKind.Utc).AddTicks(5418) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 20, 49, 31, 53, DateTimeKind.Utc).AddTicks(5421), new DateTime(2025, 3, 23, 20, 49, 31, 53, DateTimeKind.Utc).AddTicks(5421) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 3, 23, 20, 49, 31, 53, DateTimeKind.Utc).AddTicks(5423), new DateTime(2025, 3, 23, 20, 49, 31, 53, DateTimeKind.Utc).AddTicks(5423) });
        }
    }
}
