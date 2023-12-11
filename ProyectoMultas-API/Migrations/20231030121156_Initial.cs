using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoMultas_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayudantes",
                columns: table => new
                {
                    IdBanner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Carrera = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayudantes", x => x.IdBanner);
                });

            migrationBuilder.CreateTable(
                name: "Profesores",
                columns: table => new
                {
                    IdBanner = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesores", x => x.IdBanner);
                });

            migrationBuilder.CreateTable(
                name: "Multas",
                columns: table => new
                {
                    MultaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Monto = table.Column<double>(type: "float", nullable: false),
                    Razon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AyudanteId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multas", x => x.MultaId);
                    table.ForeignKey(
                        name: "FK_Multas_Ayudantes_AyudanteId",
                        column: x => x.AyudanteId,
                        principalTable: "Ayudantes",
                        principalColumn: "IdBanner",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Multas_AyudanteId",
                table: "Multas",
                column: "AyudanteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multas");

            migrationBuilder.DropTable(
                name: "Profesores");

            migrationBuilder.DropTable(
                name: "Ayudantes");
        }
    }
}
