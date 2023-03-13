using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ConcentraVHM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Cedula = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TipoPersona = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Cedula);
                });

            migrationBuilder.CreateTable(
                name: "TiposAutoMovil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAutoMovil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesPlacas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Total = table.Column<int>(type: "int", nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesPlacas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenesPlacas_Clientes_ClienteCedula",
                        column: x => x.ClienteCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula");
                });

            migrationBuilder.CreateTable(
                name: "Placas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    TipoAutoMovilId = table.Column<int>(type: "int", nullable: false),
                    ClienteCedula = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Placas_Clientes_ClienteCedula",
                        column: x => x.ClienteCedula,
                        principalTable: "Clientes",
                        principalColumn: "Cedula");
                    table.ForeignKey(
                        name: "FK_Placas_TiposAutoMovil_TipoAutoMovilId",
                        column: x => x.TipoAutoMovilId,
                        principalTable: "TiposAutoMovil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposAutoMovil",
                columns: new[] { "Id", "Descripcion", "Tipo", "Valor" },
                values: new object[,]
                {
                    { 1, "Publico", "A", 100 },
                    { 2, "Privado", "F", 200 },
                    { 3, "Transporte", "T", 300 },
                    { 4, "Pesado", "P", 400 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesPlacas_ClienteCedula",
                table: "OrdenesPlacas",
                column: "ClienteCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Placas_ClienteCedula",
                table: "Placas",
                column: "ClienteCedula");

            migrationBuilder.CreateIndex(
                name: "IX_Placas_TipoAutoMovilId",
                table: "Placas",
                column: "TipoAutoMovilId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesPlacas");

            migrationBuilder.DropTable(
                name: "Placas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TiposAutoMovil");
        }
    }
}
