using System.Data.Entity;
using Data;

namespace ProvenStyle.Data
{
    public class DataMappingConfiguration : Highway.Data.IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonMapping());
        }
    }
}
