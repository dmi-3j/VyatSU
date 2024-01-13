using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vaccinecalend.Migrations
{
    /// <inheritdoc />
    public partial class update25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompleteVaccineComponents",
                table: "CompleteVaccineComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompleteVaccineComponents",
                table: "CompleteVaccineComponents",
                column: "CompleteComponentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompleteVaccineComponents",
                table: "CompleteVaccineComponents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompleteVaccineComponents",
                table: "CompleteVaccineComponents",
                columns: new[] { "CompleteComponentId", "ComponentId" });
        }
    }
}
