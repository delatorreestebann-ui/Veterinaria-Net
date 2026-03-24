using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Veterinaria.API.Migrations
{
    /// <inheritdoc />
    public partial class V01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dueños",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_dueño = table.Column<string>(type: "text", nullable: false),
                    Apellido_dueño = table.Column<string>(type: "text", nullable: false),
                    Telefono_dueño = table.Column<string>(type: "text", nullable: false),
                    email_dueño = table.Column<string>(type: "text", nullable: false),
                    contraseña_dueño = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dueños", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_especie = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Hora_Inicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalAdministrativos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Personal = table.Column<string>(type: "text", nullable: false),
                    Apellido_Personal = table.Column<string>(type: "text", nullable: false),
                    Telefono_Personal = table.Column<string>(type: "text", nullable: false),
                    email_Personal = table.Column<string>(type: "text", nullable: false),
                    contraseña_Personal = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalAdministrativos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoCitas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoCitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre_Mascota = table.Column<string>(type: "text", nullable: false),
                    Fecha_Nacimiento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueñoId = table.Column<int>(type: "integer", nullable: false),
                    EspecieId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Dueños_DueñoId",
                        column: x => x.DueñoId,
                        principalTable: "Dueños",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mascotas_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Citas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MascotaId = table.Column<int>(type: "integer", nullable: false),
                    PersonalId = table.Column<int>(type: "integer", nullable: false),
                    PersonalAdministrativoId = table.Column<int>(type: "integer", nullable: true),
                    HorarioId = table.Column<int>(type: "integer", nullable: false),
                    TipoCitaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Citas_Horarios_HorarioId",
                        column: x => x.HorarioId,
                        principalTable: "Horarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_Mascotas_MascotaId",
                        column: x => x.MascotaId,
                        principalTable: "Mascotas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Citas_PersonalAdministrativos_PersonalAdministrativoId",
                        column: x => x.PersonalAdministrativoId,
                        principalTable: "PersonalAdministrativos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Citas_TipoCitas_TipoCitaId",
                        column: x => x.TipoCitaId,
                        principalTable: "TipoCitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Citas_HorarioId",
                table: "Citas",
                column: "HorarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_MascotaId",
                table: "Citas",
                column: "MascotaId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_PersonalAdministrativoId",
                table: "Citas",
                column: "PersonalAdministrativoId");

            migrationBuilder.CreateIndex(
                name: "IX_Citas_TipoCitaId",
                table: "Citas",
                column: "TipoCitaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_DueñoId",
                table: "Mascotas",
                column: "DueñoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_EspecieId",
                table: "Mascotas",
                column: "EspecieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Citas");

            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "PersonalAdministrativos");

            migrationBuilder.DropTable(
                name: "TipoCitas");

            migrationBuilder.DropTable(
                name: "Dueños");

            migrationBuilder.DropTable(
                name: "Especies");
        }
    }
}
