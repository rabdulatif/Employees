using Employees.Database.Tables;

namespace Employees.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEmployeeService : IBaseReadService<Employee>, IBaseAddOrEditService<Employee>,
                                        IBaseRemoveService<Employee>
    {
    }
}
