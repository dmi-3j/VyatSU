using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                table: "Vaccines");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompleteComponentId",
                table: "Vaccines",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                table: "Vaccines",
                column: "CompleteComponentId",
                principalTable: "ComponentsComplete",
                principalColumn: "CompleteComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                table: "Vaccines");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompleteComponentId",
                table: "Vaccines",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                table: "Vaccines",
                column: "CompleteComponentId",
                principalTable: "ComponentsComplete",
                principalColumn: "CompleteComponentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
