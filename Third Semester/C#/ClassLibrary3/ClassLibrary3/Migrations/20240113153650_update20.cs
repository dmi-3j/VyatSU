using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update20 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Vaccinations_VaccinationId",
                table: "Records");

            migrationBuilder.AlterColumn<Guid>(
                name: "VaccinationId",
                table: "Records",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "VaccineId",
                table: "Records",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccineId",
                table: "Records",
                column: "VaccineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Vaccinations_VaccinationId",
                table: "Records",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Vaccines_VaccineId",
                table: "Records",
                column: "VaccineId",
                principalTable: "Vaccines",
                principalColumn: "VaccineId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_Vaccinations_VaccinationId",
                table: "Records");

            migrationBuilder.DropForeignKey(
                name: "FK_Records_Vaccines_VaccineId",
                table: "Records");

            migrationBuilder.DropIndex(
                name: "IX_Records_VaccineId",
                table: "Records");

            migrationBuilder.DropColumn(
                name: "VaccineId",
                table: "Records");

            migrationBuilder.AlterColumn<Guid>(
                name: "VaccinationId",
                table: "Records",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_Vaccinations_VaccinationId",
                table: "Records",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
