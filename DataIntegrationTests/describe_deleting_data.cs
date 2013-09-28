using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using ProvenStyle.Data;
using ProvenStyle.Data.Commands;
using ProvenStyle.Entities;

namespace ProvenStyle.DataIntegrationTests
{
    // ReSharper disable InconsistentNaming

    [Subject(Constants.DeletingRecords)]
    public class when_deleting_records : with_delete
    {                        
        Because of = () =>
           {
               Factory.WithRepository(r => r.Execute(new DeletePerson(Bob.Id)));

               Factory.WithRepository(r =>
                  {
                      People = r.Find(new PeopleByFirstName("Bob")).ToList();
                  });
           };

        It should_delete_the_record = () => People.Count.ShouldEqual(0);
    }

    [Subject(Constants.DeletingRecords)]
    public class when_deleting_record_that_does_not_exist : with_delete
    {
        Because of = () =>
        {
            Factory.WithRepository(r => r.Execute(new DeletePerson(10)));

            Factory.WithRepository(r =>
            {
                People = r.Find(new PeopleByFirstName("Bob")).ToList();
            });
        };

        It should_not_throw_and_exception = () => People.Count.ShouldEqual(1);
    }

    [Subject(Constants.DeletingRecords)]
    public class when_deleting_using_an_advanced_command : with_delete
    {        
        Because of = () =>
            {
                Factory.WithRepository(r => r.Execute(new DeletePersonAdvancedCommand(Bob.Id)));

                Factory.WithRepository(r =>
                    {
                        People = r.Find(new PeopleByFirstName("Bob")).ToList();
                    });
                
            };

        It should_delete_record = () => People.Count.ShouldEqual(0);
    }

    public class with_delete : with_container
    {
        protected static List<Person> People;
        protected static Person Bob;

        Establish context = () => Factory.WithRepository(r =>
        {
            Bob = new Person("Bob", "Wiley");
            r.Context.Add(Bob);
            r.Context.Commit();
        });
    }
}
