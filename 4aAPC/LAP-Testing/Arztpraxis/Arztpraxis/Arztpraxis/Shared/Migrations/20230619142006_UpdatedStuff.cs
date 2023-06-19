using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Arztpraxis.Shared.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedStuff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Datum",
                table: "Termine",
                newName: "Ende");

            migrationBuilder.AddColumn<DateTime>(
                name: "Beginn",
                table: "Termine",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Beginn",
                table: "Termine");

            migrationBuilder.RenameColumn(
                name: "Ende",
                table: "Termine",
                newName: "Datum");
        }
    }
}
