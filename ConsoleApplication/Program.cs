using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Castle.Facilities.TypedFactory;
using ProvenStyle.Data;
using ProvenStyle.Entities;

namespace ProvenStyle.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new DatabaseManager("DataLayer");
            manager.DropCreateDatabase();

            var container = new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(new DataInstaller());

            var repositoryFactory = container.Resolve<IRepositoryFactory>();

            repositoryFactory.WithRepository(r =>
                                                 {
                                                     r.Context.Add(new Person("Richard", "Castle"));
                                                     r.Context.Add(new Person("Kate", "Becket"));
                                                     r.Context.Add(new Person("Nikki", "Heat"));
                                                     r.Context.Add(new Person("Derrick", "Storm"));
                                                     r.Context.Add(new Person("Richard", "Nixon"));
                                                     r.Context.Commit();
                                                 });

            var richards = new List<Person>();
            repositoryFactory.WithRepository(r =>
                                                 {
                                                     richards = r.Find(new PeopleByFirstName("Richard")).ToList();
                                                 });

            Console.WriteLine("People named Richard");
            richards.ForEach(r=>Console.WriteLine("{0} {1}", r.FirstName, r.LastName));
            

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
