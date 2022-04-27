using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace BookMvc.Repository
{
     public interface IRepository<TEntity> where TEntity : class
    {
        Task<IList<TEntity>> GetAllAsync();
        TEntity Insert(TEntity entity);
        ValueTask<EntityEntry<TEntity>> InsertAsync(TEntity entity);
        void Insert(IEnumerable<TEntity> entities);
        Task InsertAsync(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Delete(TEntity entity);
        void Delete(IEnumerable<TEntity> entities);
    }
 
}