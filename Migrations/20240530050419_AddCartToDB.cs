using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerQueen_PACUR12400.Migrations
{
    /// <inheritdoc />
    public partial class AddCartToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           // migrationBuilder.DeleteData(
             //   table: "AspNetRoles",
               // keyColumn: "Id",
                //keyValue: "8b0dd98f-a1b2-410d-97e8-420df241ef5c");

//            migrationBuilder.DeleteData(
  //              table: "AspNetRoles",
    //            keyColumn: "Id",
      //          keyValue: "ce4bae99-c0ba-404c-bc1f-73425facbb65");

            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItem_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

        //    migrationBuilder.InsertData(
          //      table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
              //  values: new object[,]
               // {
                 //   { "6ac1df97-20e4-47c0-b567-bbfe68cc7d3a", null, "admin", "user" },
                   // { "d8042430-750d-468e-86fd-4f20cebcf782", null, "user", null }
                //});

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_ProductID",
                table: "CartItem",
                column: "ProductID");
        }

        /// <inheritdoc />
     //   protected override void Down(MigrationBuilder migrationBuilder)
        //{
       //     migrationBuilder.DropTable(
         //       name: "CartItem");

           // migrationBuilder.DeleteData(
             //   table: "AspNetRoles",
               // keyColumn: "Id",
                //keyValue: "6ac1df97-20e4-47c0-b567-bbfe68cc7d3a");
//
  //          migrationBuilder.DeleteData(
    //            table: "AspNetRoles",
      //          keyColumn: "Id",
        //        keyValue: "d8042430-750d-468e-86fd-4f20cebcf782");

          //  migrationBuilder.InsertData(
              //  table: "AspNetRoles",
            //    columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                //values: new object[,]
                //{
                  //  { "8b0dd98f-a1b2-410d-97e8-420df241ef5c", null, "admin", "user" },
                    //{ "ce4bae99-c0ba-404c-bc1f-73425facbb65", null, "user", null }
               // });/
        //}
    }
}
