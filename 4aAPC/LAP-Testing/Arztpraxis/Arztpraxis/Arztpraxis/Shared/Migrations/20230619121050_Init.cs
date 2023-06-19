using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arztpraxis.Shared.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Diagnosen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patienten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    svnr = table.Column<int>(type: "int", nullable: false),
                    GebDatum = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patienten", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Termine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uhrzeit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bemerkung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    DiagnoseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Termine_Diagnosen_DiagnoseId",
                        column: x => x.DiagnoseId,
                        principalTable: "Diagnosen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Termine_Patienten_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patienten",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Termine_DiagnoseId",
                table: "Termine",
                column: "DiagnoseId");

            migrationBuilder.CreateIndex(
                name: "IX_Termine_PatientId",
                table: "Termine",
                column: "PatientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Termine");

            migrationBuilder.DropTable(
                name: "Diagnosen");

            migrationBuilder.DropTable(
                name: "Patienten");
        }
    }
}
