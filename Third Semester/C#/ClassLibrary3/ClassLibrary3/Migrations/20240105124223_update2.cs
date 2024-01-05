using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vaccinationDiary_Vaccinations_VaccinationId",
                table: "vaccinationDiary");

            migrationBuilder.DropIndex(
                name: "IX_vaccinationDiary_VaccinationId",
                table: "vaccinationDiary");

            migrationBuilder.CreateTable(
                name: "VaccinationVaccinationDiary",
                columns: table => new
                {
                    VaccinationsDiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationsVaccinationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationVaccinationDiary", x => new { x.VaccinationsDiaryId, x.VaccinationsVaccinationId });
                    table.ForeignKey(
                        name: "FK_VaccinationVaccinationDiary_Vaccinations_VaccinationsVaccin~",
                        column: x => x.VaccinationsVaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationVaccinationDiary_vaccinationDiary_VaccinationsDi~",
                        column: x => x.VaccinationsDiaryId,
                        principalTable: "vaccinationDiary",
                        principalColumn: "DiaryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationVaccinationDiary_VaccinationsVaccinationId",
                table: "VaccinationVaccinationDiary",
                column: "VaccinationsVaccinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VaccinationVaccinationDiary");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_VaccinationId",
                table: "vaccinationDiary",
                column: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinationDiary_Vaccinations_VaccinationId",
                table: "vaccinationDiary",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
