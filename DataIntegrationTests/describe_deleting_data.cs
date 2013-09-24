using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Machine.Specifications;
using ProvenStyle.Data;
using ProvenStyle.Data.Commands;
using ProvenStyle.Entities;

namespace ProvenStyle.DataIntegrationTests
{

   [Subject("Subject Deleteing Records")]
   public class when_deleting_records : with_container
   {
      private static List<Person> _people;
      private static Person _bob;

      private Establish context = () => Factory.WithRepository(r =>
         {
            _bob = new Person("Bob", "Wiley");
            r.Context.Add(_bob);
            r.Context.Commit();
         });

      private Because of = () =>
         {
            Factory.WithRepository(r => r.Execute(new DeletePerson(_bob.Id)));

            Factory.WithRepository(r =>
               {
                  _people = r.Find(new PeopleByFirstName("Bob")).ToList();
               });
         };

      private It should_delete_the_record = () => _people.Count.ShouldEqual(0);
   }

   public class when_deleting_record_that_does_not_exist : with_container
   {
      private static List<Person> _people;            

      private Because of = () =>
      {
         Factory.WithRepository(r => r.Execute(new DeletePerson(1)));

         Factory.WithRepository(r =>
         {
            _people = r.Find(new PeopleByFirstName("Bob")).ToList();
         });
      };

      private It should_not_throw_and_exception = () => _people.Count.ShouldEqual(0);
   }
}
