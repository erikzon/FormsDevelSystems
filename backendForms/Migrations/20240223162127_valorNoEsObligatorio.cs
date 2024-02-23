using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendForms.Migrations
{
    /// <inheritdoc />
    public partial class valorNoEsObligatorio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Campos_Encuestas_EncuestaIdEncuesta",
                table: "Campos");

            migrationBuilder.DropIndex(
                name: "IX_Campos_EncuestaIdEncuesta",
                table: "Campos");

            migrationBuilder.DropColumn(
                name: "EncuestaIdEncuesta",
                table: "Campos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EncuestaIdEncuesta",
                table: "Campos",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Campos_EncuestaIdEncuesta",
                table: "Campos",
                column: "EncuestaIdEncuesta");

            migrationBuilder.AddForeignKey(
                name: "FK_Campos_Encuestas_EncuestaIdEncuesta",
                table: "Campos",
                column: "EncuestaIdEncuesta",
                principalTable: "Encuestas",
                principalColumn: "IdEncuesta");
        }
    }
}
