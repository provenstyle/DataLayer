using System.Configuration;
using Machine.Specifications;
using ProvenStyle.DatabaseManager;

namespace ProvenStyle.DataIntegrationTests
{
    [Subject("Creating a database")]
    public class can_create_a_database_without_a_reference_to_entity_framework
    {
        private static DatabaseCreator _databaseCreator;

        private Establish context = () => _databaseCreator = new DatabaseCreator(ConnectionString.GetConnectionString());

        private Because of_creating_the_database = () => _databaseCreator.DropCreateDatabase();

        private It should_create_the_database = () => _databaseCreator.DatabaseExists().ShouldBeTrue();
    }
}
