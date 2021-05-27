using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    /// <summary>
    /// Contains common methods that are used across the different DAO implementations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDAO<T>
    {
        /// <summary>
        /// Get a list of all the items in the table.
        /// </summary>
        /// <returns>List of the <typeparamref name="T"/></returns>
        /// <remarks>Yannick, 2020/05/10</remarks>
        List<T> GetAll();

        /// <summary>
        /// Get a item by the ID.
        /// </summary>
        /// <param name="id">The ID of the item.</param>
        /// <returns>The item that matches the ID.</returns>
        /// <remarks>Yannick, 2020/05/20</remarks>
        T GetById(int id);

        /// <summary>
        /// Store a item in a table.
        /// </summary>
        /// <param name="item">The item to store.</param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        void Store(T item);

        /// <summary>
        /// Update a record of a table.
        /// </summary>
        /// <param name="item">The updated item.</param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        void Update(T item);
    }
}
