using System.Linq.Expressions;

namespace TaskManagement.Domain.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        IQueryable<TEntity> Entities { get; }
        Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = false);
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}