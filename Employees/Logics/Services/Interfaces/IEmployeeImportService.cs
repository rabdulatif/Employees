using Employees.Database.Tables;
using System.Collections.Generic;
using System.IO;

namespace Employees.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeImportService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        List<Employee> Import(Stream stream);
    }
}
