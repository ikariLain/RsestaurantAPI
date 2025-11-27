using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RestaurantAPI.Migrations
{
    /// <inheritdoc />
    public partial class updateDBPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$GvvNedRSjv4TLJfDEyyBuelua9YuyckZ.OJOc22dPqkQEuuDR73iC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$6jVUqYX0Ce8xqyRUF4PYc.DbeBpOBl/nscMVrFokKq4HBMbO83k6y");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
