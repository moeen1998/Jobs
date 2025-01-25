using System.Linq.Expressions;

namespace Jobs.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        bool IsExist(Expression<Func<T, bool>> criteria);

        T Find(Expression<Func<T, bool>> criteria);
        
        IEnumerable<T> GetAll();
                
        T Add(T entity);
        
        T Update(T entity);
    }
}
