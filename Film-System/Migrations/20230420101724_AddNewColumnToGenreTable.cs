using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_System.Migrations
{
    public partial class AddNewColumnToGenreTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_tmdb",
                table: "Genre",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id_tmdb",
                table: "Genre");
        }
    }
}
