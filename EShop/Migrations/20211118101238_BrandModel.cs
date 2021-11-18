using Microsoft.EntityFrameworkCore.Migrations;

namespace EShop.Migrations
{
    public partial class BrandModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_Cart1",
                table: "Account");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Cart",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CartID",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Account_CartID",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Account");

            migrationBuilder.AddColumn<int>(
                name: "BrandID",
                table: "Product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    BrandID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.BrandID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brand",
                table: "Product",
                column: "BrandID",
                principalTable: "Brand",
                principalColumn: "BrandID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brand",
                table: "Product");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropIndex(
                name: "IX_Product_BrandID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "BrandID",
                table: "Product");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Account",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CartID",
                table: "Customers",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_Account_CartID",
                table: "Account",
                column: "CartID");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_Cart1",
                table: "Account",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Cart",
                table: "Customers",
                column: "CartID",
                principalTable: "Cart",
                principalColumn: "CartID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
