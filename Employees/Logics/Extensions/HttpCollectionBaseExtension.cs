using Employees.Database.Tables;
using Employees.Services;
using System.Collections.Generic;
using System.Web;

namespace Employees.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class HttpCollectionBaseExtension
    {
        /// <summary>
        /// Read file and import records to Database
        /// </summary>
        /// <param name="fileCollection">Request files collection</param>
        /// <param name="importService">Import files to datatable type</param>
        /// <param name="employeeService">DbContext crud interface for add to database</param>
        /// <returns>Returns result of import process</returns>
        public static string ImportFilesToDatabase(this HttpFileCollectionBase fileCollection, IEmployeeImportService importService,
                                        IEmployeeService employeeService)
        {
            var employees = new List<Employee>();
            for (int i = 0; i < fileCollection.Count; i++)
            {
                employees = importService.Import(fileCollection[i].InputStream);
                employeeService.AddOrEdit(employees);
            }

            return OnImported(employees.Count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="importedFileCount"></param>
        private static string OnImported(int importedFileCount)
        {
            if (importedFileCount > 0)
                return $"Successfully imported {importedFileCount} records";
            else
                return "File is empty";
        }
    }
}