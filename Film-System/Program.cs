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
    PersonRepository personRepo = new PersonRepository(new FilmSystemDbContext());

    return personRepo.GetAll();
})
.WithName("GetPeople");

// GET all genres connected to a person
app.MapGet("/persongenre/{id}", (int id, HttpContext httpContext) =>
{
    PersonGenreRepository genreRepo = new PersonGenreRepository(new FilmSystemDbContext());

    return genreRepo.GetByCondition(genre => genre.Fk_person == id);
})
.WithName("GetGenreByPersonId");

// GET all movies connected to a person
app.MapGet("/movie/{id}", (int id, HttpContext httpContext) =>
{
    MovieRepository movieRepo = new MovieRepository(new FilmSystemDbContext());

    return movieRepo.GetByCondition(movie => movie.Fk_person == id);
})
.WithName("GetMovieByPersonId");

// Add and get rating on movies connected to a person

// Connect a person to a new genre

// Add new links for a person 

// Add new links for a genre

// Get movies related to a genre from an external API (TMDB)

app.Run();