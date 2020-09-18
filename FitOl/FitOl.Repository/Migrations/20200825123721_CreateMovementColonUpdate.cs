using Microsoft.EntityFrameworkCore.Migrations;

namespace FitOl.Repository.Migrations
{
    public partial class CreateMovementColonUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EnumMovementType",
                table: "FT_Area",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnumMovementType",
                table: "FT_Area");
        }
    }
}
