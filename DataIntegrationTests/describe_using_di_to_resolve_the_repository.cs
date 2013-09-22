using System.Collections.Generic;
using System.Linq;
using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Machine.Specifications;
using ProvenStyle.Data;
using ProvenStyle.Entities;

namespace ProvenStyle.DataIntegrationTests
{
    [Subject("When using a Castle Container")]
    public class spec
    {
        private static WindsorContainer _container;
        private static IEnumerable<Person> _people;

        private Establish establish = () =>
            {
                _container = new WindsorContainer();
                _container.AddFacility<TypedFactoryFacility>();
                _container.Install(new DataInstaller());

                var manager = new DatabaseManager(Constants.ConnectionName);
                manager.DropCreateDatabase();
            };

        private Because of_resolving_the_repository_factory = () =>
            {
                var factory = _container.Resolve<IRepositoryFactory>();
                factory.WithRepository(r =>
                {
                    r.Context.Add(new Person("Richard", "Castle"));
                    r.Context.Commit();
                    _people = r.Find(new PeopleByFirstName("Richard")).ToList();
                });
            };

        private It should_find_people = () => _people.Count().ShouldEqual(1);
    }
}
