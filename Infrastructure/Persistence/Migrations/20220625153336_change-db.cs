using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Persistence.Migrations
{
    public partial class changedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRow_AspNetUsers_UserId",
                table: "OrderRow");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRow_Order_OrderId",
                table: "OrderRow");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderRow_Products_ProductId",
                table: "OrderRow");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_CartId",
                table: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_CartId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderRow",
                table: "OrderRow");

            migrationBuilder.DropIndex(
                name: "IX_OrderRow_UserId",
                table: "OrderRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OrderRow");

            migrationBuilder.RenameTable(
                name: "OrderRow",
                newName: "ShoppingOrderRows");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "ShoppingOrders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRow_ProductId",
                table: "ShoppingOrderRows",
                newName: "IX_ShoppingOrderRows_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRow_OrderId",
                table: "ShoppingOrderRows",
                newName: "IX_ShoppingOrderRows_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_Order_UserId",
                table: "ShoppingOrders",
                newName: "IX_ShoppingOrders_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "CartId",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCartItems",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingOrderRows",
                table: "ShoppingOrderRows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingOrders",
                table: "ShoppingOrders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderRows_Products_ProductId",
                table: "ShoppingOrderRows",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrderRows_ShoppingOrders_OrderId",
                table: "ShoppingOrderRows",
                column: "OrderId",
                principalTable: "ShoppingOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingOrders_AspNetUsers_UserId",
                table: "ShoppingOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCartItems_AspNetUsers_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderRows_Products_ProductId",
                table: "ShoppingOrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrderRows_ShoppingOrders_OrderId",
                table: "ShoppingOrderRows");

            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingOrders_AspNetUsers_UserId",
                table: "ShoppingOrders");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCartItems_UserId",
                table: "ShoppingCartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingOrders",
                table: "ShoppingOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingOrderRows",
                table: "ShoppingOrderRows");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCartItems");

            migrationBuilder.RenameTable(
                name: "ShoppingOrders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "ShoppingOrderRows",
                newName: "OrderRow");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrders_UserId",
                table: "Order",
                newName: "IX_Order_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrderRows_ProductId",
                table: "OrderRow",
                newName: "IX_OrderRow_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_ShoppingOrderRows_OrderId",
                table: "OrderRow",
                newName: "IX_OrderRow_OrderId");

            migrationBuilder.AlterColumn<int>(
                name: "CartId",
                table: "ShoppingCartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OrderRow",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderRow",
                table: "OrderRow",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCarts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_CartId",
                table: "ShoppingCartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRow_UserId",
                table: "OrderRow",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCarts_UserId",
                table: "ShoppingCarts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_AspNetUsers_UserId",
                table: "Order",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRow_AspNetUsers_UserId",
                table: "OrderRow",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRow_Order_OrderId",
                table: "OrderRow",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRow_Products_ProductId",
                table: "OrderRow",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCartItems_ShoppingCarts_CartId",
                table: "ShoppingCartItems",
                column: "CartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
