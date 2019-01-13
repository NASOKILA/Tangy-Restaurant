using Microsoft.EntityFrameworkCore.Migrations;

namespace TangyRestaurant.Migrations
{
    public partial class EspisyEnumChanged2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Espicy",
                table: "MenuItem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Espicy",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0);
        }
    }
}
