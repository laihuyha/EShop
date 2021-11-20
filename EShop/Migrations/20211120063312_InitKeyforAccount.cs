using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Migrations
{
    public partial class InitKeyforAccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Randomkey",
                table: "Customers",
                type: "nvarchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Randomkey",
                table: "Customers");
        }
    }
}
