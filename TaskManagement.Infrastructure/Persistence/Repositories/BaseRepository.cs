using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Repositories;
using Task = System.Threading.Tasks.Task;

namespace TaskManagement.Infrastructure.Persistence.Repositories
{
    internal abstract class BaseRepository<TEntity>(TaskManagmentDbContext dbContext) : IBaseRepository<TEntity> 
        where TEntity : BaseEntity, new()
    {
        private readonly TaskManagmentDbContext _dbContext = dbContext;

        public IQueryable<TEntity> Entities => _dbContext.Set<TEntity>();

        public Task<TEntity> AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity?> GetByIdAsync(Expression<Func<TEntity, bool>> predicate, bool noTracking = false)
        {
            var query = Entities.AsQueryable();
            if (noTracking) query = query.AsNoTracking();
            return query.SingleOrDefaultAsync(predicate);
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}