using Microsoft.EntityFrameworkCore.Migrations;

namespace APixelADay.Migrations
{
    public partial class thirdMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PixelArtURL",
                table: "PixelArts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PixelArtURL",
                table: "PixelArts");
        }
    }
}
