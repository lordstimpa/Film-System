using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Film_System.Migrations
{
    public partial class InitializeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id_genre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id_genre);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    Id_person = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Last_name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.Id_person);
                });

            migrationBuilder.CreateTable(
                name: "Movie",
                columns: table => new
                {
                    Id_movielink = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_person = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Link = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie", x => x.Id_movielink);
                    table.ForeignKey(
                        name: "FK_Movie_Person_Fk_person",
                        column: x => x.Fk_person,
                        principalTable: "Person",
                        principalColumn: "Id_person",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonGenre",
                columns: table => new
                {
                    Id_personGenre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_person = table.Column<int>(type: "int", nullable: false),
                    Fk_genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonGenre", x => x.Id_personGenre);
                    table.ForeignKey(
                        name: "FK_PersonGenre_Genre_Fk_genre",
                        column: x => x.Fk_genre,
                        principalTable: "Genre",
                        principalColumn: "Id_genre",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PersonGenre_Person_Fk_person",
                        column: x => x.Fk_person,
                        principalTable: "Person",
                        principalColumn: "Id_person",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MovieGenre",
                columns: table => new
                {
                    Id_movieGenre = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_movie = table.Column<int>(type: "int", nullable: false),
                    Fk_genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieGenre", x => x.Id_movieGenre);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Genre_Fk_genre",
                        column: x => x.Fk_genre,
                        principalTable: "Genre",
                        principalColumn: "Id_genre",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MovieGenre_Movie_Fk_movie",
                        column: x => x.Fk_movie,
                        principalTable: "Movie",
                        principalColumn: "Id_movielink",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MovieRating",
                columns: table => new
                {
                    Id_movieRating = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fk_movie = table.Column<int>(type: "int", nullable: false),
                    Fk_person = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieRating", x => x.Id_movieRating);
                    table.ForeignKey(
                        name: "FK_MovieRating_Movie_Fk_movie",
                        column: x => x.Fk_movie,
                        principalTable: "Movie",
                        principalColumn: "Id_movielink",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MovieRating_Person_Fk_person",
                        column: x => x.Fk_person,
                        principalTable: "Person",
                        principalColumn: "Id_person",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Fk_person",
                table: "Movie",
                column: "Fk_person");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_Fk_genre",
                table: "MovieGenre",
                column: "Fk_genre");

            migrationBuilder.CreateIndex(
                name: "IX_MovieGenre_Fk_movie",
                table: "MovieGenre",
                column: "Fk_movie");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRating_Fk_movie",
                table: "MovieRating",
                column: "Fk_movie");

            migrationBuilder.CreateIndex(
                name: "IX_MovieRating_Fk_person",
                table: "MovieRating",
                column: "Fk_person");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenre_Fk_genre",
                table: "PersonGenre",
                column: "Fk_genre");

            migrationBuilder.CreateIndex(
                name: "IX_PersonGenre_Fk_person",
                table: "PersonGenre",
                column: "Fk_person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieGenre");

            migrationBuilder.DropTable(
                name: "MovieRating");

            migrationBuilder.DropTable(
                name: "PersonGenre");

            migrationBuilder.DropTable(
                name: "Movie");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
