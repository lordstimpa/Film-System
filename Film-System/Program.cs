using Film_System.Repository;
using Film_System.Repository_Models;
using FilmSystem.DataAccess;
using FilmSystem.Models;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseHttpsRedirection();

// GET all people
app.MapGet("/person", (HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    PersonRepository personRepo = new PersonRepository(filmSystemDbContext);

    return personRepo.GetAll();
})
.WithName("GetPeople");

// GET all genres connected to a person
app.MapGet("/persongenre/{id}", (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    PersonGenreRepository personGenreRepo = new PersonGenreRepository(filmSystemDbContext);
    PersonRepository personRepo = new PersonRepository(filmSystemDbContext);
    GenreRepository genreRep = new GenreRepository(filmSystemDbContext);
   
    var genres = personGenreRepo.GetByCondition(pG => pG.Fk_person == id).Join(genreRep.GetAll(),
                   personGenre => personGenre.Fk_genre,
                   genres => genres.Id_genre,
                   (persGen, gen) => new { Genre = gen }).ToList();

    return genres;
})
.WithName("GetGenreByPersonId");

// GET all movies connected to a person
app.MapGet("/movie/{id}", (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieRepository movieRepo = new MovieRepository(filmSystemDbContext);

    var movies = movieRepo.GetByCondition(m => m.Fk_person == id).ToList();

    return movies;
})
.WithName("GetMovieByPersonId");

// GET rating on movie connected to a person
app.MapGet("/movierating/{id}", (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieRatingRepository movieRatingRepo = new MovieRatingRepository(filmSystemDbContext);
    PersonRepository personRepo = new PersonRepository(filmSystemDbContext);
    MovieRepository movieRepo = new MovieRepository(filmSystemDbContext);

    var movieRatings = movieRatingRepo.GetByCondition(pG => pG.Fk_person == id).Join(movieRepo.GetAll(),
               personRepo => personRepo.Fk_person,
               movieRepo => movieRepo.Id_movie,
               (movRate, gen) => new { Genre = gen }).ToList();

    return movieRatings;
})
.WithName("GetMovieRatingByPersonId");

// ADD rating on movie connected to a person

// Connect a person to a new genre

// Add new links for a person 

// Add new links for a genre

// Get movies related to a genre from an external API (TMDB)

app.Run();