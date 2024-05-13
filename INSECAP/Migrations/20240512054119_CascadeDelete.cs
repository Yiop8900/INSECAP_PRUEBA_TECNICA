using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace INSECAP.Migrations
{
    /// <inheritdoc />
    public partial class CascadeDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    RUN_Alumno = table.Column<int>(type: "int", nullable: false),
                    DV_Alumno = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Fecha_Nacimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    Genero = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.RUN_Alumno);
                });

            migrationBuilder.CreateTable(
                name: "Bimestre",
                columns: table => new
                {
                    ID_Bimestre = table.Column<int>(type: "int", nullable: false),
                    Anio = table.Column<int>(type: "int", nullable: false),
                    Numero_Bimestre = table.Column<int>(type: "int", nullable: false),
                    Fecha_Inicio = table.Column<DateOnly>(type: "date", nullable: false),
                    Fecha_Fin = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bimestre", x => x.ID_Bimestre);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Codigo_Curso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Nombre_Curso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Codigo_Curso);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    RUN_Profesor = table.Column<int>(type: "int", nullable: false),
                    DV_Profesor = table.Column<string>(type: "char(10)", unicode: false, fixedLength: true, maxLength: 10, nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.RUN_Profesor);
                });

            migrationBuilder.CreateTable(
                name: "Sala",
                columns: table => new
                {
                    Codigo_Sala = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Capacidad_Maxima = table.Column<int>(type: "int", nullable: false),
                    Caracteristicas_Especiales = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sala", x => x.Codigo_Sala);
                });

            migrationBuilder.CreateTable(
                name: "Notas",
                columns: table => new
                {
                    ID_Nota = table.Column<int>(type: "int", nullable: false),
                    RUN_Alumno = table.Column<int>(type: "int", nullable: false),
                    Codigo_Curso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    ID_Bimestre = table.Column<int>(type: "int", nullable: false),
                    Nota = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notas", x => x.ID_Nota);
                    table.ForeignKey(
                        name: "FK_Notas_Alumno",
                        column: x => x.RUN_Alumno,
                        principalTable: "Alumno",
                        principalColumn: "RUN_Alumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notas_Bimestre",
                        column: x => x.ID_Bimestre,
                        principalTable: "Bimestre",
                        principalColumn: "ID_Bimestre");
                    table.ForeignKey(
                        name: "FK_Notas_Curso",
                        column: x => x.Codigo_Curso,
                        principalTable: "Curso",
                        principalColumn: "Codigo_Curso");
                });

            migrationBuilder.CreateTable(
                name: "Asignacion_Cursos_Pro",
                columns: table => new
                {
                    ID_Asignacion = table.Column<int>(type: "int", nullable: false),
                    Codigo_Curso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RUN_Profesor = table.Column<int>(type: "int", nullable: false),
                    ID_Bimestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacion_Cursos_Pro", x => x.ID_Asignacion);
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Pro_Bimestre",
                        column: x => x.ID_Bimestre,
                        principalTable: "Bimestre",
                        principalColumn: "ID_Bimestre");
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Pro_Curso",
                        column: x => x.Codigo_Curso,
                        principalTable: "Curso",
                        principalColumn: "Codigo_Curso");
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Pro_Profesor",
                        column: x => x.RUN_Profesor,
                        principalTable: "Profesor",
                        principalColumn: "RUN_Profesor");
                });

            migrationBuilder.CreateTable(
                name: "Asignacion_Cursos_Alu",
                columns: table => new
                {
                    ID_Asignacion = table.Column<int>(type: "int", nullable: false),
                    Codigo_Curso = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Codigo_Sala = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    RUN_Alumno = table.Column<int>(type: "int", nullable: false),
                    ID_Bimestre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Asignacion_Cursos_Alu", x => x.ID_Asignacion);
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Alu_Alumno",
                        column: x => x.RUN_Alumno,
                        principalTable: "Alumno",
                        principalColumn: "RUN_Alumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Alu_Bimestre",
                        column: x => x.ID_Bimestre,
                        principalTable: "Bimestre",
                        principalColumn: "ID_Bimestre");
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Alu_Curso",
                        column: x => x.Codigo_Curso,
                        principalTable: "Curso",
                        principalColumn: "Codigo_Curso");
                    table.ForeignKey(
                        name: "FK_Asignacion_Cursos_Alu_Sala",
                        column: x => x.Codigo_Sala,
                        principalTable: "Sala",
                        principalColumn: "Codigo_Sala");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Cursos_Alu_Codigo_Curso",
                table: "Asignacion_Cursos_Alu",
                column: "Codigo_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Cursos_Alu_Codigo_Sala",
                table: "Asignacion_Cursos_Alu",
                column: "Codigo_Sala");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Cursos_Alu_ID_Bimestre",
                table: "Asignacion_Cursos_Alu",
                column: "ID_Bimestre");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Cursos_Alu_RUN_Alumno",
                table: "Asignacion_Cursos_Alu",
                column: "RUN_Alumno");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Cursos_Pro_ID_Bimestre",
                table: "Asignacion_Cursos_Pro",
                column: "ID_Bimestre");

            migrationBuilder.CreateIndex(
                name: "IX_Asignacion_Cursos_Pro_RUN_Profesor",
                table: "Asignacion_Cursos_Pro",
                column: "RUN_Profesor");

            migrationBuilder.CreateIndex(
                name: "UQ_Asignacion_Cursos_Pro_Bimestre",
                table: "Asignacion_Cursos_Pro",
                columns: new[] { "Codigo_Curso", "RUN_Profesor", "ID_Bimestre" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notas_Codigo_Curso",
                table: "Notas",
                column: "Codigo_Curso");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_ID_Bimestre",
                table: "Notas",
                column: "ID_Bimestre");

            migrationBuilder.CreateIndex(
                name: "IX_Notas_RUN_Alumno",
                table: "Notas",
                column: "RUN_Alumno");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Asignacion_Cursos_Alu");

            migrationBuilder.DropTable(
                name: "Asignacion_Cursos_Pro");

            migrationBuilder.DropTable(
                name: "Notas");

            migrationBuilder.DropTable(
                name: "Sala");

            migrationBuilder.DropTable(
                name: "Profesor");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "Bimestre");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
