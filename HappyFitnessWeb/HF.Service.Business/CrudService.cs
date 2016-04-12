using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HF.Repository;
using HF.Repository.Generic;

namespace HF.Service
{
    public class CrudService<TEntity> : ICrudService<TEntity>
        where TEntity : class
    {
        public ICrudRepository<TEntity> Repository { get; set; }

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

    public enum OperationType
    {
        Insert, Update, Delete
    }
}
