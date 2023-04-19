using Film_System.Repository;
using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace Film_System.Repository_Models
{
    public class PersonGenreRepository : RepositoryBase<PersonGenre>, IPersonGenreRepository
    {
        public PersonGenreRepository(FilmSystemDbContext filmSystemDbContext)
            : base(filmSystemDbContext)
        {
        }
    }
}
