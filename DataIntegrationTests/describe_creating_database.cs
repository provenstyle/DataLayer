using System.Configuration;
using Machine.Specifications;
using ProvenStyle.Data;

namespace ProvenStyle.DataIntegrationTests
{
    [Subject("Creating a database")]
    public class can_create_a_database_without_a_reference_to_entity_framework
    {
        private static DatabaseManager _databaseManager;

        private Establish context = () => _databaseManager = new DatabaseManager(Constants.ConnectionName);

        private Because of_creating_the_database = () => _databaseManager.DropCreateDatabase();

        private It should_create_the_database = () => _databaseManager.DatabaseExists().ShouldBeTrue();
    }
}
