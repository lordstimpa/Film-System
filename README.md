# Film-System

## Overview

This is a ASP.NET Core Web API application developed for creating the possibility to access data from a local database.
The program includes the use of an external API which retrieves data related to the data stored in the local database.

TMDB (The Movie Database) is the source for the external API.

Feel free to visit their website:
<picture>
<a href="https://www.themoviedb.org/"><img width="80" alt="Container diagram." src="github/blue_short-tmdb.svg"></a>
</picture>

## API-calls

All of the API-calls created can be seen below:

<table>
    <tr>
        <th> URL path</th>
        <th> HTTP method</th>
        <th> Description</th>
        <th> Example request/response</th>
    </tr>
    <tr>
        <td>/person</td>
        <td>GET</td>
        <td>Get all people</td>
        <td>[
{
    "id_person": 0,
    "first_name": "string",
    "last_name": "string",
    "email": "string"
  }
]</td>
    </tr>
    <tr>
        <td>/persongenre/{person-id}</td>
        <td>GET</td>
        <td>Get genres by personId</td>
        <td>[
  {
    "genre": {
      "id_genre": 0,
      "id_tmdb": 0,
      "title": "string",
      "description": "string"
    }
  }
]</td>
    </tr>
    <tr>
        <td>/movie/{person-id}</td>
        <td>GET</td>
        <td>Get movies by personId</td>
        <td>[
  {
    "id_movie": 0,
    "fk_person": 0,
    "person": null,
    "title": "string",
    "link": "string"
  }]</td>
    </tr>
    <tr>
        <td>/movierating/{person-id}</td>
        <td>GET</td>
        <td>Get movie rating by personId</td>
        <td>[
  {
    "id_movieRating": 0,
    "fk_movie": 0,
    "movie": null,
    "fk_person": 0,
    "person": null,
    "rating": 0
  }]</td>
    </tr>
    <tr>
        <td>/movierating</td>
        <td>POST</td>
        <td>Post movie rating by person</td>
        <td>{
  "fk_movie": 3,
  "fk_person": 2,
  "rating": 9
}</td>
    </tr>
    <tr>
        <td>/persongenre</td>
        <td>POST</td>
        <td>Post genre liked by person</td>
        <td>{
  "fk_person": 2,
  "fk_genre": 6
}</td>
    </tr>
    <tr>
        <td>/movie-person</td>
        <td>POST</td>
        <td>POST movie linked to person</td>
        <td>{
  "fk_person": 1,
  "title": "The Super Mario Bros. Movie",
  "link": "https://www.themoviedb.org/movie/502356-the-super-mario-bros-movie"
}</td>
    </tr>
    <tr>
        <td>/movie-genre</td>
        <td>POST</td>
        <td>POST movie linked to genre</td>
        <td>{
  "fk_movie": 4,
  "fk_genre": 6
}</td>
    </tr>
    <tr>
        <td>/movies/{genre-id}</td>
        <td>GET</td>
        <td>GET movies related to genre</td>
        <td>    {
      "adult": false,
      "backdrop_path": "/qQWR4f765vp8uRKaY39R8W47wLX.jpg",
      "genre_ids": [
        37,
        27,
        9648
      ],
      "id": 888257,
      "original_language": "en",
      "original_title": "Ghosts of the Ozarks",
      "overview": "In 1866, a young doctor is summoned by his uncle to a remote town in the Ozarks only to discover upon his arrival that the utopian paradise is not all that it seems to be.",
      "popularity": 124.926,
      "poster_path": "/5KgBwcelQoxWgplfJhY46Urz3Cf.jpg",
      "release_date": "2022-02-04",
      "title": "Ghosts of the Ozarks",
      "video": false,
      "vote_average": 6.3,
      "vote_count": 16
    }</td>
    </tr>
</table>

## Database Structure

Below image shows the tables the Film System database consists of:
<picture>
<img width="550" alt="Container diagram." src="github/ER-diagram-FilmSystem-Tables.drawio.png">
</picture>

Below image show an ER-diagram which displays the relationship between the tables:
<picture>
<img width="550" alt="Container diagram." src="github/ER-diagram-FilmSystem-Relation.drawio.png">
</picture>

## Reflection

The first step of developing this web-API was to design a ER-model which gives context to the database schema. The API is hard to create without a good database design.

My main goal when designing the ER-model was to significantly reduce repeated rows of the same sort of data. To manage this potential problem I added two junction tables (PersonGenre, MovieGenre). For instance, since a movie can have several types of genres, if I were not to have a junction table (MovieGenre) between them it would force me to store the primary key of Genre table as a foreign key in the Movie table. Now if I were to connect a movie to 4 types of genres then that table would include 4 rows of the same information (except the genre which is different on each specific row).

One could argue that having this many tables is just making it more complicated than it needs to be. That might be true depending on the type of tools used in writing the code.

I used the repository pattern for creating this application which is a pattern I am inexperinced in using. It added separation of concern which makes the program easier to maintain. But by using this pattern I experienced that it was harder and more complicated to develop the API calls. In observing the approach of not using a repository pattern it seemed easier to design the API calls with Entity Framework on it's own. Since Entity Framework already is considered an abstraction layer in of itself.

To determine the best approach is by trying different code structures and tools. From observing and discussing other types of methods in creating a minimal API I came to the conclusion that a repository pattern might not be useful in development of smaller projects. If it was a large project with a database with many tables and rows of data it might be a more optimal approach.

The API calls created can be improved upon by adding exception handling in the code. The current API does not include exception handling which is crucial for making sure that everything in the API works as intended.

## Tools

All of the tools used during the development of this program:

#### Integrated Development Environment (IDE)

- Visual Studio

#### Relational Database Management System (RDBMS)

- SQL Server 2022

#### Database Client (GUI)

- Microsoft SQL Server Management Studio 19

#### Dependencies / Packages

- Microsoft.EntityFrameworkCore (6.0.16)
- Microsoft.EntityFrameworkCore.SqlServer (6.0.16)
- Microsoft.EntityFrameworkCore.Tools (6.0.16)
- Swashbuckle.AspNetCore (6.2.3)
- Newtonsoft.Json (13.0.3)

### Design Pattern

- Repository Pattern

### Object Relational Mapping (ORM)

- Entity Framework

#### Languages

- C#
- SQL
