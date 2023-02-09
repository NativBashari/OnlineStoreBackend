using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class setForeignKeyUserAdressUserWithModelRef : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_UserAdresses_UserId",
                table: "UserAdresses",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAdresses_Users_UserId",
                table: "UserAdresses",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAdresses_Users_UserId",
                table: "UserAdresses");

            migrationBuilder.DropIndex(
                name: "IX_UserAdresses_UserId",
                table: "UserAdresses");
        }
    }
}
