﻿using System;
using System.Configuration;
using ProvenStyle.Data;

namespace ProvenStyle.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var cn = ConfigurationManager.ConnectionStrings["DataLayer"].ConnectionString;
            var manager = new DatabaseManager(cn);
            manager.DropCreateDatabase();
            Console.WriteLine("Database exists: {0}", cn);
        }
    }
}
