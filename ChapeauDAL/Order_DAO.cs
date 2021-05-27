using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class Order_DAO : SqlBase, IDAO<Order>
    {
        /// <summary>
        /// The select statement for getting orders.
        /// We define this here to prevent writing the same code multiple times.
        /// </summary>
        /// <remarks>Yannick, 2020/06/08</remarks>
        private const string ORDERS_SELECT_QUERY =
            @"SELECT
                orders.order_id AS order_id,
                is_payed,
                order_item_id,
                orders_items.item_id AS item_id,
                items.name AS item_name,
                taken_at,
                price,
                tax_category_id,
                tax_categories.name AS tax_category_name,
                vat_percentage,
                orders_items.[state] AS [state],
                state_time,
                quantity,
                comment,
                stock,
                menus.menu_id AS menu_id,
                menus.name AS menu_name,
                start_time,
                end_time,
                categories.[category_id] AS menu_category_id,
                categories.[name] AS menu_category_name,
                tables.table_id AS table_id,
                tables.[state] AS table_state,
                employees.employee_id AS employee_id,
                employees.[first_name] AS [first_name],
                employees.[last_name] AS [last_name],
                employees.[password] AS [password],
                roles.[name] AS role
            FROM orders
            INNER JOIN orders_items ON orders.order_id = orders_items.order_id
            INNER JOIN items ON orders_items.item_id = items.item_id
            INNER JOIN menus ON menus.menu_id = items.menu_id
            INNER JOIN tax_categories ON tax_categories.tax_category_id = items.tax_category
            INNER JOIN categories ON items.category = categories.category_id
            INNER JOIN employees ON employees.employee_id = orders.employee_id
            INNER JOIN roles ON roles.role_id = employees.[role]
            INNER JOIN tables on tables.table_id = orders.table_id";

        /// <summary>
        /// Get a list of all orders.
        /// </summary>
        /// <returns>A list of all the orders.</returns>
        public List<Order> GetAll()
        {
            string query = ORDERS_SELECT_QUERY;

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get a specific order by their ID.
        /// </summary>
        /// <param name="id">The ID of the order.</param>
        /// <returns>The order that matches the parameter <paramref name="id"/>.</returns>
        public Order GetById(int id)
        {
            string query = $@"{ORDERS_SELECT_QUERY} WHERE orders.order_id = @orderId;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@orderId", id)
            };

            return ParseDataTable(Query(query, sqlParameters))[0];
        }

        /// <summary>
        /// Get all orders of today.
        /// </summary>
        /// <remarks>Stephem, 2020/06/10</remarks>
        public List<Order> GetAllToday()
        {
            string query = $@"{ORDERS_SELECT_QUERY} WHERE taken_at >= @today;";

            SqlParameter[] sqlParameters = 
            {
                new SqlParameter("@today", DateTime.Today)
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get a list of open orders.
        /// </summary>
        /// <returns>A list of all unpaid orders.</returns>
        /// <remarks>Yannick, 2020/05/21</remarks>
        public List<Order> GetOpenOrders()
        {
            string query = $@"{ORDERS_SELECT_QUERY} WHERE orders.is_payed = 0;";

            SqlParameter[] sqlParameters = new SqlParameter[0];

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get all open kitchen orders of today.
        /// </summary>
        /// <returns>A list of all open kitchen orders of today.</returns>
        public List<Order> GetAllOpenKitchenOrders()
        {
            string query =
                $@"{ORDERS_SELECT_QUERY}
                WHERE 
                    orders_items.[state] = 'Taken'
                    AND taken_at >= @today 
                    AND menus.menu_id != 2;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@today", DateTime.Today),
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get all open bar orders of today.
        /// </summary>
        /// <returns>A list of all open bar orders of today.</returns>
        public List<Order> GetAllOpenBarOrders()
        {
            string query =
                $@"{ORDERS_SELECT_QUERY}
                WHERE 
                    orders_items.[state] = 'Taken'
                    AND taken_at >= @today 
                    AND menus.menu_id = 2;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@today", DateTime.Today),
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get all finished kitchen orders of today.
        /// </summary>
        /// <returns>A list of all finished kitchen orders of today.</returns>
        public List<Order> GetAllFinishedKitchenOrders()
        {
            string query =
                $@"{ORDERS_SELECT_QUERY}
                WHERE 
                    orders_items.[state] != 'Taken'
                    AND orders_items.[state] != 'InProgress'
                    AND taken_at >= @today 
                    AND menus.menu_id != 2";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@today", DateTime.Today)
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        /// <summary>
        /// Get all finished bar orders of today.
        /// </summary>
        /// <returns>Get all finished bar orders of today.</returns>
        public List<Order> GetAllFinishedBarOrders()
        {
            string query =
                $@"{ORDERS_SELECT_QUERY}
                WHERE 
                    orders_items.[state] != 'Taken'
                    AND orders_items.[state] != 'InProgress'
                    AND taken_at >= @today 
                    AND menus.menu_id = 2";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@today", DateTime.Today)
            };

            return ParseDataTable(Query(query, sqlParameters));
        }

        public Order GetByTableId(int id)
        {
            string query = $@"{ORDERS_SELECT_QUERY} WHERE tables.table_id = @tableId AND orders.is_payed = 0;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@tableId", id)
            };

            List<Order> orders = ParseDataTable(Query(query, sqlParameters));

            if (orders.Count > 0)
            {
                return orders[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Saves an order to the database.
        /// </summary>
        /// <param name="order">The order that should be saved to the database.</param>
        /// <remarks>Yannick, 2020/05/21</remarks>
        public void Store(Order order)
        {
            // Create an order in the database.
            string query =
                @"INSERT INTO orders(table_id, is_payed, employee_id)
                VALUES
                (@tableId, 0, @employeeId);";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@tableId", order.Table.Id),
                new SqlParameter("@employeeId", order.Employee.Id)
            };

            int orderId = EditQueryWithId(query, sqlParameters);

            // We save the time this order was taken at.
            DateTime takenAt = DateTime.Now;

            // Convert the order items into a DataTable.
            DataTable orderItemsTable = OrderItemsToDataTable(order.OrderItems, takenAt, orderId);

            // Save the order items to the database.
            StoreOrderItems(orderItemsTable);
            BulkUpdateStock(order.OrderItems, orderId);
        }

        /// <summary>
        /// Saves the order items to the database.
        /// </summary>
        /// <param name="dataTable">The table that should be stored to the database.</param>
        /// <remarks>Yannick, 2020/05/21</remarks>
        private void StoreOrderItems(DataTable dataTable)
        {
            try
            {
                // Add the mapping for the DataTable to the database table.
                List<SqlBulkCopyColumnMapping> columnsMapping = new List<SqlBulkCopyColumnMapping>
                {
                    new SqlBulkCopyColumnMapping("item_id", "item_id"),
                    new SqlBulkCopyColumnMapping("order_id", "order_id"),
                    new SqlBulkCopyColumnMapping("state", "state"),
                    new SqlBulkCopyColumnMapping("state_time", "state_time"),
                    new SqlBulkCopyColumnMapping("taken_at", "taken_at"),
                    new SqlBulkCopyColumnMapping("quantity", "quantity"),
                    new SqlBulkCopyColumnMapping("comment", "comment")
                };

                // Insert the order items into the database. 
                BulkInsert(dataTable, "orders_items", columnsMapping);
            }
            catch (Exception error)
            {
                throw error;
            }
        }
        
        /// <summary>
        /// For each order item in the list it will reduce the Menu item stock by the Quantity property of that item.
        /// </summary>
        /// <param name="orderItems">A list of the order items from a order.</param>
        /// <param name="orderId">The ID of the order.</param>
        /// <remarks>Yannick, 2020/05/21</remarks>
        private void BulkUpdateStock(List<OrderItem> orderItems, int orderId)
        {
            // Open SQL connection and create a SQL transaction.
            SqlConnection connection = OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                foreach (OrderItem orderItem in orderItems)
                {
                    // Add a reduce stock query.
                    string updateQuery = @"UPDATE items SET stock = stock - @quantity WHERE items.item_id = @itemId;";

                    SqlParameter[] updateParams =
                    {
                        new SqlParameter("@quantity", orderItem.Quantity),
                        new SqlParameter("@itemId", orderItem.Item.Id)
                    };

                    // Add the query to the transaction.
                    EditTransactionQuery(updateQuery, updateParams, transaction);
                }

                // Reduce the stock of the items.
                transaction.Commit();
            }
            catch (Exception error)
            {
                // Roll back the transaction.
                transaction.Rollback();

                // Delete the created order (Rollback)
                Delete(orderId);

                throw new OutOfStockException("An item in the order is out of stock", error);
            }
        }

        public void Update(Order item)
        {
            // Open SQL connection and create a SQL transaction.
            SqlConnection connection = OpenConnection();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Update the order.
                string query =
                    @"UPDATE orders
                        SET
                            table_id = @tableId,
                            employee_id = @employeeId,
                            is_payed = @isPayed
                        WHERE order_id = @orderId;";

                SqlParameter[] sqlParameters =
                {
                    new SqlParameter("@orderId", item.Id),
                    new SqlParameter("@tableId", item.Table.Id),
                    new SqlParameter("@employeeId", item.Employee.Id),
                    new SqlParameter("@isPayed", item.IsPayed)
                };

                EditTransactionQuery(query, sqlParameters, transaction);

                // Update the order item state of each order item.
                foreach (OrderItem orderItem in item.OrderItems)
                {
                    UpdateOrderItemState(orderItem, transaction);
                }

                // Commit the order updates.
                transaction.Commit();
            }
            catch (Exception error)
            {
                // Roll back the transaction.
                transaction.Rollback();

                throw error;
            }
        }

        private void UpdateOrderItemState(OrderItem orderItem, SqlTransaction transaction)
        {
            string query = @"UPDATE orders_items SET [state] = @orderItemState WHERE order_item_id = @itemId";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@itemId", orderItem.Id),
                new SqlParameter("@orderItemState", $"{orderItem.State}")
            };

            EditTransactionQuery(query, sqlParameters, transaction);
        }

        /// <summary>
        /// Delete a order.
        /// </summary>
        /// <param name="id">The ID of the order to delete.</param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public void Delete(int id)
        {
            string query = @"DELETE FROM orders WHERE orders.order_id = @orderId;";

            SqlParameter[] sqlParameters =
            {
                new SqlParameter("@orderId", id)
            };

            EditQuery(query, sqlParameters);
        }

        /// <summary>
        /// Delete a order item.
        /// </summary>
        /// <param name="id">The ID of the order item to delete.</param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public void DeleteOrderItem(int orderItemId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Convert order items into a DataTable.
        /// </summary>
        /// <param name="orderItems">An list of order items.</param>
        /// <param name="takenAt">The date the order is taken at.</param>
        /// <param name="orderId">The ID of the order.</param>
        /// <returns>A DataTable containing all the OrderItems.</returns>
        /// <remarks>Yannick</remarks>
        private DataTable OrderItemsToDataTable(List<OrderItem> orderItems, DateTime takenAt, int orderId)
        {
            // Create a new DataTable.
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(new DataColumn("item_id", typeof(int)));
            dataTable.Columns.Add(new DataColumn("order_id", typeof(int)));
            dataTable.Columns.Add(new DataColumn("state", typeof(string)));
            dataTable.Columns.Add(new DataColumn("state_time", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("taken_at", typeof(DateTime)));
            dataTable.Columns.Add(new DataColumn("quantity", typeof(int)));
            dataTable.Columns.Add(new DataColumn("comment", typeof(string)));

            foreach (OrderItem orderItem in orderItems)
            {
                DataRow row = OrderItemToDataRow(orderItem, takenAt, orderId, dataTable);

                // Add the row to the DataTable.
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /// <summary>
        /// Convert an OrderItem to a DataRow.
        /// </summary>
        /// <param name="orderItem">The OrderItem to convert to a DataRow.</param>
        /// <param name="takenAt">The date the Order was taken at.</param>
        /// <param name="orderId">The ID of the order.</param>
        /// <param name="dataTable">The DataTable that the order item should belong to.</param>
        /// <returns>The OrderItem as a DataRow.</returns>
        /// <remarks>Yannick</remarks>
        private DataRow OrderItemToDataRow(OrderItem orderItem, DateTime takenAt, int orderId, DataTable dataTable) 
        {
            DataRow row = dataTable.NewRow();

            // Fill the row.
            row["item_id"] = orderItem.Item.Id;
            row["order_id"] = orderId;
            row["state"] = "Taken";
            row["state_time"] = takenAt;
            row["taken_at"] = takenAt;
            row["quantity"] = orderItem.Quantity;
            row["comment"] = orderItem.Comment;

            return row;
        }

        /// <summary>
        /// Parses a DataTable to a list of Orders.
        /// </summary>
        /// <param name="dataTable">The DataTable to parse.</param>
        /// <returns>A list of orders.</returns>
        private List<Order> ParseDataTable(DataTable dataTable)
        {
            List<Order> orders = new List<Order>();

            foreach (DataRow row in dataTable.Rows)
            {
                bool exists = false;

                // Add the order items to the correct order.
                for (int i = 0; i < orders.Count; i++)
                {
                    if (orders[i].Id == (int)row["order_id"])
                    {
                        OrderItem orderItem = RowToOrderItem(row);

                        orders[i].OrderItems.Add(orderItem);

                        exists = true;
                        continue;
                    }
                }

                if (!exists)
                {
                    orders.Add(RowToOrder(row));
                }
            }

            return orders;
        }
        
        /// <summary>
        /// Convert an order item state from a string to an <see cref="OrderItemState"/>.
        /// </summary>
        /// <param name="state">The state of an order item.</param>
        /// <returns>The order item state.</returns>
        private OrderItemState ToOrderItemState(string state)
        {
            switch (state.ToLower())
            {
                case "taken":
                    return OrderItemState.Taken;

                case "inprogress":
                    return OrderItemState.InProgress;

                case "readytoserve":
                    return OrderItemState.ReadyToServe;

                case "served":
                    return OrderItemState.Served;

                default:
                    throw new Exception($"{state} is not a valid OrderItemState.");
            }
        }

        /// <summary>
        /// Parse a DataRow to an OrderItem.
        /// </summary>
        /// <param name="row">The DataRow to parse.</param>
        /// <returns>The parsed DataRow as an OrderItem.</returns>
        private OrderItem RowToOrderItem(DataRow row)
        {
            TaxCategory taxCategory = new TaxCategory()
            {
                Id = (int)row["tax_category_id"],
                Name = (string)row["tax_category_name"],
                VAT = (int)row["vat_percentage"]
            };

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
                Name = (string)row["menu_category_name"]
            };

            MenuItem item = new MenuItem()
            {
                Id = (int)row["item_id"],
                Name = (string)row["item_name"],
                Stock = (int)row["stock"],
                Price = (decimal)row["price"],
                Menu = menu,
                TaxCategory = taxCategory,
                Category = menuCategory
            };

            OrderItem orderItem = new OrderItem()
            {
                Id = (int)row["order_item_id"],
                State = ToOrderItemState((string)row["state"]),
                StateTime = (DateTime)row["state_time"],
                Quantity = (int)row["quantity"],
                TakenAt = (DateTime)row["taken_at"],
                Item = item
            };

            if (row["comment"] != DBNull.Value)
            {
                orderItem.Comment = (string)row["comment"];
            }

            return orderItem;
        }

        /// <summary>
        /// Parse a DataRow to an Order.
        /// </summary>
        /// <param name="row">The DataRow to parse.</param>
        /// <returns>The parsed DataRow as an Order.</returns>
        private Order RowToOrder(DataRow row)
        {
            OrderItem orderItem = RowToOrderItem(row);

            Table table = new Table()
            {
                Id = (int)row["table_id"]
            };

            Employee employee = new Employee()
            {
                Id = (int)row["employee_id"],
                FirstName = (string)row["first_name"],
                LastName = (string)row["last_name"],
                Passcode = (int)row["password"],
                Role = (Role)Role.Parse(typeof(Role), row["role"].ToString(), true)
            };

            Order order = new Order()
            {
                Id = (int)row["order_id"],
                IsPayed = (bool)row["is_payed"],
                OrderItems = new List<OrderItem>()
                {
                    orderItem
                },
                Table = table,
                Employee = employee
            };

            return order;
        }
    }
}
