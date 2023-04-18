using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace Film_System.Repository
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(FilmSystemDbContext filmSystemDbContext)
            : base(filmSystemDbContext)
        {
        }
    }
}
