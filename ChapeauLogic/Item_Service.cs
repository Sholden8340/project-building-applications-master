using System.Collections.Generic;

using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    /// <summary>
    /// The logic layer for getting items from the DAL layer.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class Item_Service : Logic<MenuItem>
    {
        public Item_Service()
        {
            db = new Item_DAO();
        }

        /// <summary>
        /// Get all menu items that belong to a certain menu.
        /// </summary>
        /// <param name="id">The ID of the menu.</param>
        /// <returns>A list of menu items that belong to the menu.</returns>
        public List<MenuItem> GetByMenuId(int id)
        {
            Item_DAO itemDB = (Item_DAO)db;
            return itemDB.GetByMenuId(id);
        }

        /// <summary>
        /// Get all menu items that belong to a certain menu category.
        /// </summary>
        /// <param name="id">The ID of the MenuCategory.</param>
        /// <returns>A list of menu items that belong to the menu category.</returns>
        public List<MenuItem> GetByMenuCategoryId(int id)
        {
            Item_DAO itemDB = (Item_DAO)db;
            return itemDB.GetByMenuCategoryId(id);
        }

        public void UpdateItem(MenuItem item)
        {
            Item_DAO itemDB = (Item_DAO)db;
            itemDB.Update(item);
        }

        public void RemoveItem(int id)
        {
            Item_DAO itemDB = (Item_DAO)db;
            itemDB.DeleteById(id);
        }

        public MenuItem GetByMenuItemId(int id)
        {
            Item_DAO itemDB = (Item_DAO)db;
            return itemDB.GetById(id);
        }
    }
}
