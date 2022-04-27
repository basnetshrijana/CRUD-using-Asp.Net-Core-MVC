using BookMvc.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookMvc.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;

        protected readonly DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentException(nameof(dbContext));
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void Delete(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public virtual ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity)
        {
            return _dbSet.AddAsync(entity);
        }

        public virtual Task InsertAsync(IEnumerable<TEntity> entities)
        {
            return _dbSet.AddRangeAsync(entities);
        }


        public virtual void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public TEntity Insert(TEntity entity)
        {
           return _dbSet.Add(entity).Entity;
        }

    }
        
    
}