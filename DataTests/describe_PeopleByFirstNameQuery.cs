using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Machine.Specifications;

namespace DataTests
{
    [Subject("Querying the Person table")]
    public class spec : with_mock_data
    {
        private static IEnumerable<Person> _people;

        Establish establish = () => MockDataContext<Person>(new List<Person>
                                                                        {
                                                                            new Person("Michael", "Jones"),
                                                                            new Person("Michael", "Smith"),
                                                                            new Person("Michael", "Peterson"),
                                                                            new Person("Robert", "Peterson"),
                                                                        });

        Because of = () => _people = Repository.Find(new PeopleByFirstName("Michael"));

        It should = () => _people.Count().ShouldEqual(3);
    }
}
