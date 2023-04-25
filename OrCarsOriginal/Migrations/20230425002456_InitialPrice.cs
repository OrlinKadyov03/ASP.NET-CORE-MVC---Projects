using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrCarsOriginal.Migrations
{
    public partial class InitialPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Car");
        }
    }
}
