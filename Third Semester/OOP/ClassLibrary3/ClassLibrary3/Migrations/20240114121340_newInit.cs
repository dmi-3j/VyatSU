using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class newInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: false),
                    InshuranceNumber = table.Column<long>(type: "bigint", nullable: false),
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
                    ValidPeriod = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccines", x => x.VaccineId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Vaccinated_UserId",
                        column: x => x.UserId,
                        principalTable: "Vaccinated",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VaccinationDiary",
                columns: table => new
                {
                    DiaryId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinatedId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VaccinationDiary", x => x.DiaryId);
                    table.ForeignKey(
                        name: "FK_VaccinationDiary_Vaccinated_VaccinatedId",
                        column: x => x.VaccinatedId,
                        principalTable: "Vaccinated",
                        principalColumn: "Id",
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
                name: "Records",
                columns: table => new
                {
                    RecordId = table.Column<Guid>(type: "uuid", nullable: false),
                    RecordDate = table.Column<DateTime>(type: "date", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinatedId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    MedicalOrganizationOrganizationId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.RecordId);
                    table.ForeignKey(
                        name: "FK_Records_MedicalOrganizations_MedicalOrganizationOrganizatio~",
                        column: x => x.MedicalOrganizationOrganizationId,
                        principalTable: "MedicalOrganizations",
                        principalColumn: "OrganizationId");
                    table.ForeignKey(
                        name: "FK_Records_Vaccinated_VaccinatedId",
                        column: x => x.VaccinatedId,
                        principalTable: "Vaccinated",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_Vaccines_VaccineId",
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
                    MedicalOrganizationOrganizationId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaccinations", x => x.VaccinationId);
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
                name: "CompleteVaccineComponents",
                columns: table => new
                {
                    CompleteComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccineComponentComponentId = table.Column<Guid>(type: "uuid", nullable: false),
                    VaccinationDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompleteVaccineComponents", x => x.CompleteComponentId);
                    table.ForeignKey(
                        name: "FK_CompleteVaccineComponents_Components_VaccineComponentCompon~",
                        column: x => x.VaccineComponentComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompleteVaccineComponents_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reactions",
                columns: table => new
                {
                    ReactionId = table.Column<Guid>(type: "uuid", nullable: false),
                    DescriptionOfReaction = table.Column<string>(type: "text", nullable: false),
                    DateOfReaction = table.Column<DateTime>(type: "date", nullable: false),
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
                        name: "FK_VaccinationVaccinationDiary_VaccinationDiary_VaccinationsDi~",
                        column: x => x.VaccinationsDiaryId,
                        principalTable: "VaccinationDiary",
                        principalColumn: "DiaryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VaccinationVaccinationDiary_Vaccinations_VaccinationsVaccin~",
                        column: x => x.VaccinationsVaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "VaccinationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompleteVaccineComponents_VaccinationId",
                table: "CompleteVaccineComponents",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_CompleteVaccineComponents_VaccineComponentComponentId",
                table: "CompleteVaccineComponents",
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
                name: "IX_Records_MedicalOrganizationOrganizationId",
                table: "Records",
                column: "MedicalOrganizationOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccinatedId",
                table: "Records",
                column: "VaccinatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccineId",
                table: "Records",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinated_InshuranceNumber",
                table: "Vaccinated",
                column: "InshuranceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinated_UserId",
                table: "Vaccinated",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinated_Username",
                table: "Vaccinated",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationDiary_VaccinatedId",
                table: "VaccinationDiary",
                column: "VaccinatedId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_MedicalOrganizationOrganizationId",
                table: "Vaccinations",
                column: "MedicalOrganizationOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_VaccineId",
                table: "Vaccinations",
                column: "VaccineId");

            migrationBuilder.CreateIndex(
                name: "IX_VaccinationVaccinationDiary_VaccinationsVaccinationId",
                table: "VaccinationVaccinationDiary",
                column: "VaccinationsVaccinationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompleteVaccineComponents");

            migrationBuilder.DropTable(
                name: "Reactions");

            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "VaccinationVaccinationDiary");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "VaccinationDiary");

            migrationBuilder.DropTable(
                name: "Vaccinations");

            migrationBuilder.DropTable(
                name: "Vaccinated");

            migrationBuilder.DropTable(
                name: "MedicalOrganizations");

            migrationBuilder.DropTable(
                name: "Vaccines");
        }
    }
}
