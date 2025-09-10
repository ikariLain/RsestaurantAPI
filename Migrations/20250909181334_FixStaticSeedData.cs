using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class FixStaticSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookingDate", "StartTime" },
                values: new object[] { new DateOnly(2025, 9, 15), new DateTime(2025, 9, 15, 19, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1,
                columns: new[] { "BookingDate", "StartTime" },
                values: new object[] { new DateOnly(2025, 9, 10), new DateTime(2025, 9, 11, 15, 11, 53, 36, DateTimeKind.Local).AddTicks(5287) });
        }
    }
}
