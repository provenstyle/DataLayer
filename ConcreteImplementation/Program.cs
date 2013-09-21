using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProvenStyle.DatabaseManager;

namespace ConcreteImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            var cn = ConfigurationManager.ConnectionStrings["ConcreteImplementation"].ConnectionString;
            var manager = new DatabaseCreator(cn);
            manager.DropCreateDatabase();
            Console.WriteLine("Database exists: {0}", cn);

            

        }
    }
}
