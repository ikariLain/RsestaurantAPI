using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class hashPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$12$asWCam7g0AylGer9M2m0muTShueKbWq8mKWFq5LYId3w.vIDGTsr6/8DcJkBRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$12$WxJI1zUGVNaqfDBmsf/CU.GLRIvJB5eUabYS/gVA2Qg0G3dZNETge");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2y$10$ovacz2yv6ygxqoDxoNuOmeKtWdDdfNTDm1guCwF8WeSG/8DcJkBRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2y$10$ytRQ6/wotHQMIOLXV4CkbuvygCCxJOGy9hl2vUWKkRJgI80LSI4cC");
        }
    }
}
