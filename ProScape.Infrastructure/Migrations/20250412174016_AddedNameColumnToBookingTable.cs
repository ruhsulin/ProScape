using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProScape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNameColumnToBookingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 40, 16, 192, DateTimeKind.Utc).AddTicks(3599), new DateTime(2025, 4, 12, 17, 40, 16, 192, DateTimeKind.Utc).AddTicks(3603) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 40, 16, 192, DateTimeKind.Utc).AddTicks(3606), new DateTime(2025, 4, 12, 17, 40, 16, 192, DateTimeKind.Utc).AddTicks(3607) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 12, 17, 40, 16, 192, DateTimeKind.Utc).AddTicks(3608), new DateTime(2025, 4, 12, 17, 40, 16, 192, DateTimeKind.Utc).AddTicks(3609) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bookings");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 12, 13, 21, 33, 802, DateTimeKind.Utc).AddTicks(5754), new DateTime(2025, 4, 12, 13, 21, 33, 802, DateTimeKind.Utc).AddTicks(5760) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 12, 13, 21, 33, 802, DateTimeKind.Utc).AddTicks(5764), new DateTime(2025, 4, 12, 13, 21, 33, 802, DateTimeKind.Utc).AddTicks(5765) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 12, 13, 21, 33, 802, DateTimeKind.Utc).AddTicks(5769), new DateTime(2025, 4, 12, 13, 21, 33, 802, DateTimeKind.Utc).AddTicks(5769) });
        }
    }
}
