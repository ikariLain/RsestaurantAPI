using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "Alice Johnson", "0701234567" },
                    { 2, "bob@example.com", "Bob Smith", "0709876543" }
                });

            migrationBuilder.InsertData(
                table: "Foods",
                columns: new[] { "FoodId", "Description", "ImageUrl", "IsAvailable", "IsPopular", "IsVegetarian", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Classic cheese pizza", "pizza.jpg", true, true, true, "Margherita Pizza", 89.0 },
                    { 2, "Beef burger with cheese", "burger.jpg", true, true, false, "Cheeseburger", 120.0 },
                    { 3, "Fresh salad with chicken and dressing", "salad.jpg", true, false, false, "Caesar Salad", 75.0 }
                });

            migrationBuilder.InsertData(
                table: "Tables",
                columns: new[] { "TableId", "IsAvailable", "ReservationId", "SeatAmount" },
                values: new object[,]
                {
                    { 1, true, null, 2 },
                    { 2, true, null, 4 },
                    { 3, false, null, 6 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Email", "FirstName", "LastName", "PasswordHash", "Role" },
                values: new object[,]
                {
                    { 1, "admin@restaurant.com", "Admin", "User", "hashedpassword123", "Admin" },
                    { 2, "john@example.com", "John", "Doe", "hashedpassword456", "Customer" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "AmountOfGuests", "AmountOfTables", "BookingDate", "Customer_FK", "Duration", "StartTime", "status" },
                values: new object[] { 1, 2, 1, new DateOnly(2025, 9, 10), 1, new TimeSpan(0, 2, 0, 0, 0), new DateTime(2025, 9, 11, 15, 11, 53, 36, DateTimeKind.Local).AddTicks(5287), "Confirmed" });

            migrationBuilder.InsertData(
                table: "ServiceOrder",
                columns: new[] { "ServiceOrderId", "FoodId_FK", "Note", "Quantity", "Reservation_FK", "TotalPriceAmount" },
                values: new object[] { 1, 1, "Extra cheese", 2, 1, 178m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ServiceOrder",
                keyColumn: "ServiceOrderId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tables",
                keyColumn: "TableId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1);
        }
    }
}
