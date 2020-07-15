using System;

namespace Employees.Services
{
    /// <summary>
    /// Base Remove generic service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRemoveService<T> where T:class
    {
        /// <summary>
        /// Base remove logic
        /// </summary>
        void Remove(T obj);

        /// <summary>
        /// Base remove logic
        /// </summary>
        void Remove(Guid guid);
    }
}
