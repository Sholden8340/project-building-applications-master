using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using ChapeauModel;

namespace ChapeauDAL
{
    /// <summary>
    /// The DAL layer for the Menu area of the application.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class Menu_DAO : SqlBase, IDAO<Menu>
    {
        /// <summary>
        /// Get a list of all menus.
        /// </summary>
        /// <returns>An list of all the menus.</returns>
        /// <remarks>Yannick</remarks>
        public List<Menu> GetAll()
        {
            string query =
                @"SELECT
                    menus.menu_id AS menu_id,
                    menus.[name] AS name,
                    start_time,
                    end_time,
                    category_id,
                    categories.[name] AS category_name
                FROM menus
                INNER JOIN categories ON menus.menu_id = categories.menu_id;";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get a menu by a specific menu ID.
        /// </summary>
        /// <param name="id">The ID of the menu.</param>
        /// <returns>A single menu.</returns>
        /// <remarks>Yannick</remarks>
        public Menu GetById(int id)
        {
            string query =
                @"SELECT
                    menus.menu_id AS menu_id,
                    menus.[name] AS name,
                    start_time,
                    end_time,
                    category_id,
                    categories.[name] AS category_name
                FROM menus
                INNER JOIN categories ON menus.menu_id = categories.menu_id
                WHERE menus.menu_id = @menuId;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@menuId", id)
            };

            return ParseDataTable(Query(query, sqlParameters))[0];
        }

        public void Store(Menu menu)
        {
            throw new NotImplementedException();
        }

        public void Update(Menu menu)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Converts a data table into a list of menus
        /// </summary>
        /// <param name="dataTable">The data table that should be parsed.</param>
        /// <returns>An list of menus.</returns>
        /// <remarks>Yannick</remarks>
        private List<Menu> ParseDataTable(DataTable dataTable)
        {
            List<Menu> menus = new List<Menu>();

            foreach (DataRow row in dataTable.Rows)
            {
                bool exists = false;

                for (int i = 0; i < menus.Count; i++)
                {
                    if (menus[i].Id == (int)row["menu_id"])
                    {
                        MenuCategory menuCategory = RowToMenuCategory(row);

                        menus[i].MenuCategories.Add(menuCategory);

                        exists = true;
                        continue;
                    }
                }

                if (!exists)
                {
                    menus.Add(RowToMenu(row));
                }
            }

            return menus;
        }

        /// <summary>
        /// Converts a DataRow into an Menu.
        /// </summary>
        /// <param name="row">The DataRow to parse.</param>
        /// <returns>The parsed DataRow as a Menu.</returns>
        /// <remarks>Yannick</remarks>
        private Menu RowToMenu(DataRow row)
        {
            Menu menu = new Menu()
            {
                Id = (int)row["menu_id"],
                Name = (string)row["name"],
                StartTime = (TimeSpan)row["start_time"],
                EndTime = (TimeSpan)row["end_time"],
                MenuCategories = new List<MenuCategory>()
                {
                    RowToMenuCategory(row)
                }
            };

            return menu;
        }

        /// <summary>
        /// Convert a DataRow to a MenuCategory.
        /// </summary>
        /// <param name="row">The DataRow to parse.</param>
        /// <returns>The parsed DataRow as a MenuCategory.</returns>
        /// <remarks>Yannick</remarks>
        private MenuCategory RowToMenuCategory(DataRow row)
        {
            MenuCategory menuCategory = new MenuCategory()
            {
                Id = (int)row["category_id"],
                Name = (string)row["category_name"]
            };

            return menuCategory;
        }
    }
}
