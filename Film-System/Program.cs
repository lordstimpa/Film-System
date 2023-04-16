using FilmSystem.Models;
using FilmSystemAPI.DataAccess;
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

// Add person
app.MapPost("/person", (Person person) =>
{
    TextInfo myTI = new CultureInfo("en-US", false).TextInfo;
    person.First_name = myTI.ToTitleCase(person.First_name);

    var response = SQLServerDataAccess.AddPerson(person);

    return response;
})
.WithName("AddPerson");

// GET all people
app.MapGet("/person", (HttpContext httpContext) =>
{
    var response = SQLServerDataAccess.GetPeople();

    return response;
})
.WithName("GetPeople");

// Get all genres connected to a person

// Get all movies connected to a person

// Add and get rating on movies connected to a person

// Connect a person to a new genre

// Add new links for a person 

// Add new links for a genre

// Get movies related to a genre from an external API (TMDB)

app.Run();