using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProScape.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddStripeColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckInDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualCheckOutDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentSuccessful",
                table: "Bookings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PaymentDate",
                table: "Bookings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "StripePaymentIntentId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StripeSessionId",
                table: "Bookings",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VillaNumber",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 8, 51, 424, DateTimeKind.Utc).AddTicks(6386), new DateTime(2025, 4, 22, 17, 8, 51, 424, DateTimeKind.Utc).AddTicks(6389) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 8, 51, 424, DateTimeKind.Utc).AddTicks(6391), new DateTime(2025, 4, 22, 17, 8, 51, 424, DateTimeKind.Utc).AddTicks(6391) });

            migrationBuilder.UpdateData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 4, 22, 17, 8, 51, 424, DateTimeKind.Utc).AddTicks(6393), new DateTime(2025, 4, 22, 17, 8, 51, 424, DateTimeKind.Utc).AddTicks(6393) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ActualCheckInDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ActualCheckOutDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "IsPaymentSuccessful",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "PaymentDate",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StripePaymentIntentId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "StripeSessionId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "VillaNumber",
                table: "Bookings");

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
    }
}
