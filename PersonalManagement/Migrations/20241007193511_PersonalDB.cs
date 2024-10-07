using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PersonalManagement.Migrations
{
    /// <inheritdoc />
    public partial class PersonalDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    CodigoCargo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionCargo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.CodigoCargo);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    NumeroDocumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaIngreso = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CodigoCargo = table.Column<int>(type: "int", nullable: false),
                    CargoCodigoCargo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.NumeroDocumento);
                    table.ForeignKey(
                        name: "FK_Personal_Cargos_CargoCodigoCargo",
                        column: x => x.CargoCodigoCargo,
                        principalTable: "Cargos",
                        principalColumn: "CodigoCargo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personal_CargoCodigoCargo",
                table: "Personal",
                column: "CargoCodigoCargo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "Cargos");
        }
    }
}
