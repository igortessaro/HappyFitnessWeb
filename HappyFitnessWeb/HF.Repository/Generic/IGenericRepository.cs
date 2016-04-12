using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF.Repository.Generic
{
    public interface IGenericRepository
    {
        void Insert(object entity);

        void Update(object entity);

        void Delete(object entity);

        TEntity Get<TEntity>(params object[] ids) where TEntity : class;

        IQueryable<TEntity> Query<TEntity>() where TEntity : class;

        IQueryable<TEntity> Queryable<TEntity>(ISatisfiedBy<TEntity> satisfiedBy) where TEntity : class;

        void SaveChanges();

        void UndoChanges();
    }
}
