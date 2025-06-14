using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bc.Migrations
{
    /// <inheritdoc />
    public partial class BazuniaKawiarni : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorie",
                columns: table => new
                {
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorie", x => x.IdKategorii);
                });

            migrationBuilder.CreateTable(
                name: "Skladniki",
                columns: table => new
                {
                    IdSkladnika = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaSkladnika = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skladniki", x => x.IdSkladnika);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienia",
                columns: table => new
                {
                    IdZamowienia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KwotaZamowienia = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    StatusZamowienia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienia", x => x.IdZamowienia);
                });

            migrationBuilder.CreateTable(
                name: "Produkty",
                columns: table => new
                {
                    IdProduktu = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaProduktu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKategorii = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.IdProduktu);
                    table.ForeignKey(
                        name: "FK_Produkty_Kategorie_IdKategorii",
                        column: x => x.IdKategorii,
                        principalTable: "Kategorie",
                        principalColumn: "IdKategorii",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProduktyZamowienia",
                columns: table => new
                {
                    PzId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProduktId = table.Column<int>(type: "int", nullable: false),
                    ZamowienieId = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduktyZamowienia", x => x.PzId);
                    table.ForeignKey(
                        name: "FK_ProduktyZamowienia_Produkty_ProduktId",
                        column: x => x.ProduktId,
                        principalTable: "Produkty",
                        principalColumn: "IdProduktu",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduktyZamowienia_Zamowienia_ZamowienieId",
                        column: x => x.ZamowienieId,
                        principalTable: "Zamowienia",
                        principalColumn: "IdZamowienia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Kategorie",
                columns: new[] { "IdKategorii", "Name" },
                values: new object[,]
                {
                    { 1, "Kawa" },
                    { 2, "Herbata" },
                    { 3, "Desery" }
                });

            migrationBuilder.InsertData(
                table: "Skladniki",
                columns: new[] { "IdSkladnika", "NazwaSkladnika" },
                values: new object[,]
                {
                    { 1, "Mleko" },
                    { 2, "Cukier" },
                    { 3, "Cytryna" }
                });

            migrationBuilder.InsertData(
                table: "Zamowienia",
                columns: new[] { "IdZamowienia", "DataZamowienia", "KwotaZamowienia", "StatusZamowienia" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 15, 10, 30, 0, 0, DateTimeKind.Unspecified), 15.99m, 0 },
                    { 2, new DateTime(2023, 1, 16, 11, 0, 0, 0, DateTimeKind.Unspecified), 25.50m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Produkty",
                columns: new[] { "IdProduktu", "IdKategorii", "NazwaProduktu" },
                values: new object[,]
                {
                    { 1, 1, "Espresso" },
                    { 2, 1, "Cappuccino" },
                    { 3, 2, "Zielona herbata" }
                });

            migrationBuilder.InsertData(
                table: "ProduktyZamowienia",
                columns: new[] { "PzId", "Ilosc", "ProduktId", "ZamowienieId" },
                values: new object[,]
                {
                    { 1, 2, 1, 1 },
                    { 2, 1, 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdKategorii",
                table: "Produkty",
                column: "IdKategorii");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktyZamowienia_ProduktId",
                table: "ProduktyZamowienia",
                column: "ProduktId");

            migrationBuilder.CreateIndex(
                name: "IX_ProduktyZamowienia_ZamowienieId",
                table: "ProduktyZamowienia",
                column: "ZamowienieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProduktyZamowienia");

            migrationBuilder.DropTable(
                name: "Skladniki");

            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
