using Film_System.Interfaces;
using FilmSystem.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Film_System.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected FilmSystemDbContext FilmSystemDbContext { get; set; }
        public RepositoryBase(FilmSystemDbContext filmSystemDbContext)
        {
            FilmSystemDbContext = filmSystemDbContext;
        }
        public IQueryable<T> GetAll() => FilmSystemDbContext.Set<T>().AsNoTracking();
        public IQueryable<T> GetByCondition(Expression<Func<T, bool>> expression) =>
            FilmSystemDbContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity) => FilmSystemDbContext.Set<T>().Add(entity);
        public void Update(T entity) => FilmSystemDbContext.Set<T>().Update(entity);
        public void Delete(T entity) => FilmSystemDbContext.Set<T>().Remove(entity);
    }
}
