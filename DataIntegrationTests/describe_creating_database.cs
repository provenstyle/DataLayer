using System.Configuration;
using Machine.Specifications;
using ProvenStyle.DatabaseManager;

namespace ProvenStyle.DataIntegrationTests
{
    [Subject("Creating a database")]
    public class can_create_a_database_without_a_reference_to_entity_framework
    {
        private static DatabaseCreator _databaseCreator;

        private Establish establish = () =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DataIntegrationTests"].ConnectionString;
                _databaseCreator = new DatabaseCreator(connectionString);
            };

        private Because of_creating_the_database = () => _databaseCreator.DropCreateDatabase();

        private It database_should_exist = () => _databaseCreator.DatabaseExists().ShouldBeTrue();
    }
}
