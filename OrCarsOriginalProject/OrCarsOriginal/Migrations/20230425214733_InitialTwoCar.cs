using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrCarsOriginal.Migrations
{
    public partial class InitialTwoCar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AntiLockBraking",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte>(
                name: "Audio",
                table: "Car",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Cylinders",
                table: "Car",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "DualFrontAirbags",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PSteering",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Variant",
                table: "Car",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AntiLockBraking",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Audio",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Cylinders",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "DualFrontAirbags",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "PSteering",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Variant",
                table: "Car");
        }
    }
}
