using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Foods_FoodId_FK",
                table: "ServiceOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrder_Reservations_Reservation_FK",
                table: "ServiceOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrder",
                table: "ServiceOrder");

            migrationBuilder.DropIndex(
                name: "IX_ServiceOrder_FoodId_FK",
                table: "ServiceOrder");

            migrationBuilder.DropColumn(
                name: "FoodId_FK",
                table: "ServiceOrder");

            migrationBuilder.RenameTable(
                name: "ServiceOrder",
                newName: "ServiceOrders");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrder_Reservation_FK",
                table: "ServiceOrders",
                newName: "IX_ServiceOrders_Reservation_FK");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrders",
                table: "ServiceOrders",
                column: "ServiceOrderId");

            migrationBuilder.CreateTable(
                name: "ServiceOrderFood",
                columns: table => new
                {
                    ServiceOrderId = table.Column<int>(type: "int", nullable: false),
                    FoodId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceOrderFood", x => new { x.ServiceOrderId, x.FoodId });
                    table.ForeignKey(
                        name: "FK_ServiceOrderFood_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "FoodId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceOrderFood_ServiceOrders_ServiceOrderId",
                        column: x => x.ServiceOrderId,
                        principalTable: "ServiceOrders",
                        principalColumn: "ServiceOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://upload.wikimedia.org/wikipedia/commons/c/c8/Pizza_Margherita_stu_spivack.jpg");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://assets.epicurious.com/photos/5c745a108918ee7ab68daf79/master/pass/Smashburger-recipe-120219.jpg");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                column: "ImageUrl",
                value: "https://assets.icanet.se/e_sharpen:80,q_auto,dpr_1.25,w_718,h_718,c_lfill/sbl46xzizeoysgb64buz.jpg");

            migrationBuilder.InsertData(
                table: "ServiceOrderFood",
                columns: new[] { "FoodId", "ServiceOrderId", "Id", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 0, 89m, 1 },
                    { 2, 1, 0, 89m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrderFood_FoodId",
                table: "ServiceOrderFood",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrders_Reservations_Reservation_FK",
                table: "ServiceOrders",
                column: "Reservation_FK",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceOrders_Reservations_Reservation_FK",
                table: "ServiceOrders");

            migrationBuilder.DropTable(
                name: "ServiceOrderFood");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ServiceOrders",
                table: "ServiceOrders");

            migrationBuilder.RenameTable(
                name: "ServiceOrders",
                newName: "ServiceOrder");

            migrationBuilder.RenameIndex(
                name: "IX_ServiceOrders_Reservation_FK",
                table: "ServiceOrder",
                newName: "IX_ServiceOrder_Reservation_FK");

            migrationBuilder.AddColumn<int>(
                name: "FoodId_FK",
                table: "ServiceOrder",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ServiceOrder",
                table: "ServiceOrder",
                column: "ServiceOrderId");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 1,
                column: "ImageUrl",
                value: "pizza.jpg");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 2,
                column: "ImageUrl",
                value: "burger.jpg");

            migrationBuilder.UpdateData(
                table: "Foods",
                keyColumn: "FoodId",
                keyValue: 3,
                column: "ImageUrl",
                value: "salad.jpg");

            migrationBuilder.UpdateData(
                table: "ServiceOrder",
                keyColumn: "ServiceOrderId",
                keyValue: 1,
                column: "FoodId_FK",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceOrder_FoodId_FK",
                table: "ServiceOrder",
                column: "FoodId_FK");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Foods_FoodId_FK",
                table: "ServiceOrder",
                column: "FoodId_FK",
                principalTable: "Foods",
                principalColumn: "FoodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceOrder_Reservations_Reservation_FK",
                table: "ServiceOrder",
                column: "Reservation_FK",
                principalTable: "Reservations",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
