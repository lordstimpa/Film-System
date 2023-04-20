using Film_System.Repository;
using Film_System.Repository_Models;
using Film_System.Secret;
using FilmSystem.DataAccess;
using FilmSystem.Models;
using Newtonsoft.Json;
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

// ( GET ) all people
app.MapGet("/person", (HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    PersonRepository personRepo = new PersonRepository(filmSystemDbContext);

    return personRepo.GetAll();
})
.WithName("GetPeople");

// ( GET ) all genres connected to a person
app.MapGet("/persongenre/{id}", (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    PersonGenreRepository personGenreRepo = new PersonGenreRepository(filmSystemDbContext);
    PersonRepository personRepo = new PersonRepository(filmSystemDbContext);
    GenreRepository genreRepo = new GenreRepository(filmSystemDbContext);
   
    var genres = personGenreRepo.GetByCondition(pG => pG.Fk_person == id).Join(genreRepo.GetAll(),
                   personGenre => personGenre.Fk_genre,
                   genres => genres.Id_genre,
                   (persGen, gen) => new { Genre = gen }).ToList();

    return genres;
})
.WithName("GetGenreByPersonId");

// ( GET ) all movies connected to a person
app.MapGet("/movie/{id}", (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieRepository movieRepo = new MovieRepository(filmSystemDbContext);

    var movies = movieRepo.GetByCondition(m => m.Fk_person == id).ToList();

    return movies;
})
.WithName("GetMovieByPersonId");

// ( GET ) rating on movie connected to a person
app.MapGet("/movierating/{id}", (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieRatingRepository movieRatingRepo = new MovieRatingRepository(filmSystemDbContext);

    var movieRatings = movieRatingRepo.GetByCondition(mR => mR.Fk_person == id).ToList();

    return movieRatings;
})
.WithName("GetMovieRatingByPersonId");

// ( POST ) rating on movie connected to a person
app.MapPost("/movierating", (MovieRating movieRating, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieRatingRepository movieRatingRepo = new MovieRatingRepository(filmSystemDbContext);

    movieRatingRepo.Create(movieRating);
    filmSystemDbContext.SaveChanges();

    return movieRating;
})
.WithName("PostMovieRatingByPersonId");

// ( POST ) Connect a person to a new genre
app.MapPost("/persongenre", (PersonGenre personGenre, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    PersonGenreRepository personGenreRepo = new PersonGenreRepository(filmSystemDbContext);

    personGenreRepo.Create(personGenre);
    filmSystemDbContext.SaveChanges();

    return personGenre;
})
.WithName("PostPersonToGenreByPersonId");

// ( POST ) new movie for a person
app.MapPost("/movie-person", (Movie movie, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieRepository movieRepo = new MovieRepository(filmSystemDbContext);

    movieRepo.Create(movie);
    filmSystemDbContext.SaveChanges();

    return movie;
})
.WithName("PostMovieConnectedToPerson");

// ( POST ) new movie for a genre
app.MapPost("/movie-genre", (MovieGenre movieGenre, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    MovieGenreRepository movieGenreRepo = new MovieGenreRepository(filmSystemDbContext);

    movieGenreRepo.Create(movieGenre);
    filmSystemDbContext.SaveChanges();

    return movieGenre;
})
.WithName("PostMovieConnectedToGenre");

// ( GET ) movies related to a genre from an external API (TMDB)
app.MapGet("/movies/{id}", async (int id, HttpContext httpContext) =>
{
    FilmSystemDbContext filmSystemDbContext = new FilmSystemDbContext();
    GenreRepository genreRepo = new GenreRepository(filmSystemDbContext);
    Service keyClass = new Service();
    var genre = genreRepo.GetByCondition(g => g.Id_genre == id).Single();

    string baseUrl = "https://api.themoviedb.org/3/discover/movie?api_key=";
    string apiKey = keyClass.App_Key;
    int tmdbGenreId = genre.Id_tmdb;

    var completeUrl = (baseUrl + keyClass.App_Key + "&with_genres=" + tmdbGenreId).ToString();

    var client = new HttpClient();

    var response = await client.GetAsync(completeUrl);
    var content = await response.Content.ReadAsStringAsync();

    return Results.Content(content, contentType: "application/json");
})
.WithName("GetMoviesRelatedToGenre");

app.Run(); 
