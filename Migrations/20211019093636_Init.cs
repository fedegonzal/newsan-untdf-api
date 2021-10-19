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
                    Longitud = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vivienda", x => x.ViviendaId);
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

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_OperacionId",
                table: "Oferta",
                column: "OperacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ViviendaId",
                table: "Oferta",
                column: "ViviendaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Operacion");

            migrationBuilder.DropTable(
                name: "Vivienda");
        }
    }
}
