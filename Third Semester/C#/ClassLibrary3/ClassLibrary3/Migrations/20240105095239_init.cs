using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "MedicalOrganizations",
                columns: table => new
                {
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalOrganizations", x => x.OrganizationId);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinated",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Discriminator = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinated", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vaccinated_Vaccinated_UserId",
                        column: x => x.UserId,
                        principalTable: "Vaccinated",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccines",
                columns: table => new
                {
                    VaccineId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineName = table.Column<string>(type: "text", nullable: false),
                    ManufactorCountry = table.Column<string>(type: "text", nullable: false),
                    ValidPeriod = table.Column<string>(type: "text", nullable: false),
                    CompleteComponentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineId);
                    table.ForeignKey(
                        name: "FK_Vaccines_ComponentsComplete_CompleteComponentId",
                        column: x => x.CompleteComponentId,
                        principalTable: "ComponentsComplete",
                        principalColumn: "CompleteComponentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Structure = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    IntervalOfComponent = table.Column<string>(type: "text", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                    table.ForeignKey(
                        name: "FK_Components_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaccinations",
                columns: table => new
                {
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    Serial = table.Column<string>(type: "text", nullable: false),
                    FlagIsDone = table.Column<bool>(type: "boolean", nullable: false),
                    TimeInterval = table.Column<string>(type: "text", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalOrganizationOrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uuid", nullable: false),
                    CompleteComponentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.VaccinationId);
                    table.ForeignKey(
                        name: "FK_Vaccinations_ComponentsComplete_CompleteComponentId",
                        column: x => x.CompleteComponentId,
                        principalTable: "ComponentsComplete",
                        principalColumn: "CompleteComponentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_MedicalOrganizations_MedicalOrganizationOrgani~",
                        column: x => x.MedicalOrganizationOrganizationId,
                        principalTable: "MedicalOrganizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vaccinations_Vaccines_VaccineId",
                        column: x => x.VaccineId,
                        principalTable: "Vaccines",
                        principalColumn: "VaccineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompleteVaccines",
                columns: table => new
                {
                    CompleteComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineComponentComponentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteVaccines", x => new { x.CompleteComponentId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_CompleteVaccines_ComponentsComplete_CompleteComponentId",
                        column: x => x.CompleteComponentId,
                        principalTable: "ComponentsComplete",
                        principalColumn: "CompleteComponentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompleteVaccines_Components_VaccineComponentComponentId",
                        column: x => x.VaccineComponentComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    ReactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescriptionOfReaction = table.Column<string>(type: "text", nullable: false),
                    DateOfReaction = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactions", x => x.ReactionId);
                    table.ForeignKey(
                        name: "FK_Reactions_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinatedId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalOrganizationOrganizationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_MedicalOrganizations_MedicalOrganizationOrganizatio~",
                        column: x => x.MedicalOrganizationOrganizationId,
                        principalTable: "MedicalOrganizations",
                        principalColumn: "OrganizationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Vaccinated_VaccinatedId",
                        column: x => x.VaccinatedId,
                        principalTable: "Vaccinated",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vaccinationDiary",
                columns: table => new
                {
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinatedId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    DiseaseId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vaccinationDiary", x => x.DiaryId);
                    table.ForeignKey(
                        name: "FK_vaccinationDiary_Diseases_DiseaseId",
                        column: x => x.DiseaseId,
                        principalTable: "Diseases",
                        principalColumn: "DiseaseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vaccinationDiary_Vaccinated_VaccinatedId",
                        column: x => x.VaccinatedId,
                        principalTable: "Vaccinated",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_vaccinationDiary_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CompleteVaccines_VaccineComponentComponentId",
                table: "CompleteVaccines",
                column: "VaccineComponentComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_VaccineId",
                table: "Components",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Reactions_VaccinationId",
                table: "Reactions",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_DiseaseId",
                table: "Records",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_MedicalOrganizationOrganizationId",
                table: "Records",
                column: "MedicalOrganizationOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccinatedId",
                table: "Records",
                column: "VaccinatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccinationId",
                table: "Records",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinated_UserId",
                table: "Vaccinated",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_DiseaseId",
                table: "vaccinationDiary",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_VaccinatedId",
                table: "vaccinationDiary",
                column: "VaccinatedId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_vaccinationDiary_VaccinationId",
                table: "vaccinationDiary",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDiseases_DiseaseId",
                table: "VaccinationDiseases",
                column: "DiseaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_CompleteComponentId",
                table: "Vaccinations",
                column: "CompleteComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_MedicalOrganizationOrganizationId",
                table: "Vaccinations",
                column: "MedicalOrganizationOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccines_CompleteComponentId",
                table: "Vaccines",
                column: "CompleteComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompleteVaccines");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "vaccinationDiary");

            migrationBuilder.DropTable(
                name: "VaccinationDiseases");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Vaccinated");

            migrationBuilder.DropTable(
                name: "Diseases");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "MedicalOrganizations");

            migrationBuilder.DropTable(
                name: "Vaccines");

            migrationBuilder.DropTable(
                name: "ComponentsComplete");
        }
    }
}
