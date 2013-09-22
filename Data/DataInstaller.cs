using System.Configuration;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Highway.Data;

namespace ProvenStyle.Data
{
    public class DataInstaller : IWindsorInstaller
    {        
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            var manager = new DatabaseManager("DataLayer");

            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<DataMappingConfiguration>(),
                Component.For<IDataContext>().ImplementedBy<DataContext>().DependsOn(new { connectionString = manager.ConnectionString }).LifeStyle.Transient,
                Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.Transient,
                Component.For<IRepositoryFactory>().AsFactory()
             );
        }
    }
}
