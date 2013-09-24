using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Machine.Specifications;
using ProvenStyle.Data;

namespace ProvenStyle.DataIntegrationTests
{
   public class with_container
   {
      public static WindsorContainer Container;
      public static IRepositoryFactory Factory;

      private Establish context = () =>
         {
            var manager = new DatabaseManager(Constants.ConnectionName);
            manager.DropCreateDatabase();

            Container = new WindsorContainer();
            Container.AddFacility<TypedFactoryFacility>();
            Container.Install(new DataInstaller());
            Factory = Container.Resolve<IRepositoryFactory>();
         };      
   }
}