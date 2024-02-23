using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backendForms.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Encuestas",
                columns: table => new
                {
                    IdEncuesta = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Encuestas", x => x.IdEncuesta);
                });

            migrationBuilder.CreateTable(
                name: "Campos",
                columns: table => new
                {
                    IdCampo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Requerido = table.Column<bool>(type: "bit", nullable: false),
                    TipoCampo = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IdEncuesta = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campos", x => x.IdCampo);
                    table.ForeignKey(
                        name: "FK_Campos_Encuestas_IdEncuesta",
                        column: x => x.IdEncuesta,
                        principalTable: "Encuestas",
                        principalColumn: "IdEncuesta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    IdRespuesta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IdCampo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.IdRespuesta);
                    table.ForeignKey(
                        name: "FK_Respuestas_Campos_IdCampo",
                        column: x => x.IdCampo,
                        principalTable: "Campos",
                        principalColumn: "IdCampo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campos_IdEncuesta",
                table: "Campos",
                column: "IdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_IdCampo",
                table: "Respuestas",
                column: "IdCampo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Campos");

            migrationBuilder.DropTable(
                name: "Encuestas");
        }
    }
}
