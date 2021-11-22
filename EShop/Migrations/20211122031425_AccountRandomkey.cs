using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Migrations
{
    public partial class AccountRandomkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Randomkey",
                table: "Account",
                type: "nchar(10)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Randomkey",
                table: "Account");
        }
    }
}
