using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RaceRunApp.Migrations
{
    public partial class Mileage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Milage",
                table: "AspNetUsers",
                newName: "Mileage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mileage",
                table: "AspNetUsers",
                newName: "Milage");
        }
    }
}
