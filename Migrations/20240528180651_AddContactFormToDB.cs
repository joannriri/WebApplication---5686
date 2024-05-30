using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BurgerQueen_PACUR12400.Migrations
{
    /// <inheritdoc />
    public partial class AddContactFormToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
            //    keyColumn: "Id",
            //    keyValue: "5fed9fdf-bde0-41ec-a934-61178fb9ff19");

           // migrationBuilder.DeleteData(
           //     table: "AspNetRoles",
           //     keyColumn: "Id",
           //     keyValue: "a8c89d47-9f0b-44e2-b712-30231d11ea48");

            migrationBuilder.CreateTable(
                name: "ContactForm",
                columns: table => new
                {
                    ContactID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForm", x => x.ContactID);
                });

          //  migrationBuilder.InsertData(
          //      table: "AspNetRoles",
          //      columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
         //       values: new object[,]
         //       {
           //         { "8b0dd98f-a1b2-410d-97e8-420df241ef5c", null, "admin", "user" },
             //       { "ce4bae99-c0ba-404c-bc1f-73425facbb65", null, "user", null }
               // });
        }

        /// <inheritdoc />
       // protected override void Down(MigrationBuilder migrationBuilder)
        //{
         //   migrationBuilder.DropTable(
          //      name: "ContactForm");

           // migrationBuilder.DeleteData(
            //    table: "AspNetRoles",
             //   keyColumn: "Id",
              //  keyValue: "8b0dd98f-a1b2-410d-97e8-420df241ef5c");

           // migrationBuilder.DeleteData(
           //     table: "AspNetRoles",
               // keyColumn: "Id",
               // keyValue: "ce4bae99-c0ba-404c-bc1f-73425facbb65");

           // migrationBuilder.InsertData(
             //   table: "AspNetRoles",
              //  columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
              //  values: new object[,]
               // {
                 //   { "5fed9fdf-bde0-41ec-a934-61178fb9ff19", null, "admin", "user" },
                   // { "a8c89d47-9f0b-44e2-b712-30231d11ea48", null, "user", null }
               // });
        //}
    }
}
