using Highway.Data;

namespace ProvenStyle.Data
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager(string connectionString)
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