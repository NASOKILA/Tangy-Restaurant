using Microsoft.EntityFrameworkCore.Migrations;

namespace TangyRestaurant.Migrations
{
    public partial class EspisyEnumChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Espicy",
                table: "MenuItem",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Espicy",
                table: "MenuItem");
        }
    }
}
