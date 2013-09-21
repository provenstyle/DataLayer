using System.Collections.Generic;
using System.Linq;
using Data;
using Entities;
using Machine.Specifications;

namespace DataTests
{
    [Subject("Querying the Person table")]
    public class when_querying_by_first_name : with_mock_data
    {
        private static IEnumerable<Person> _people;

        Establish establish = () => MockDataContext(new List<Person>
            {
                new Person("Michael", "Jones"),
                new Person("Michael", "Smith"),
                new Person("Michael", "Peterson"),
                new Person("Robert", "Peterson"),
            });

        Because of_passing_firstName_query_to_repository = () => _people = Repository.Find(new PeopleByFirstName("Michael"));

        It should_find_expected_people = () => _people.Count().ShouldEqual(3);
    }
}
