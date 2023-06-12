using Microsoft.EntityFrameworkCore;

namespace EF_Learning.Repository
{
    public class BaseRepository<TEntity> where TEntity : class
    {
        protected readonly Data.AppContext _appContext;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(Data.AppContext appContext) {
            _appContext = appContext;
            _dbSet = appContext.Set<TEntity>();
        }

        public TEntity FindById(int id) {
            return _dbSet.Find(id) ?? throw new Exception("Сущность не найдена.");
        }

        public List<TEntity> GetAll() {
            return _dbSet.ToList();
        }

        public void DeleteEntity(TEntity entity) {
            _dbSet.Remove(entity);
            _appContext.SaveChanges();
        }

        public void AddEntity(TEntity entity) {
            _dbSet.Add(entity);
            _appContext.SaveChanges();
        }
    }
}
