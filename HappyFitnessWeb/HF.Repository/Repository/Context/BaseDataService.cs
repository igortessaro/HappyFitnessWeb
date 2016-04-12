using System;
using System.Configuration;
using System.Data.Entity;

namespace HF.Repository.Repository.Context
{
    public abstract class BaseDataService : BaseService
    {
        public BaseDataService()
        {
            ServiceBusinessSection serviceBusinessSection =
                (ServiceBusinessSection)ConfigurationManager.GetSection(ServiceBusinessSection.ServiceBusinessSectionName);

            Type dbContextType = Type.GetType(serviceBusinessSection.DefaultDataServiceDbContext.TypeName, true, true);
            DbContext dbContext = (DbContext)Activator.CreateInstance(dbContextType);

            this.Repository = new EntityFrameworkWrapper(dbContext);
        }
        protected IGenericRepository Repository { get; set; }

        public override void Dispose()
        {
            if (Repository != null)
            {
                Repository.Dispose();
                Repository = null;
            }
        }

    }

    public abstract class BaseDataService<TDbContext> : BaseDataService, IDisposable
        where TDbContext : DbContext, new()
    {
        public BaseDataService()
        {
            this.Repository = new EntityFrameworkWrapper(new TDbContext());
        }


        public override void Dispose()
        {

            if (this.Repository != null)
            {
                this.Repository.Dispose();
                this.Repository = null;
            }
        }
    }
}