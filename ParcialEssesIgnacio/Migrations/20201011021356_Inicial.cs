using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParcialEssesIgnacio.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id_User = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    User = table.Column<string>(maxLength: 20, nullable: false),
                    Clave = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Recurso",
                columns: table => new
                {
                    Id_Recurso = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: true),
                    UsuarioId_User = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recurso", x => x.Id_Recurso);
                    table.ForeignKey(
                        name: "FK_Recurso_Usuario_UsuarioId_User",
                        column: x => x.UsuarioId_User,
                        principalTable: "Usuario",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarea",
                columns: table => new
                {
                    Id_Tarea = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(nullable: true),
                    Vencimiento = table.Column<DateTime>(nullable: false),
                    Estimacion = table.Column<int>(nullable: false),
                    ResponsableId_Recurso = table.Column<int>(nullable: true),
                    Estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarea", x => x.Id_Tarea);
                    table.ForeignKey(
                        name: "FK_Tarea_Recurso_ResponsableId_Recurso",
                        column: x => x.ResponsableId_Recurso,
                        principalTable: "Recurso",
                        principalColumn: "Id_Recurso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    Id_Detalle = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<string>(nullable: true),
                    Tiempo = table.Column<string>(nullable: true),
                    RecursoId_Recurso = table.Column<int>(nullable: true),
                    TareaId_Tarea = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.Id_Detalle);
                    table.ForeignKey(
                        name: "FK_Detalle_Recurso_RecursoId_Recurso",
                        column: x => x.RecursoId_Recurso,
                        principalTable: "Recurso",
                        principalColumn: "Id_Recurso",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_Tarea_TareaId_Tarea",
                        column: x => x.TareaId_Tarea,
                        principalTable: "Tarea",
                        principalColumn: "Id_Tarea",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_RecursoId_Recurso",
                table: "Detalle",
                column: "RecursoId_Recurso");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_TareaId_Tarea",
                table: "Detalle",
                column: "TareaId_Tarea");

            migrationBuilder.CreateIndex(
                name: "IX_Recurso_UsuarioId_User",
                table: "Recurso",
                column: "UsuarioId_User");

            migrationBuilder.CreateIndex(
                name: "IX_Tarea_ResponsableId_Recurso",
                table: "Tarea",
                column: "ResponsableId_Recurso");
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
