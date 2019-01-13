using Microsoft.EntityFrameworkCore.Migrations;

namespace TangyRestaurant.Migrations
{
    public partial class PriceChangeToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                table: "MenuItems",
                nullable: false,
                oldClrType: typeof(double));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "MenuItems",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
