using Jobs.Core.Interfaces;
using Jobs.Core.Models;
using Jobs.EF.Data;
using System.Linq.Expressions;

namespace Jobs.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool IsExist(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return query.Any(criteria);
        }

        public T Find(Expression<Func<T, bool>> criteria)
        {
            IQueryable<T> query = _context.Set<T>();

            return query.FirstOrDefault(criteria);
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _context.Set<T>();

            return query.ToList();
        }

        public T Add(T entity)
        {
            _context.Set<T>().Add(entity);

            return entity;
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

    }
}
