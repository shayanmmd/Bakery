using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bakery.Persistence.Migrations
{
    public partial class Add_Prop_Role : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_FkCustomer",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_Customers_FkCustomer",
                table: "Suggestions");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignedInDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Guid);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_FkCustomer",
                table: "Orders",
                column: "FkCustomer",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_Users_FkCustomer",
                table: "Suggestions",
                column: "FkCustomer",
                principalTable: "Users",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_FkCustomer",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Suggestions_Users_FkCustomer",
                table: "Suggestions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SignedInDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Guid);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_FkCustomer",
                table: "Orders",
                column: "FkCustomer",
                principalTable: "Customers",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suggestions_Customers_FkCustomer",
                table: "Suggestions",
                column: "FkCustomer",
                principalTable: "Customers",
                principalColumn: "Guid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
