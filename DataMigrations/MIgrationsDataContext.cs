using Common.Logging;
using Highway.Data;

namespace DataMigrations
{
    public class MigrationsDataContext : DataContext
    {
        public MigrationsDataContext(string connectionString, IMappingConfiguration mapping) : base(connectionString, mapping)
        {
        }

        public MigrationsDataContext(string connectionString, IMappingConfiguration mapping, ILog log) : base(connectionString, mapping, log)
        {
        }

        public MigrationsDataContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration) : base(connectionString, mapping, contextConfiguration)
        {
        }

        public MigrationsDataContext(string connectionString, IMappingConfiguration mapping, IContextConfiguration contextConfiguration, ILog log) : base(connectionString, mapping, contextConfiguration, log)
        {
        }

        public MigrationsDataContext(string databaseFirstConnectionString) : base(databaseFirstConnectionString)
        {
        }

        public MigrationsDataContext(string databaseFirstConnectionString, ILog log) : base(databaseFirstConnectionString, log)
        {
        }
    }
}
