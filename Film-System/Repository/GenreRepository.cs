using Film_System.Repository;
using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace Film_System.Repository_Models
{
    public class GenreRepository : RepositoryBase<Genre>, IGenreRepository
    {
        public GenreRepository(FilmSystemDbContext filmSystemDbContext)
            : base(filmSystemDbContext)
        {
        }
    }
}
