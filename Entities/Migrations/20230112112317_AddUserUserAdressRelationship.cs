using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class AddUserUserAdressRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAdressId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserAdressId",
                table: "Users",
                column: "UserAdressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserAdresses_UserAdressId",
                table: "Users",
                column: "UserAdressId",
                principalTable: "UserAdresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserAdresses_UserAdressId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_UserAdressId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UserAdressId",
                table: "Users");
        }
    }
}
