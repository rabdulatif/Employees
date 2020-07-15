using System;
using System.Collections.Generic;

namespace Employees.Services
{
    /// <summary>
    /// Base Read generic service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseReadService<T> where T : class
    {
        /// <summary>
        /// Get all objects
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> Read();

        /// <summary>
        /// Get object by given Guid
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        T Read(Guid guid);
    }
}
