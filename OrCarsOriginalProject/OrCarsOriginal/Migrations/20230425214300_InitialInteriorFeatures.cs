using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrCarsOriginal.Migrations
{
    public partial class InitialInteriorFeatures : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AC",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "AntiTheft",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BrakeAssist",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "BrakeEBFC",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CentralLocking",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "CruiseControl",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EngineImmobiliser",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FrontPowerWindows",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HeadAirbags",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MirrorIndicators",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MultiFunctionScreen",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PowerMirrors",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RearPowerWindows",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RemoteKey",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ReversingCamera",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "SideFrontAirbags",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TractionControlSystem",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TripComputer",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VehicleStabilityControl",
                table: "Car",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AC",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "AntiTheft",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BrakeAssist",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BrakeEBFC",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CentralLocking",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "CruiseControl",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "EngineImmobiliser",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "FrontPowerWindows",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "HeadAirbags",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MirrorIndicators",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "MultiFunctionScreen",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "PowerMirrors",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RearPowerWindows",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "RemoteKey",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "ReversingCamera",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "SideFrontAirbags",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TractionControlSystem",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "TripComputer",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "VehicleStabilityControl",
                table: "Car");
        }
    }
}
