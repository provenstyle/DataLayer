using System.Configuration;
using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Highway.Data;

namespace ProvenStyle.Data
{
    public class DataInstaller : IComponentsInstaller
    {
        public void SetUp(IWindsorContainer container, IConfigurationStore store)
        {
            var cn = ConfigurationManager.ConnectionStrings["DataLayer"].ConnectionString;

            container.Register(
                Component.For<IMappingConfiguration>().ImplementedBy<DataMappingConfiguration>(),
                Component.For<IDataContext>().ImplementedBy<DataContext>().DependsOn(new{connectionString = cn}).LifeStyle.Transient,
                Component.For<IRepository>().ImplementedBy<Repository>().LifeStyle.Transient,    
                Component.For<IRepositoryFactory>().AsFactory()                
             );
        }
    }
}
