using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Molecule.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bouquets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bouquets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Flours",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flours", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BouquetFlour",
                columns: table => new
                {
                    BouquetsId = table.Column<Guid>(type: "uuid", nullable: false),
                    FloursId = table.Column<Guid>(type: "uuid", nullable: false),
                    BouquetId = table.Column<int>(type: "integer", nullable: false),
                    FlourId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BouquetFlour", x => new { x.BouquetsId, x.FloursId });
                    table.ForeignKey(
                        name: "FK_BouquetFlour_Bouquets_BouquetsId",
                        column: x => x.BouquetsId,
                        principalTable: "Bouquets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BouquetFlour_Flours_FloursId",
                        column: x => x.FloursId,
                        principalTable: "Flours",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BouquetFlour_FloursId",
                table: "BouquetFlour",
                column: "FloursId");

            migrationBuilder.CreateIndex(
                name: "IX_Bouquets_Id",
                table: "Bouquets",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flours_Id",
                table: "Flours",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BouquetFlour");

            migrationBuilder.DropTable(
                name: "Bouquets");

            migrationBuilder.DropTable(
                name: "Flours");
        }
    }
}
