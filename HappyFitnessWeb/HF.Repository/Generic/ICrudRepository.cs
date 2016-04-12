using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HF.Repository.Generic
{
    public interface ICrudRepository<TEntity>
        where TEntity : class
    {
        int Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        TEntity Get(params object[] ids);
    }
}
