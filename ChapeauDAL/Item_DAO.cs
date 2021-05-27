using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    /// <summary>
    /// The DAL layer implementations for getting MenuItems from the database.
    /// </summary>
    /// <remarks>Yannick</remarks>
    public class Item_DAO : SqlBase, IDAO<MenuItem>
    {
        /// <summary>
        /// Get all menu items from the database.
        /// </summary>
        /// <returns></returns>
        public List<MenuItem> GetAll()
        {
            string query =
                @"SELECT
                    item_id,
                    items.name AS [name],
                    stock,
                    price,
                    menus.menu_id AS menu_id,
                    menus.name AS menu_name,
                    start_time,
                    end_time,
                    tax_category_id,
                    tax_categories.name AS category_name,
                    vat_percentage,
                    categories.[category_id] AS menu_category_id,
                    categories.[name] AS menu_category_name
                FROM items
                INNER JOIN menus ON menus.menu_id = items.menu_id
                INNER JOIN tax_categories ON tax_categories.tax_category_id = items.tax_category
                INNER JOIN categories ON items.category = categories.category_id;";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ParseDataTable(Query(query, sqlParameters));
        }

        public MenuItem GetById(int id)
        {
            string query =
                    @"SELECT
                        item_id,
                        items.name AS [name],
                        stock,
                        price,
                        menus.menu_id AS menu_id,
                        menus.name AS menu_name,
                        start_time,
                        end_time,
                        tax_category_id,
                        tax_categories.name AS category_name,
                        vat_percentage,
                        categories.[category_id] AS menu_category_id,
                        categories.[name] AS menu_category_name
                    FROM items
                    INNER JOIN menus ON menus.menu_id = items.menu_id
                    INNER JOIN tax_categories ON tax_categories.tax_category_id = items.tax_category
                    INNER JOIN categories ON items.category = categories.category_id
                    WHERE item_id = @id;";
            SqlParameter[] sqlParameters =
{
                new SqlParameter("@id", id)
            };
            return ParseDataTable(Query(query, sqlParameters))[0];
        }

        /// <summary>
        /// Get all the menu items that belong to a certain menu. (Lunch, Dinner, Drinks)
        /// </summary>
        /// <param name="menuId">The ID of the menu to get the items from.</param>
        /// <returns>A list of MenuItems that belong to the menu.</returns>
        public List<MenuItem> GetByMenuId(int menuId)
        {
            string query =
                @"SELECT
                    item_id,
                    items.name AS [name],
                    stock,
                    price,
                    menus.menu_id AS menu_id,
                    menus.name AS menu_name,
                    start_time,
                    end_time,
                    tax_category_id,
                    tax_categories.name AS category_name,
                    vat_percentage,
                    categories.[category_id] AS menu_category_id,
                    categories.[name] AS menu_category_name
                FROM items
                INNER JOIN menus ON menus.menu_id = items.menu_id
                INNER JOIN tax_categories ON tax_categories.tax_category_id = items.tax_category
                INNER JOIN categories ON items.category = categories.category_id
                WHERE menus.menu_id = @menuId;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@menuId", menuId)
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get all the menu items that belong to a menu/sub category.
        /// </summary>
        /// <param name="categoryId">The ID of the menu category.</param>
        /// <returns>A list of menu items that belong to the menu category.</returns>
        public List<MenuItem> GetByMenuCategoryId(int categoryId)
        {
            string query =
                @"SELECT
                    item_id,
                    items.name AS [name],
                    stock,
                    price,
                    menus.menu_id AS menu_id,
                    menus.name AS menu_name,
                    start_time,
                    end_time,
                    tax_category_id,
                    tax_categories.name AS category_name,
                    vat_percentage,
                    categories.[category_id] AS menu_category_id,
                    categories.[name] AS menu_category_name
                FROM items
                INNER JOIN menus ON menus.menu_id = items.menu_id
                INNER JOIN tax_categories ON tax_categories.tax_category_id = items.tax_category
                INNER JOIN categories ON items.category = categories.category_id
                WHERE categories.category_id = @categoryId;";

            SqlParameter[] sqlParameters =
           {
                new SqlParameter("@categoryId", categoryId)
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        public void DeleteById(int id)
        {
            string query =
                @"DELETE FROM items
                  WHERE [item_id] = @id;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@id", id),
            };

            EditQuery(query, sqlParameters);
        }

        public void Store(MenuItem item)
        {
            string query =
                @"INSERT INTO items([name], [stock], [price], [menu_id], [tax_category], [category])
                    VALUES (@name, @stock, @price,
                        (SELECT [menu_id] 
                        FROM categories 
                        WHERE [name] = @category),
                        @taxcategory,
                        (SELECT [category_id] 
                        FROM categories 
                        WHERE [name] = @category));";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@name", item.Name),
                new SqlParameter("@stock", item.Stock),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@category", item.Category.Name),
                new SqlParameter("@taxcategory", item.TaxCategory.Id),
            };

            EditQuery(query, sqlParameters);
        }

        public void Update(MenuItem item)
        {
            string query =
                @"UPDATE dbo.items
                    SET
                    [name] = @name, 
                    [stock] = @stock, 
                    [price] = @price, 
                    [menu_id] = @menu, 
                    [tax_category] = @taxCategory,
                    [category] = (SELECT [category_id] FROM categories WHERE [name] = @menuCategory)
                    WHERE [item_id] = @id;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@name", item.Name),
                new SqlParameter("@stock", item.Stock),
                new SqlParameter("@price", item.Price),
                new SqlParameter("@menu", item.Menu.Id),
                new SqlParameter("@taxCategory", item.TaxCategory.Id),
                new SqlParameter("@menuCategory", item.Category.Name),
                new SqlParameter("@id", item.Id),
            };

            EditQuery(query, sqlParameters);
        }

        /// <summary>
        /// Converts a data table into a list of menu items
        /// </summary>
        /// <param name="dataTable">The data table that should be parsed.</param>
        /// <returns>An list of menu items.</returns>
        /// <remarks>Yannick</remarks>
        private List<MenuItem> ParseDataTable(DataTable dataTable)
        {
            List<MenuItem> items = new List<MenuItem>();

            // If the data table is null, then something went wrong in the SQL statement.
            if (dataTable == null)
            {
                throw new DatatableIsNullException("ParseDataTable was given a null value for dataTable in Item_DAO.", new Exception());
            }

            foreach (DataRow row in dataTable.Rows)
            {
                items.Add(RowToItem(row));
            }

            return items;
        }

        /// <summary>
        /// Converts a DataRow into an MenuItem.
        /// </summary>
        /// <param name="row">The DataRow to parse.</param>
        /// <returns>The parsed DataRow as a MenuItem.</returns>
        private MenuItem RowToItem(DataRow row)
        {
            Menu menu = new Menu()
            {
                Id = (int)row["menu_id"],
                Name = (string)row["menu_name"],
                StartTime = (TimeSpan)row["start_time"],
                EndTime = (TimeSpan)row["end_time"]
            };
            MenuCategory menuCategory = new MenuCategory()
            {
                Id = (int)row["menu_category_id"],
                Name = (string)row["menu_category_name"],
            };

            TaxCategory taxCategory = new TaxCategory()
            {
                Id = (int)row["tax_category_id"],
                Name = (string)row["category_name"],
                VAT = (int)row["vat_percentage"]
            };

            MenuItem item = new MenuItem()
            {
                Id = (int)row["item_id"],
                Name = (string)row["name"],
                Stock = (int)row["stock"],
                Price = (decimal)row["price"],
                Menu = menu,
                TaxCategory = taxCategory,
                Category = menuCategory
            };

            return item;
        }
    }
}
