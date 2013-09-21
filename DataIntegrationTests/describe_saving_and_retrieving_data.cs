using System.Collections.Generic;
using System.Linq;
using Highway.Data;
using Machine.Specifications;
using ProvenStyle.Data;
using ProvenStyle.DatabaseManager;
using ProvenStyle.Entities;

namespace ProvenStyle.DataIntegrationTests
{
    [Subject("Saving and retrieving data")]
    public class when_saving_and_retrieving_data
    {
        private static DatabaseCreator _creator;
        private static IRepository _repository;
        private static List<Person> _people;

        private Establish establish = () =>
            {
                _creator = new DatabaseCreator(ConnectionString.GetConnectionString());
                _creator.DropCreateDatabase();
                _repository = _creator.GetRepository();
                
            };

        private Because of_adding_and_retrieving = () =>
                                  {
                                      _repository.Context.Add(new Person("Bob", "Smith"));
                                      _repository.Context.Commit();
                                      _people = _repository.Find(new PeopleByFirstName("Bob")).ToList();
                                  };

        private It should_have_expected_records = () => _people.Count().ShouldEqual(1);

    }
}
