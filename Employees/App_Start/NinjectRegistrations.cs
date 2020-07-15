using Employees.Services;
using Ninject.Modules;

namespace Employees.App_Start
{
    /// <summary>
    /// 
    /// </summary>
    public class NinjectRegistrations : NinjectModule
    {
        /// <summary>
        /// 
        /// </summary>
        public override void Load()
        {
            Bind<IEmployeeService>().To<EmployeeService>();
            Bind<IEmployeeImportService>().To<EmployeeImportService>();
        }
    }
}