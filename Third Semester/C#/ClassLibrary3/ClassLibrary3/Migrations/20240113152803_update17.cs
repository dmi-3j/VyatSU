using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Diseases_DiseaseId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_vaccinationDiary_Diseases_DiseaseId",
                table: "vaccinationDiary");

            migrationBuilder.DropTable(
                name: "VaccinationDiseases");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropIndex(
                name: "IX_vaccinationDiary_DiseaseId",
                table: "vaccinationDiary");

            migrationBuilder.DropIndex(
                name: "IX_Records_DiseaseId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "DiseaseId",
                table: "vaccinationDiary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiseaseId",
                table: "vaccinationDiary",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Diseases",
                columns: table => new
                {
                    DiseaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    IndicationsToVaccination = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseases", x => x.DiseaseId);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDiseases",
                columns: table => new
                {
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDiseases", x => new { x.VaccinationId, x.DiseaseId });
                    table.ForeignKey(
                        name: "FK_VaccinationDiseases_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationDiseases_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_DiseaseId",
                table: "vaccinationDiary",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_DiseaseId",
                table: "Records",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDiseases_DiseaseId",
                table: "VaccinationDiseases",
                column: "DiseaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Diseases_DiseaseId",
                table: "Records",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "DiseaseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinationDiary_Diseases_DiseaseId",
                table: "vaccinationDiary",
                column: "DiseaseId",
                principalTable: "Diseases",
                principalColumn: "DiseaseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
