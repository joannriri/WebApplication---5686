using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerQueen_PACUR12400.Migrations
{
    /// <inheritdoc />
    public partial class AddCheckoutToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          //  migrationBuilder.DeleteData(
          //      table: "AspNetRoles",
           //     keyColumn: "Id",
            //    keyValue: "6ac1df97-20e4-47c0-b567-bbfe68cc7d3a");

//            migrationBuilder.DeleteData(
  //              table: "AspNetRoles",
    //            keyColumn: "Id",
      //          keyValue: "d8042430-750d-468e-86fd-4f20cebcf782");

            migrationBuilder.CreateTable(
                name: "UserCheckout",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCheckout", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CheckoutItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    CheckoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckoutItem_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckoutItem_UserCheckout_CheckoutId",
                        column: x => x.CheckoutId,
                        principalTable: "UserCheckout",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

      //      migrationBuilder.InsertData(
        //        table: "AspNetRoles",
          //      columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
            //    values: new object[,]
              //  {
                //    { "11ab7a50-819c-47c2-b13e-d0998ec59997", null, "user", null },
                  //  { "88b6a26b-22e4-4f6e-9eb4-01b11a01a387", null, "admin", "user" }
                //});

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutItem_CheckoutId",
                table: "CheckoutItem",
                column: "CheckoutId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutItem_ProductID",
                table: "CheckoutItem",
                column: "ProductID");
        }

        /// <inheritdoc />
      //  protected override void Down(MigrationBuilder migrationBuilder)
     //   {
       //     migrationBuilder.DropTable(
        //        name: "CheckoutItem");

         //   migrationBuilder.DropTable(
           //     name: "UserCheckout");

//            migrationBuilder.DeleteData(
  //              table: "AspNetRoles",
    //            keyColumn: "Id",
      //          keyValue: "11ab7a50-819c-47c2-b13e-d0998ec59997");

        //    migrationBuilder.DeleteData(
          //      table: "AspNetRoles",
            //    keyColumn: "Id",
              //  keyValue: "88b6a26b-22e4-4f6e-9eb4-01b11a01a387");

            //migrationBuilder.InsertData(
              //  table: "AspNetRoles",
                //columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                //values: new object[,]
                //{
                  //  { "6ac1df97-20e4-47c0-b567-bbfe68cc7d3a", null, "admin", "user" },
                    //{ "d8042430-750d-468e-86fd-4f20cebcf782", null, "user", null }
        //        });
        //}
    }
}
