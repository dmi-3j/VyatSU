using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update27 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_vaccinationDiary_Vaccinated_VaccinatedId",
                table: "vaccinationDiary");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationVaccinationDiary_vaccinationDiary_VaccinationsDi~",
                table: "VaccinationVaccinationDiary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_vaccinationDiary",
                table: "vaccinationDiary");

            migrationBuilder.RenameTable(
                name: "vaccinationDiary",
                newName: "VaccinationDiary");

            migrationBuilder.RenameIndex(
                name: "IX_vaccinationDiary_VaccinatedId",
                table: "VaccinationDiary",
                newName: "IX_VaccinationDiary_VaccinatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VaccinationDiary",
                table: "VaccinationDiary",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationDiary_Vaccinated_VaccinatedId",
                table: "VaccinationDiary",
                column: "VaccinatedId",
                principalTable: "Vaccinated",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationVaccinationDiary_VaccinationDiary_VaccinationsDi~",
                table: "VaccinationVaccinationDiary",
                column: "VaccinationsDiaryId",
                principalTable: "VaccinationDiary",
                principalColumn: "DiaryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationDiary_Vaccinated_VaccinatedId",
                table: "VaccinationDiary");

            migrationBuilder.DropForeignKey(
                name: "FK_VaccinationVaccinationDiary_VaccinationDiary_VaccinationsDi~",
                table: "VaccinationVaccinationDiary");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VaccinationDiary",
                table: "VaccinationDiary");

            migrationBuilder.RenameTable(
                name: "VaccinationDiary",
                newName: "vaccinationDiary");

            migrationBuilder.RenameIndex(
                name: "IX_VaccinationDiary_VaccinatedId",
                table: "vaccinationDiary",
                newName: "IX_vaccinationDiary_VaccinatedId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_vaccinationDiary",
                table: "vaccinationDiary",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_vaccinationDiary_Vaccinated_VaccinatedId",
                table: "vaccinationDiary",
                column: "VaccinatedId",
                principalTable: "Vaccinated",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VaccinationVaccinationDiary_vaccinationDiary_VaccinationsDi~",
                table: "VaccinationVaccinationDiary",
                column: "VaccinationsDiaryId",
                principalTable: "vaccinationDiary",
                principalColumn: "DiaryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
