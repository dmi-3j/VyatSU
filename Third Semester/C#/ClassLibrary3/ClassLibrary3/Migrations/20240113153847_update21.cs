using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Vaccinations_VaccinationId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_VaccinationId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "VaccinationId",
                table: "Records");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VaccinationId",
                table: "Records",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccinationId",
                table: "Records",
                column: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Vaccinations_VaccinationId",
                table: "Records",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId");
        }
    }
}
