using System.Collections.Generic;

namespace Employees.Services
{
    /// <summary>
    /// Base Add or Edit generic service
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseAddOrEditService<T> where T : class
    {
        /// <summary>
        /// Base Add or Edit logic
        /// </summary>
        /// <param name="obj"></param>
        void AddOrEdit(T obj);

        /// <summary>
        /// Add or edit 2 or more objects
        /// </summary>
        /// <param name="obj"></param>
        void AddOrEdit(List<T> obj);
    }
}
