using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToysAndGames.Persistence.Migrations
{
    public partial class AddReleaseYearToProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReleaseYear",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Products");
        }
    }
}
