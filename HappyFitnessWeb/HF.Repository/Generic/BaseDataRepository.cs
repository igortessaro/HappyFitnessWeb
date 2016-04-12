using System;
using System.Data.Entity;

namespace HF.Repository.Generic
{
    public abstract class BaseDataRepository<TDbContext>
        where TDbContext : DbContext
    {
        public BaseDataRepository()
        {
            DbContext dbContext = (DbContext)Activator.CreateInstance(typeof(TDbContext), new object[] { });

            this.Repository = new EntityFrameworkWrapper(dbContext);
        }

        protected IGenericRepository Repository
        { get; set; }
    }
}
