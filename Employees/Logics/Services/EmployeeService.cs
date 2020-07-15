using Employees.Database;
using Employees.Database.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Employees.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        /// <summary>
        /// 
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        /// 
        /// </summary>
        private static EmployeeContext _context;

        /// <summary>
        /// 
        /// </summary>
        public EmployeeService()
        {
            if (_context == null)
            {
                lock (_lock)
                {
                    if (_context == null)
                        _context = new EmployeeContext();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public EmployeeService(EmployeeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Gets Employees from Database
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> Read()
        {
            return _context.Employees.OrderBy(s => s.Surname);
        }

        /// <summary>
        /// Get Employee by given Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public Employee Read(Guid guid)
        {
            if (guid == Guid.Empty)
                return null;
            return _context.Employees.FirstOrDefault(s => s.EmployeeGuid == guid);
        }

        /// <summary>
        /// Add or edit 2 or more objects
        /// </summary>
        /// <param name="obj"></param>
        public void AddOrEdit(List<Employee> obj)
        {
            foreach (var item in obj)
            {
                AddOrEdit(item);
            }
        }

        /// <summary>
        /// Add Employee to database if not exists else update given Employee
        /// </summary>
        /// <param name="obj"></param>
        public void AddOrEdit(Employee obj)
        {
            var emp = _context.Employees.FirstOrDefault(s => s.EmployeeGuid == obj.EmployeeGuid 
                                                          || s.PayrollNumber==obj.PayrollNumber);
            if (emp == null)
                InternalAddEmployee(obj);
            else
                InternalEditEmployee(emp, obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void InternalAddEmployee(Employee obj)
        {
            _context.Employees.Add(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void InternalEditEmployee(Employee oldObj, Employee newObj)
        {
            oldObj.PayrollNumber = newObj.PayrollNumber;
            oldObj.Surname = newObj.Surname;
            oldObj.Forenames = newObj.Forenames;
            oldObj.DateOfBirth = newObj.DateOfBirth;
            oldObj.Telephone = newObj.Telephone;
            oldObj.Mobile = newObj.Mobile;
            oldObj.Address = newObj.Address;
            oldObj.Address2 = newObj.Address2;
            oldObj.PostCode = newObj.PostCode;
            oldObj.Email = newObj.Email;
            oldObj.StartDate = newObj.StartDate;
            
            _context.Entry(oldObj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Remove(Employee obj)
        {
            if (_context.Employees.Contains(obj))
                _context.Employees.Remove(obj);
            _context.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guid"></param>
        public void Remove(Guid guid)
        {
            var emp = Read(guid);
            if (emp != null)
                _context.Employees.Remove(emp);
            _context.SaveChanges();
        }

    }
}