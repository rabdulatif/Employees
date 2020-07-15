using Employees.Database.Tables;
using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace Employees.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeImportService : IEmployeeImportService
    {
        List<Employee> EmployeeList = new List<Employee>();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Employee> Import(Stream stream)
        {
            try
            {
                InternalReadStream(stream);
            }
            catch (Exception ex)
            {
                throw;
            }

            return EmployeeList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        private void InternalReadStream(Stream stream)
        {
            using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
            {
                var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                {
                    ConfigureDataTable = _ => new ExcelDataTableConfiguration
                    {
                        UseHeaderRow = true
                    }
                });
                TransformToEmployee(dataSet);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataSet"></param>
        private void TransformToEmployee(DataSet dataSet)
        {
            if (dataSet.Tables.Count > 0)
            {
                var dataTable = dataSet.Tables[0];
                foreach (DataRow objDataRow in dataTable.Rows)
                {
                    if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                    EmployeeList.Add(new Employee()
                    {
                        EmployeeGuid = Guid.NewGuid(),
                        PayrollNumber = objDataRow["Personnel_Records.Payroll_Number"].ToString(),
                        Forenames = objDataRow["Personnel_Records.Forenames"].ToString(),
                        Surname = objDataRow["Personnel_Records.Surname"].ToString(),
                        DateOfBirth = DateTime.ParseExact(objDataRow["Personnel_Records.Date_of_Birth"].ToString(),
                        "dd/mm/yyyy", null),
                        Telephone = objDataRow["Personnel_Records.Telephone"].ToString(),
                        Mobile = objDataRow["Personnel_Records.Mobile"].ToString(),
                        Address = objDataRow["Personnel_Records.Address"].ToString(),
                        Address2 = objDataRow["Personnel_Records.Address_2"].ToString(),
                        PostCode = objDataRow["Personnel_Records.Postcode"].ToString(),
                        Email = objDataRow["Personnel_Records.EMail_Home"].ToString(),
                        StartDate = DateTime.ParseExact(objDataRow["Personnel_Records.Start_Date"].ToString(),
                        "dd/mm/yyyy", null)
                    });
                }
            }
        }
    }
}