using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoSzerelo.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kliensek",
                columns: table => new
                {
                    KliensId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KliensNev = table.Column<string>(type: "TEXT", nullable: false),
                    Lakcim = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kliensek", x => x.KliensId);
                });

            migrationBuilder.CreateTable(
                name: "Munkak",
                columns: table => new
                {
                    MunkaId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KliensId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Rendszam = table.Column<string>(type: "TEXT", nullable: false),
                    GyartasiEv = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Leiras = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    HibaSulyossaga = table.Column<int>(type: "INTEGER", nullable: false),
                    Allapot = table.Column<int>(type: "INTEGER", nullable: false),
                    MKategoria = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Munkak", x => x.MunkaId);
                    table.ForeignKey(
                        name: "FK_Munkak_Kliens_KliensId",
                        column: x => x.KliensId,
                        principalTable: "Kliensek",
                        principalColumn: "KliensId",
                        onDelete: ReferentialAction.Cascade);
                });
            migrationBuilder.CreateIndex(
                name: "IX_Munkaka_KlientId",
                table: "Munkak",
                column: "KliensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kliensek");

            migrationBuilder.DropTable(
                name: "Munkak");
        }
    }
}
