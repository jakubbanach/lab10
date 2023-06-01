using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace skoki.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Skocznia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nazwa = table.Column<string>(type: "TEXT", nullable: false),
                    Kraj = table.Column<string>(type: "TEXT", nullable: false),
                    Miejscowosc = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skocznia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wynik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Miejsce = table.Column<int>(type: "INTEGER", nullable: false),
                    Seria1 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Seria2 = table.Column<decimal>(type: "TEXT", nullable: false),
                    Nota = table.Column<decimal>(type: "TEXT", nullable: false),
                    PunktySezonowe = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wynik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zawodnik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Imie = table.Column<string>(type: "TEXT", nullable: false),
                    Nazwisko = table.Column<string>(type: "TEXT", nullable: false),
                    Kraj = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zawodnik", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Konkurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkoczniaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Rodzaj = table.Column<string>(type: "TEXT", nullable: false),
                    Pora = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konkurs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Konkurs_Skocznia_SkoczniaId",
                        column: x => x.SkoczniaId,
                        principalTable: "Skocznia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Konkurs_SkoczniaId",
                table: "Konkurs",
                column: "SkoczniaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Konkurs");

            migrationBuilder.DropTable(
                name: "Wynik");

            migrationBuilder.DropTable(
                name: "Zawodnik");

            migrationBuilder.DropTable(
                name: "Skocznia");
        }
    }
}
