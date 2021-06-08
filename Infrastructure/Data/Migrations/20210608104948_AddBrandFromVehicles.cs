using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Data.Migrations
{
    public partial class AddBrandFromVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Buses",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Boats",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Boats");
        }
    }
}
