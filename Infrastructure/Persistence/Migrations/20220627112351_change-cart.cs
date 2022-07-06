using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class changecart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingOrderRows");

            migrationBuilder.DropTable(
                name: "ShoppingOrders");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<int>(
                name: "CartStatus",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CartStatus",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<string>(
                name: "CartId",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClosureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingOrders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ShoppingOrderRows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingOrderRows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingOrderRows_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingOrderRows_ShoppingOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "ShoppingOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderRows_OrderId",
                table: "ShoppingOrderRows",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrderRows_ProductId",
                table: "ShoppingOrderRows",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingOrders_UserId",
                table: "ShoppingOrders",
                column: "UserId");
        }
    }
}
