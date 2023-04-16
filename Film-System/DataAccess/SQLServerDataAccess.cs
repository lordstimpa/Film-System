using FilmSystem.DataAccess;
using FilmSystem.Models;

namespace FilmSystemAPI.DataAccess
{
    public class SQLServerDataAccess
    {
        // POST person to database
        public static Person AddPerson(Person person)
        {
            using (var context = new FilmSystemDbContext())
            {
                if (context.Person.Any(p => p.Email == person.Email))
                {
                    return person;
                };

                context.Person.Add(person);
                context.SaveChanges();

                return person;
            }
        }

        // GET all people in the database
        public static List<Person> GetPeople()
        {
            using (var context = new FilmSystemDbContext())
            {
                return context.Person.ToList();
            }
        }
    }
}
