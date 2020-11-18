using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProyectoFinal.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Clave = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    Id_Recurso = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Id_Recurso);
                    table.ForeignKey(
                        name: "FK_Recurso_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Id_Detalle = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<string>(type: "TEXT", nullable: true),
                    RecursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Id_Detalle);
                    table.ForeignKey(
                        name: "FK_Detalle_Recurso_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recurso",
                        principalColumn: "Id_Recurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    Id_Tarea = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Vencimiento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Estimacion = table.Column<int>(type: "INTEGER", nullable: false),
                    RecursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Estado = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.Id_Tarea);
                    table.ForeignKey(
                        name: "FK_Tarea_Recurso_RecursoId",
                        column: x => x.RecursoId,
                        principalTable: "Recurso",
                        principalColumn: "Id_Recurso",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_RecursoId",
                table: "Detalle",
                column: "RecursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_UsuarioId",
                table: "Recurso",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_RecursoId",
                table: "Tarea",
                column: "RecursoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Tarea");

            migrationBuilder.DropTable(
                name: "Recurso");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
