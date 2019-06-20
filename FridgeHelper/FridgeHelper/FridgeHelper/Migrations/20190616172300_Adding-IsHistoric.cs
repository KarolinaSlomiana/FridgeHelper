using Microsoft.EntityFrameworkCore.Migrations;

namespace FridgeHelper.Migrations
{
    public partial class AddingIsHistoric : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHistoric",
                table: "Products",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHistoric",
                table: "Products");
        }
    }
}
