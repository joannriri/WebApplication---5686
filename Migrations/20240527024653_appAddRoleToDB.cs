using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerQueen_PACUR12400.Migrations
{
    /// <inheritdoc />
    public partial class appAddRoleToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "aae3dc9f-f6aa-429a-a3aa-faf4464abe11", null, "user", null },
                    { "f3659909-0f46-4088-a9ee-416f4d145536", null, "admin", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aae3dc9f-f6aa-429a-a3aa-faf4464abe11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f3659909-0f46-4088-a9ee-416f4d145536");
        }
    }
}
