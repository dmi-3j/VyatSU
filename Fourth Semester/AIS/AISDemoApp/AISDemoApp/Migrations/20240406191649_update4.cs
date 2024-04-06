using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AISDemoApp.Migrations
{
    /// <inheritdoc />
    public partial class update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Cart_CartId",
                table: "Inventory");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "Inventory",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Cart_CartId",
                table: "Inventory",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Cart_CartId",
                table: "Inventory");

            migrationBuilder.AlterColumn<Guid>(
                name: "CartId",
                table: "Inventory",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Cart_CartId",
                table: "Inventory",
                column: "CartId",
                principalTable: "Cart",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
