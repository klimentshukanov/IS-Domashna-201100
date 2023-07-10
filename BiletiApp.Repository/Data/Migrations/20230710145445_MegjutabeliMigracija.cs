using Microsoft.EntityFrameworkCore.Migrations;

namespace BiletiApp.Web.Data.Migrations
{
    public partial class MegjutabeliMigracija : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletOrder_Bileti_BiletId",
                table: "BiletOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletOrder_Orders_OrderId",
                table: "BiletOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletShoppingCart_Bileti_BiletId",
                table: "BiletShoppingCart");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletShoppingCart_ShoppingCarts_ShoppingCartId",
                table: "BiletShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BiletShoppingCart",
                table: "BiletShoppingCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BiletOrder",
                table: "BiletOrder");

            migrationBuilder.RenameTable(
                name: "BiletShoppingCart",
                newName: "BiletiShoppingCarts");

            migrationBuilder.RenameTable(
                name: "BiletOrder",
                newName: "BiletiOrders");

            migrationBuilder.RenameIndex(
                name: "IX_BiletShoppingCart_ShoppingCartId",
                table: "BiletiShoppingCarts",
                newName: "IX_BiletiShoppingCarts_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_BiletShoppingCart_BiletId",
                table: "BiletiShoppingCarts",
                newName: "IX_BiletiShoppingCarts_BiletId");

            migrationBuilder.RenameIndex(
                name: "IX_BiletOrder_OrderId",
                table: "BiletiOrders",
                newName: "IX_BiletiOrders_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BiletOrder_BiletId",
                table: "BiletiOrders",
                newName: "IX_BiletiOrders_BiletId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BiletiShoppingCarts",
                table: "BiletiShoppingCarts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BiletiOrders",
                table: "BiletiOrders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletiOrders_Bileti_BiletId",
                table: "BiletiOrders",
                column: "BiletId",
                principalTable: "Bileti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletiOrders_Orders_OrderId",
                table: "BiletiOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletiShoppingCarts_Bileti_BiletId",
                table: "BiletiShoppingCarts",
                column: "BiletId",
                principalTable: "Bileti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletiShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "BiletiShoppingCarts",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BiletiOrders_Bileti_BiletId",
                table: "BiletiOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletiOrders_Orders_OrderId",
                table: "BiletiOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletiShoppingCarts_Bileti_BiletId",
                table: "BiletiShoppingCarts");

            migrationBuilder.DropForeignKey(
                name: "FK_BiletiShoppingCarts_ShoppingCarts_ShoppingCartId",
                table: "BiletiShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BiletiShoppingCarts",
                table: "BiletiShoppingCarts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BiletiOrders",
                table: "BiletiOrders");

            migrationBuilder.RenameTable(
                name: "BiletiShoppingCarts",
                newName: "BiletShoppingCart");

            migrationBuilder.RenameTable(
                name: "BiletiOrders",
                newName: "BiletOrder");

            migrationBuilder.RenameIndex(
                name: "IX_BiletiShoppingCarts_ShoppingCartId",
                table: "BiletShoppingCart",
                newName: "IX_BiletShoppingCart_ShoppingCartId");

            migrationBuilder.RenameIndex(
                name: "IX_BiletiShoppingCarts_BiletId",
                table: "BiletShoppingCart",
                newName: "IX_BiletShoppingCart_BiletId");

            migrationBuilder.RenameIndex(
                name: "IX_BiletiOrders_OrderId",
                table: "BiletOrder",
                newName: "IX_BiletOrder_OrderId");

            migrationBuilder.RenameIndex(
                name: "IX_BiletiOrders_BiletId",
                table: "BiletOrder",
                newName: "IX_BiletOrder_BiletId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BiletShoppingCart",
                table: "BiletShoppingCart",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BiletOrder",
                table: "BiletOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BiletOrder_Bileti_BiletId",
                table: "BiletOrder",
                column: "BiletId",
                principalTable: "Bileti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletOrder_Orders_OrderId",
                table: "BiletOrder",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletShoppingCart_Bileti_BiletId",
                table: "BiletShoppingCart",
                column: "BiletId",
                principalTable: "Bileti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BiletShoppingCart_ShoppingCarts_ShoppingCartId",
                table: "BiletShoppingCart",
                column: "ShoppingCartId",
                principalTable: "ShoppingCarts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
