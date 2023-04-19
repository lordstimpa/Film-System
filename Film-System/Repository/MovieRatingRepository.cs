using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace Film_System.Repository
{
    public class MovieRatingRepository : RepositoryBase<MovieRating>, IMovieRatingRepository
    {
        public MovieRatingRepository(FilmSystemDbContext filmSystemDbContext)
            : base(filmSystemDbContext)
        {
        }
    }
}
