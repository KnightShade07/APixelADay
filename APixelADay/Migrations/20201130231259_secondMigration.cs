using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APixelADay.Migrations
{
    public partial class secondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "PixelArts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "PixelArts",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
