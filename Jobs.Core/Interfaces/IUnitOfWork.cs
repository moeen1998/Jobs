using Jobs.Core.Models;

namespace Jobs.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;
        Task<int> SaveChangesAsync();
    }
}
