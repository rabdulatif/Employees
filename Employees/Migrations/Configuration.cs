using System.Data.Entity.Migrations;

namespace Employees.Migrations
{
    /// <summary>
    /// Database Migration configuration file
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<Database.EmployeeContext>
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Employees.Database.EmployeeContext";
        }
    }
}
