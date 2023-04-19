using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace Film_System.Repository
{
    public class MovieGenreRepository : RepositoryBase<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(FilmSystemDbContext filmSystemDbContext)
            : base(filmSystemDbContext)
        {
        }
    }
}
