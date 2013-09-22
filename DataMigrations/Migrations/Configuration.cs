namespace DataMigrations.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ProvenStyle.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<DataMigrations.MigrationsDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataMigrations.MigrationsDataContext context)
        {
            //SeedPersonData(context);

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        private static void SeedPersonData(MigrationsDataContext context)
        {
            context.Add(new Person("Richard", "Castle"));
            context.Add(new Person("Kate", "Becket"));
            context.Add(new Person("Nikki", "Heat"));
            context.Add(new Person("Derrick", "Storm"));
            context.Add(new Person("Richard", "Nixon"));
            context.Commit();
        }
    }
}
