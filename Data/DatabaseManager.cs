using System.Configuration;
using Highway.Data;

namespace ProvenStyle.Data
{
    public class DatabaseManager
    {
        private readonly string _connectionName;

        public DatabaseManager(string connectionName)
        {
            _connectionName = connectionName;
        }

        public string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings[_connectionName].ConnectionString; }
        }

        public void DropCreateDatabase()
        {
            var dataContext = CreateDataContext();
            if (dataContext.Database.Exists())
                dataContext.Database.Delete();
            dataContext.Database.Create();
        }

        public void CreateDatabaseIfNotExists()
        {
            var dataContext = CreateDataContext();
            if (!dataContext.Database.Exists())
                dataContext.Database.Create();
        }

        public bool DatabaseExists()
        {
            return CreateDataContext().Database.Exists();
        }

        public IRepository GetRepository()
        {
            return new Repository(CreateDataContext());
        }

        public DataContext CreateDataContext()
        {
            IMappingConfiguration mapping = new DataMappingConfiguration();
            var dataContext = new DataContext(ConnectionString, mapping);
            return dataContext;
        }
    }
}