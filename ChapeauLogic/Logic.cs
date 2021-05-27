using System;
using System.Collections.Generic;

using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    /// <summary>
    /// Common Logic layer implementations across the different service layers.
    /// </summary>
    /// <typeparam name="T">The return types that are expected from the DAL layer. (ex: Menu)</typeparam>
    /// <remarks>Yannick</remarks>
    public abstract class Logic<T>
    {
        /// <summary>
        /// A DAL layer class, this will be used to get data from the DAL layer.
        /// </summary>
        protected IDAO<T> db;

        /// <summary>
        /// Get all the items in the database table.
        /// </summary>
        /// <returns>A list of items of the <typeparamref name="T"/> type.</returns>
        public List<T> GetAll()
        {
            try
            {
                return db.GetAll();
            }
            catch (Exception error)
            {
                throw new Exception("We're sorry, it seems like the system was unable to load the requested data.", error);
            }
        }

        /// <summary>
        /// Get a single item that has a given ID.
        /// </summary>
        /// <param name="id">The ID of the item you are trying to get.</param>
        /// <returns>A single item of the <typeparamref name="T"/> type.</returns>
        public T GetById(int id)
        {
            try
            {
                return db.GetById(id);
            }
            catch (Exception error)
            {
                throw new Exception("We're sorry, it seems like the system was unable to load the requested data.", error);
            }
        }

        /// <summary>
        /// Store an item to the database.
        /// </summary>
        /// <param name="item">The item to store into the database. Of the <typeparamref name="T"/> type.</param>
        public void Store(T item)
        {
            try
            {
                db.Store(item);
            }
            catch (OutOfStockException error)
            {
                throw error;
            }
            catch (Exception error)
            {
                throw new Exception("We're sorry, it seems like the system was unable to store the given item.", error);
            }
        }

        /// <summary>
        /// Update an given item in the database.
        /// </summary>
        /// <param name="item">The item to update, of the <typeparamref name="T"/> type.</param>
        public void Update(T item)
        {
            try
            {
               db.Update(item);
            }
            catch (Exception error)
            {
                throw new Exception("We're sorry, it seems like the system was unable to update the given item.", error);
            }
        }
    }
}
