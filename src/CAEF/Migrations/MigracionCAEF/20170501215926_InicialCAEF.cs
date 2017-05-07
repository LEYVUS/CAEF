using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CAEF.Migrations.MigracionCAEF
{
    public partial class InicialCAEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alumno",
                columns: table => new
                {
                    Matricula_Alumno = table.Column<int>(nullable: false),
                    ApellidoM = table.Column<string>(nullable: false),
                    ApellidoP = table.Column<string>(nullable: false),
                    Grupo = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    Promedio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alumno", x => x.Matricula_Alumno);
                });

            migrationBuilder.CreateTable(
                name: "Carrera",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrera", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Clave_Materia = table.Column<int>(nullable: false),
                    Carrera = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Clave_Materia);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubtipoExamen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubtipoExamen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoExamen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoExamen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Numero_Empleado = table.Column<int>(nullable: false),
                    ApellidoM = table.Column<string>(nullable: true),
                    ApellidoP = table.Column<string>(nullable: true),
                    Correo = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    RolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Numero_Empleado);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_RolId",
                        column: x => x.RolId,
                        principalTable: "Rol",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudDocente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EmpleadoId = table.Column<int>(nullable: true),
                    FechaCreacion = table.Column<DateTime>(nullable: false),
                    IdCarrera = table.Column<int>(nullable: false),
                    IdEmpleado = table.Column<int>(nullable: false),
                    IdEstado = table.Column<int>(nullable: false),
                    IdMateria = table.Column<int>(nullable: false),
                    IdTipoExamen = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(nullable: false),
                    Periodo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudDocente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudDocente_Usuarios_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Usuario",
                        principalColumn: "Numero_Empleado",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitudDocente_Carrera_IdCarrera",
                        column: x => x.IdCarrera,
                        principalTable: "Carrera",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudDocente_Estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudDocente_Materia_IdMateria",
                        column: x => x.IdMateria,
                        principalTable: "Materia",
                        principalColumn: "Clave_Materia",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudDocente_TipoExamen_IdTipoExamen",
                        column: x => x.IdTipoExamen,
                        principalTable: "TipoExamen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudAdministrativo",
                columns: table => new
                {
                    IdSolicitud = table.Column<int>(nullable: false),
                    CalificacionLetra = table.Column<string>(nullable: false),
                    CicloEscolar = table.Column<string>(nullable: false),
                    ClaveUnidad = table.Column<string>(nullable: false),
                    Comentario = table.Column<string>(nullable: false),
                    EtapaSemestre = table.Column<string>(nullable: false),
                    FechaAceptacion = table.Column<DateTime>(nullable: false),
                    IdSubtipoExamen = table.Column<int>(nullable: false),
                    NumeroAlumnos = table.Column<int>(nullable: false),
                    PlanEstudios = table.Column<string>(nullable: false),
                    SubTipoExamenId = table.Column<int>(nullable: true),
                    URLDocumento = table.Column<string>(nullable: false),
                    UnidadAcademica = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudAdministrativo", x => x.IdSolicitud);
                    table.ForeignKey(
                        name: "FK_SolicitudAdministrativo_SolicitudDocente_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "SolicitudDocente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudAdministrativo_SubtipoExamen_SubTipoExamenId",
                        column: x => x.SubTipoExamenId,
                        principalTable: "SubtipoExamen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudAlumno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAlumno = table.Column<int>(nullable: false),
                    IdSolicitud = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudAlumno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudAlumno_Alumno_IdAlumno",
                        column: x => x.IdAlumno,
                        principalTable: "Alumno",
                        principalColumn: "Matricula_Alumno",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudAlumno_SolicitudDocente_IdSolicitud",
                        column: x => x.IdSolicitud,
                        principalTable: "SolicitudDocente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudAdministrativo_SubTipoExamenId",
                table: "SolicitudAdministrativo",
                column: "SubTipoExamenId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudAlumno_IdAlumno",
                table: "SolicitudAlumno",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudAlumno_IdSolicitud",
                table: "SolicitudAlumno",
                column: "IdSolicitud");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDocente_EmpleadoId",
                table: "SolicitudDocente",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDocente_IdCarrera",
                table: "SolicitudDocente",
                column: "IdCarrera");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDocente_IdEstado",
                table: "SolicitudDocente",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDocente_IdMateria",
                table: "SolicitudDocente",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudDocente_IdTipoExamen",
                table: "SolicitudDocente",
                column: "IdTipoExamen");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_RolId",
                table: "Usuario",
                column: "RolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitudAdministrativo");

            migrationBuilder.DropTable(
                name: "SolicitudAlumno");

            migrationBuilder.DropTable(
                name: "SubtipoExamen");

            migrationBuilder.DropTable(
                name: "Alumno");

            migrationBuilder.DropTable(
                name: "SolicitudDocente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Carrera");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.DropTable(
                name: "TipoExamen");

            migrationBuilder.DropTable(
                name: "Rol");
        }
    }
}
