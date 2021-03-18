using Microsoft.EntityFrameworkCore.Migrations;

namespace APixelADay.Migrations
{
    public partial class InitialDayCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DayCount",
                table: "PixelArts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DayCount",
                table: "PixelArts");
        }
    }
}
