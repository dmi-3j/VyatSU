using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update16 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                table: "Vaccines");

            migrationBuilder.DropIndex(
                name: "IX_Vaccines_CompleteComponentId",
                table: "Vaccines");

            migrationBuilder.DropColumn(
                name: "CompleteComponentId",
                table: "Vaccines");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompleteComponentId",
                table: "Vaccines",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_CompleteComponentId",
                table: "Vaccines",
                column: "CompleteComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                table: "Vaccines",
                column: "CompleteComponentId",
                principalTable: "ComponentsComplete",
                principalColumn: "CompleteComponentId");
        }
    }
}
