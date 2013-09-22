using System;
using System.Configuration;
using ProvenStyle.Data;

namespace ProvenStyle.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {            
            var manager = new DatabaseManager("DataLayer");
            manager.DropCreateDatabase();
            Console.WriteLine("Database exists: {0}", manager.ConnectionString);
        }
    }
}
