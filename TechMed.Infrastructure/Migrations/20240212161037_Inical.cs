using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechMed.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Inical : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exames_Medicos_MedicoId",
                table: "Exames");

            migrationBuilder.DropIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames");

            migrationBuilder.DropColumn(
                name: "MedicoId",
                table: "Exames");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MedicoId",
                table: "Exames",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exames_MedicoId",
                table: "Exames",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Exames_Medicos_MedicoId",
                table: "Exames",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "MedicoId");
        }
    }
}
