using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProScape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedFirstNameAndLastNameToBookingsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Bookings",
                newName: "LastName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckOutDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CheckInDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 13, 16, 4, 58, 362, DateTimeKind.Utc).AddTicks(1601), new DateTime(2025, 4, 13, 16, 4, 58, 362, DateTimeKind.Utc).AddTicks(1606) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 13, 16, 4, 58, 362, DateTimeKind.Utc).AddTicks(1609), new DateTime(2025, 4, 13, 16, 4, 58, 362, DateTimeKind.Utc).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 13, 16, 4, 58, 362, DateTimeKind.Utc).AddTicks(1611), new DateTime(2025, 4, 13, 16, 4, 58, 362, DateTimeKind.Utc).AddTicks(1612) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Bookings",
                newName: "Name");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CheckOutDate",
                table: "Bookings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "CheckInDate",
                table: "Bookings",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

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
    }
}
