using Film_System.Repository;
using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace Film_System.Repository_Models
{
    public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
    {
        public MovieRepository(FilmSystemDbContext filmSystemDbContext)
            : base(filmSystemDbContext)
        {
        }
    }
}
