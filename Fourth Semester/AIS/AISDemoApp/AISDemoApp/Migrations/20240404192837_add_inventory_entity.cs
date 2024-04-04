using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class add_inventory_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    InventoryName = table.Column<string>(type: "text", nullable: false),
                    InventoryType = table.Column<string>(type: "text", nullable: false),
                    RentPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    PhotoPath = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventory", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventory");
        }
    }
}
