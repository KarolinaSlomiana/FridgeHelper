using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeHelper.Migrations
{
    public partial class AddedSpecificName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SpecificName",
                table: "Products",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpecificName",
                table: "Products");
        }
    }
}
