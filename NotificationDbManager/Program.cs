using DbUp;
using System;
using System.Reflection;

namespace NotificationDbManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Server=192.168.0.29,1433;Database=master;User Id=SA;Password=Stelios!!!!1111;";
            EnsureDatabase.For.SqlDatabase(connectionString); //Creates database if not 
            var upgradeEngineBuilder = DeployChanges.To
                            .SqlDatabase(connectionString)
                            .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                            .WithTransaction()
                            .LogToConsole();

            var upgrader = upgradeEngineBuilder.Build();
            if (upgrader.IsUpgradeRequired()) upgrader.PerformUpgrade();
            Console.WriteLine("Hello World!");
        }
    }
}
