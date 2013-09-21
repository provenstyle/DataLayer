using System.Configuration;

namespace ProvenStyle.DataIntegrationTests
{
    public class ConnectionString
    {
        public static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DataLayer"].ConnectionString;
            return connectionString;
        }
    }
}