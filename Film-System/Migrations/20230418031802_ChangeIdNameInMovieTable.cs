using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_System.Migrations
{
    public partial class ChangeIdNameInMovieTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_movielink",
                table: "Movie",
                newName: "Id_movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id_movie",
                table: "Movie",
                newName: "Id_movielink");
        }
    }
}
