using System.Data.Entity;
using System.Linq;

namespace HF.Repository.Generic
{
    public class EntityFrameworkWrapper: IGenericRepository
    {
        public EntityFrameworkWrapper(DbContext context)
        {
            this.context = context;
        }

        private DbContext context;

        public void Insert(object entity)
        {
            this.context.Entry(entity).State = EntityState.Added;
        }

        public void Update(object entity)
        {
            this.context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(object entity)
        {
            this.context.Entry(entity).State = EntityState.Deleted;
        }

        public TEntity Get<TEntity>(params object[] ids)
            where TEntity : class
        {
            return this.context.Set<TEntity>().Find(ids);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : class
        {
            return this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> Queryable<TEntity>(ISatisfiedBy<TEntity> satisfiedBy) where TEntity : class
        {
            return this.context.Set<TEntity>().AsNoTracking().Where(satisfiedBy.Where);
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public void UndoChanges()
        {
            foreach (var entry in this.context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.State = EntityState.Unchanged;
                        break;

                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;

                    case EntityState.Deleted:
                        entry.Reload();
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
