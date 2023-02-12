using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class ManyToManyRelationshipProductUserCart : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_UserCarts_UserCartId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_UserCartId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UserCartId",
                table: "Products");

            migrationBuilder.CreateTable(
                name: "ProductUserCart",
                columns: table => new
                {
                    ProductsId = table.Column<int>(type: "int", nullable: false),
                    UserCartsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUserCart", x => new { x.ProductsId, x.UserCartsId });
                    table.ForeignKey(
                        name: "FK_ProductUserCart_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductUserCart_UserCarts_UserCartsId",
                        column: x => x.UserCartsId,
                        principalTable: "UserCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductUserCart_UserCartsId",
                table: "ProductUserCart",
                column: "UserCartsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductUserCart");

            migrationBuilder.AddColumn<int>(
                name: "UserCartId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_UserCartId",
                table: "Products",
                column: "UserCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_UserCarts_UserCartId",
                table: "Products",
                column: "UserCartId",
                principalTable: "UserCarts",
                principalColumn: "Id");
        }
    }
}
