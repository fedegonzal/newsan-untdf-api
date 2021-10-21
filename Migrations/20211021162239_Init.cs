using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace Inmobiliaria.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Operacion",
                columns: table => new
                {
                    OperacionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Tolerancia = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operacion", x => x.OperacionId);
                });

            migrationBuilder.CreateTable(
                name: "Propietario",
                columns: table => new
                {
                    PropietarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    Apellido = table.Column<string>(type: "text", nullable: true),
                    DNI = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Propietario", x => x.PropietarioId);
                });

            migrationBuilder.CreateTable(
                name: "TipoVivienda",
                columns: table => new
                {
                    TipoViviendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoVivienda", x => x.TipoViviendaId);
                });

            migrationBuilder.CreateTable(
                name: "Vivienda",
                columns: table => new
                {
                    ViviendaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DescripcionCorta = table.Column<string>(type: "text", nullable: true),
                    DomicilioCalle = table.Column<string>(type: "text", nullable: true),
                    DomicilioNumero = table.Column<string>(type: "text", nullable: true),
                    DescripcionLarga = table.Column<string>(type: "text", nullable: true),
                    GasNatural = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Latitud = table.Column<float>(type: "float", nullable: false),
                    Longitud = table.Column<float>(type: "float", nullable: false),
                    TipoViviendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vivienda", x => x.ViviendaId);
                    table.ForeignKey(
                        name: "FK_Vivienda_TipoVivienda_TipoViviendaId",
                        column: x => x.TipoViviendaId,
                        principalTable: "TipoVivienda",
                        principalColumn: "TipoViviendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    OfertaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Precio = table.Column<float>(type: "float", nullable: false),
                    ViviendaId = table.Column<int>(type: "int", nullable: false),
                    OperacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.OfertaId);
                    table.ForeignKey(
                        name: "FK_Oferta_Operacion_OperacionId",
                        column: x => x.OperacionId,
                        principalTable: "Operacion",
                        principalColumn: "OperacionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oferta_Vivienda_ViviendaId",
                        column: x => x.ViviendaId,
                        principalTable: "Vivienda",
                        principalColumn: "ViviendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropietarioVivienda",
                columns: table => new
                {
                    PropietariosPropietarioId = table.Column<int>(type: "int", nullable: false),
                    ViviendasViviendaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropietarioVivienda", x => new { x.PropietariosPropietarioId, x.ViviendasViviendaId });
                    table.ForeignKey(
                        name: "FK_PropietarioVivienda_Propietario_PropietariosPropietarioId",
                        column: x => x.PropietariosPropietarioId,
                        principalTable: "Propietario",
                        principalColumn: "PropietarioId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropietarioVivienda_Vivienda_ViviendasViviendaId",
                        column: x => x.ViviendasViviendaId,
                        principalTable: "Vivienda",
                        principalColumn: "ViviendaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_OperacionId",
                table: "Oferta",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ViviendaId",
                table: "Oferta",
                column: "ViviendaId");

            migrationBuilder.CreateIndex(
                name: "IX_PropietarioVivienda_ViviendasViviendaId",
                table: "PropietarioVivienda",
                column: "ViviendasViviendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vivienda_TipoViviendaId",
                table: "Vivienda",
                column: "TipoViviendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "PropietarioVivienda");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Propietario");

            migrationBuilder.DropTable(
                name: "Vivienda");

            migrationBuilder.DropTable(
                name: "TipoVivienda");
        }
    }
}
