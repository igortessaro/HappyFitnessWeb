using System.Configuration;

namespace HF.Repository.Repository.Context
{
    public class DefaultDataServiceDbContextElement : ConfigurationElement
    {
        [ConfigurationProperty("typeName", IsRequired = true)]
        public string TypeName
        {
            get
            {
                return (string)this["typeName"];
            }
            set
            {
                this["typeName"] = value;
            }
        }
    }
}