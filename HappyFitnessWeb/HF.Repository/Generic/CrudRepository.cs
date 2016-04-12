using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF.Repository.Generic
{
    public class CrudRepository<TDbContext, TEntity> : BaseDataRepository<TDbContext>, ICrudRepository<TEntity>
        where TDbContext : DbContext
        where TEntity : class
    {
        public virtual int Insert(TEntity entity)
        {
            this.Repository.Insert(entity);
            this.Repository.SaveChanges();

            return 0;
        }

        public virtual void Update(TEntity entity)
        {
            this.Repository.Update(entity);
            this.Repository.SaveChanges();
        }

        public virtual void Delete(params object[] ids)
        {
            this.Delete(this.Get(ids));
        }

        public virtual void Delete(TEntity entity)
        {
            this.Repository.Delete(entity);
            this.Repository.SaveChanges();
        }

        public virtual TEntity Get(params object[] ids)
        {
            return this.Repository.Get<TEntity>(ids);
        }

        protected IQueryable<TEntity> GetAll()
        {
            return this.Repository.Query<TEntity>().AsNoTracking();
        }

        protected IQueryable<TEntity> Get(ISatisfiedBy<TEntity> satisfiedBy)
        {
            return this.Repository.Queryable(satisfiedBy);
        }
    }
}
