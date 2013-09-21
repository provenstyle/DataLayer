using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Highway.Data;
using Machine.Specifications;
using Moq;

namespace DataTests
{
    public class with_mock_data
    {
        public static Mock<IDataContext> DataContext;
        public static Repository Repository;

        private Establish context = () =>
            {
                DataContext = new Mock<IDataContext>();
                Repository = new Repository(DataContext.Object);
            };

        public static void MockDataContext<T>(List<T> data) where T : class 
        {            
            DataContext.Setup(x => x.AsQueryable<T>()).Returns(data.AsQueryable);
        }
        
    }
}
