using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedtouserEmail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "ShoppingCarts");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShoppingCarts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
