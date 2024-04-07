using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class update6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Services",
                table: "Cart");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Services",
                table: "Cart",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
