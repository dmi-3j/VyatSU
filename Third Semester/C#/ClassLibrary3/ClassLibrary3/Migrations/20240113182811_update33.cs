using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update33 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_MedicalOrganizations_MedicalOrganizationOrganizatio~",
                table: "Records");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalOrganizationOrganizationId",
                table: "Records",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Records_MedicalOrganizations_MedicalOrganizationOrganizatio~",
                table: "Records",
                column: "MedicalOrganizationOrganizationId",
                principalTable: "MedicalOrganizations",
                principalColumn: "OrganizationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Records_MedicalOrganizations_MedicalOrganizationOrganizatio~",
                table: "Records");

            migrationBuilder.AlterColumn<Guid>(
                name: "MedicalOrganizationOrganizationId",
                table: "Records",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Records_MedicalOrganizations_MedicalOrganizationOrganizatio~",
                table: "Records",
                column: "MedicalOrganizationOrganizationId",
                principalTable: "MedicalOrganizations",
                principalColumn: "OrganizationId");
        }
    }
}
