using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vaccinationDiary_VaccinatedId",
                table: "vaccinationDiary");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Vaccinated");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_VaccinatedId",
                table: "vaccinationDiary",
                column: "VaccinatedId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_vaccinationDiary_VaccinatedId",
                table: "vaccinationDiary");

            migrationBuilder.AddColumn<Guid>(
                name: "DiaryId",
                table: "Vaccinated",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_VaccinatedId",
                table: "vaccinationDiary",
                column: "VaccinatedId",
                unique: true);
        }
    }
}
