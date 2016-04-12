using System.Configuration;

namespace HF.Repository.Repository.Context
{
    public class ServiceBusinessSection : ConfigurationSection
    {
        public const string ServiceBusinessSectionName = "frameworkServiceBusiness";

        [ConfigurationProperty("defaultDataServiceDbContext", IsRequired = true)]
        public DefaultDataServiceDbContextElement DefaultDataServiceDbContext
        {
            get
            {
                return (DefaultDataServiceDbContextElement)this["defaultDataServiceDbContext"];
            }
            set
            {
                this["defaultDataServiceDbContext"] = value;
            }
        }
    }
}