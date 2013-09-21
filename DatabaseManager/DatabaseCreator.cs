using Data;
using Highway.Data;
using ProvenStyle.Data;

namespace ProvenStyle.DatabaseManager
{
    public class DatabaseCreator
    {
        private readonly string _connectionString;

        public DatabaseCreator(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void DropCreateDatabase()
        {
            var _dataContext = CreateDataContext();
            if (_dataContext.Database.Exists())
                _dataContext.Database.Delete();
            _dataContext.Database.Create();
        }

        public void CreateDatabaseIfNotExists()
        {
            var _dataContext = CreateDataContext();
            if (!_dataContext.Database.Exists())
                _dataContext.Database.Create();
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
            var _dataContext = new DataContext(_connectionString, mapping);
            return _dataContext;
        }
    }
}