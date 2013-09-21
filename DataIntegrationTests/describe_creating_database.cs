using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Highway.Data;

using Machine.Specifications;

namespace DataIntegrationTests
{
    [Subject("Creating a database")]
    public class spec
    {
        private static DataContext _dataContext;

        private Establish establish = () =>
            {
                var connectionString = ConfigurationManager.ConnectionStrings["DataIntegrationTests"].ConnectionString;
                IMappingConfiguration mapping = new DataMappingConfiguration();
                 _dataContext = new DataContext(connectionString, mapping);
                var repository = new Repository(_dataContext);
                _dataContext = repository.Context as DataContext;
                if (_dataContext.Database.Exists())
                    _dataContext.Database.Delete();
            };

        private Because of = () => _dataContext.Database.Create();

        private It should = () => _dataContext.Database.Exists().ShouldBeTrue();
    }
}
