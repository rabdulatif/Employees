using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using Employees.Database;
using Employees.Database.Tables;
using Employees.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Employees.Test.Logics.Services
{
    /// <summary>
    /// 
    /// </summary>
    [TestClass]
    public class EmployeeServiceTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Get_Employees_Test()
        {
            var mockContext = GetMockContext();

            var service = new EmployeeService(mockContext.Object);
            var employees = service.Read().ToList();

            Assert.AreEqual(2, employees.Count);
            Assert.AreEqual("CS1111", employees[0].PayrollNumber);
            Assert.AreEqual("CS2222", employees[1].PayrollNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Get_EmployeeByGuid_Test()
        {
            var mockContext = GetMockContext();

            var service = new EmployeeService(mockContext.Object);
            var employee = service.Read(Guid.Parse("E8172BB7-F014-4912-A244-4B336BB170CB"));

            Assert.IsNotNull(employee);
            Assert.AreEqual("CS1111", employee.PayrollNumber);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void AddOrEdit_Employee_Test()
        {
            var mockContext = GetMockContext();

            var service = new EmployeeService(mockContext.Object);
            var newEmployee = new Employee
            {
                EmployeeGuid = Guid.Parse("FE1D5C82-5E93-4821-86CA-A023D6DC4208"),
                PayrollNumber = "CS3333",
                Forenames = "TestForenames3",
                Surname = "TestSurname3",
                DateOfBirth = DateTime.ParseExact("25/01/1999", "dd/mm/yyyy", CultureInfo.InvariantCulture),
                Mobile = "998988888888",
                Telephone = "998977777777",
                Address = "TestAddress3  143",
                Address2 = "Tashkent",
                Email = "testmail3@mail.com",
                PostCode = "100343",
                StartDate = DateTime.ParseExact("12/03/2000", "dd/mm/yyyy", CultureInfo.InvariantCulture)
            };

            service.AddOrEdit(newEmployee);
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        [Ignore]
        public void AddOrEdit_Employees_Test()
        {
            var mockContext = GetMockContext();

            var service = new EmployeeService(mockContext.Object);
            var employees = EmployeesList();
            try
            {
                service.AddOrEdit(employees);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void Remove_Employee_Test()
        {
            var mockContext = GetMockContext();

            var service = new EmployeeService(mockContext.Object);
            var employee = EmployeesList()[0];

            service.Remove(employee);
        }

        /// <summary>
        /// Return Mock DbContext
        /// </summary>
        /// <param name="mockSet"></param>
        /// <returns></returns>
        private Mock<EmployeeContext> GetMockContext()
        {
            var data = EmployeesList().AsQueryable();

            var mockSet = new Mock<DbSet<Employee>>();
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Employee>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockContext = new Mock<EmployeeContext>();
            mockContext.Setup(s => s.Set<Employee>()).Returns(mockSet.Object);

            return mockContext;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Employee> EmployeesList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    EmployeeGuid = Guid.Parse("E8172BB7-F014-4912-A244-4B336BB170CB"),
                    PayrollNumber = "CS1111",
                    Forenames="TestForenames",
                    Surname="TestSurname",
                    DateOfBirth = DateTime.ParseExact("25/11/1988","dd/mm/yyyy",CultureInfo.InvariantCulture),
                    Mobile = "993546468",
                    Telephone="554655445",
                    Address = "TestAddress  14",
                    Address2="Tashkent",
                    Email="testmail@mail.com",
                    PostCode="10034",
                    StartDate = DateTime.ParseExact("12/01/2000","dd/mm/yyyy",CultureInfo.InvariantCulture)
                },
                new Employee
                {
                    EmployeeGuid = Guid.Parse("E8172BB8-F034-4712-A244-4B336BB170CB"),
                    PayrollNumber = "CS2222",
                    Forenames="TestForenames2",
                    Surname="TestSurname2",
                    DateOfBirth = DateTime.ParseExact("22/12/1998","dd/mm/yyyy",CultureInfo.InvariantCulture),
                    Mobile = "963346462",
                    Telephone="544955145",
                    Address = "TestAddress  24",
                    Address2="Tashkent",
                    Email="testmail2@mail.com",
                    PostCode="10234",
                    StartDate = DateTime.ParseExact("12/01/2010","dd/mm/yyyy",CultureInfo.InvariantCulture)
                }
            };
        }

    }
}
