using Employees.Database.Tables;
using Employees.Migrations;
using System.Data.Entity;

namespace Employees.Database
{
    /// <summary>
    /// Employees Database context
    /// </summary>
    public class EmployeeContext : DbContext
    {
        /// <summary>
        /// ctor initialize database migration
        /// </summary>
        public EmployeeContext() : base("name=EmployeesDB")
        {
            System.Data.Entity.Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeContext, Configuration>());
        }

        /// <summary>
        /// Table Employee
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
    }
}