using System.Data.Entity;

namespace HF.Repository.Repository.Context
{
    public class CrudService<TEntity> : BaseDataService, ICrudService<TEntity>
        where TEntity : class
    {
        public virtual int Insert(TEntity entity)
        {
            this.ValidateRules(entity, OperationType.Insert);

            this.Repository.Insert(entity);
            this.Repository.SaveChanges();
            return 0;
        }

        public virtual void Update(TEntity entity)
        {
            this.ValidateRules(entity, OperationType.Update);

            this.Repository.Update(entity);
            this.Repository.SaveChanges();
        }

        public virtual void Delete(params object[] ids)
        {
            this.Delete(this.Get(ids));
        }

        public virtual void Delete(TEntity entity)
        {
            this.ValidateRules(entity, OperationType.Delete);

            this.Repository.Delete(entity);
            this.Repository.SaveChanges();
        }

        public virtual TEntity Get(params object[] ids)
        {
            return this.Repository.Get<TEntity>(ids);
        }

        protected virtual void ValidateRules(TEntity entity, OperationType operationType)
        {
        }
    }

    public class BaseCrudService<TDbContext, TEntity> : CrudService<TEntity>
        where TDbContext : DbContext, new()
        where TEntity : class
    {
        public BaseCrudService()
        {
            this.Repository = new EntityFrameworkWrapper(new TDbContext());
        }
    }
}