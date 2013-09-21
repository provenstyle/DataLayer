using System;
using System.Configuration;
using ProvenStyle.DatabaseManager;

namespace ProvenStyle.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var cn = ConfigurationManager.ConnectionStrings["ConsoleApplication"].ConnectionString;
            var manager = new DatabaseCreator(cn);
            manager.DropCreateDatabase();
            Console.WriteLine("Database exists: {0}", cn);
        }
    }
}
