using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bc.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
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
                    IdKategorii = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produkty", x => x.IdProduktu);
                    table.ForeignKey(
                        name: "FK_Produkty_Kategorie_IdKategorii",
                        column: x => x.IdKategorii,
                        principalTable: "Kategorie",
                        principalColumn: "IdKategorii");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produkty_IdKategorii",
                table: "Produkty",
                column: "IdKategorii");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produkty");

            migrationBuilder.DropTable(
                name: "Skladniki");

            migrationBuilder.DropTable(
                name: "Zamowienia");

            migrationBuilder.DropTable(
                name: "Kategorie");
        }
    }
}
