using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompleteVaccines_ComponentsComplete_CompleteComponentId",
                table: "CompleteVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_CompleteVaccines_Components_VaccineComponentComponentId",
                table: "CompleteVaccines");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_ComponentsComplete_CompleteComponentId",
                table: "Vaccinations");

            migrationBuilder.DropTable(
                name: "ComponentsComplete");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_CompleteComponentId",
                table: "Vaccinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompleteVaccines",
                table: "CompleteVaccines");

            migrationBuilder.RenameTable(
                name: "CompleteVaccines",
                newName: "CompleteVaccineComponents");

            migrationBuilder.RenameIndex(
                name: "IX_CompleteVaccines_VaccineComponentComponentId",
                table: "CompleteVaccineComponents",
                newName: "IX_CompleteVaccineComponents_VaccineComponentComponentId");

            migrationBuilder.AddColumn<Guid>(
                name: "VaccinationId",
                table: "CompleteVaccineComponents",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompleteVaccineComponents",
                table: "CompleteVaccineComponents",
                columns: new[] { "CompleteComponentId", "ComponentId" });

            migrationBuilder.CreateIndex(
                name: "IX_CompleteVaccineComponents_VaccinationId",
                table: "CompleteVaccineComponents",
                column: "VaccinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompleteVaccineComponents_Components_VaccineComponentCompon~",
                table: "CompleteVaccineComponents",
                column: "VaccineComponentComponentId",
                principalTable: "Components",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompleteVaccineComponents_Vaccinations_VaccinationId",
                table: "CompleteVaccineComponents",
                column: "VaccinationId",
                principalTable: "Vaccinations",
                principalColumn: "VaccinationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompleteVaccineComponents_Components_VaccineComponentCompon~",
                table: "CompleteVaccineComponents");

            migrationBuilder.DropForeignKey(
                name: "FK_CompleteVaccineComponents_Vaccinations_VaccinationId",
                table: "CompleteVaccineComponents");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompleteVaccineComponents",
                table: "CompleteVaccineComponents");

            migrationBuilder.DropIndex(
                name: "IX_CompleteVaccineComponents_VaccinationId",
                table: "CompleteVaccineComponents");

            migrationBuilder.DropColumn(
                name: "VaccinationId",
                table: "CompleteVaccineComponents");

            migrationBuilder.RenameTable(
                name: "CompleteVaccineComponents",
                newName: "CompleteVaccines");

            migrationBuilder.RenameIndex(
                name: "IX_CompleteVaccineComponents_VaccineComponentComponentId",
                table: "CompleteVaccines",
                newName: "IX_CompleteVaccines_VaccineComponentComponentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompleteVaccines",
                table: "CompleteVaccines",
                columns: new[] { "CompleteComponentId", "ComponentId" });

            migrationBuilder.CreateTable(
                name: "ComponentsComplete",
                columns: table => new
                {
                    CompleteComponentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentsComplete", x => x.CompleteComponentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_CompleteComponentId",
                table: "Vaccinations",
                column: "CompleteComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompleteVaccines_ComponentsComplete_CompleteComponentId",
                table: "CompleteVaccines",
                column: "CompleteComponentId",
                principalTable: "ComponentsComplete",
                principalColumn: "CompleteComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompleteVaccines_Components_VaccineComponentComponentId",
                table: "CompleteVaccines",
                column: "VaccineComponentComponentId",
                principalTable: "Components",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_ComponentsComplete_CompleteComponentId",
                table: "Vaccinations",
                column: "CompleteComponentId",
                principalTable: "ComponentsComplete",
                principalColumn: "CompleteComponentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
