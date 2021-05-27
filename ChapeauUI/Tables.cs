using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class Tables : Form
    {
        Timer tmr = new Timer();
        Order_Service orderService = new Order_Service();
        Employee employee;
        List<TableUIElements> tables = new List<TableUIElements>();
        Table_Service tableService = new Table_Service();

        public Tables(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;
            Text = $"Table overview - {employee.FirstName} {employee.LastName}";

            tmr.Interval = 10000;
            tmr.Tick += (sender, e) => UpdateTakenAtInWorker();
            tmr.Start();
        }

        private List<Order> GetOpenOrders()
        {
            try
            {
                return orderService.GetOpenOrders();
            }
            catch
            {
                ErrorUI.ShowErrorDialog("Something went wrong while trying to get the open orders.");
            }

            return new List<Order>();
        }

        private void UpdateTakenAtInWorker()
        {
            Worker_UpdateTimer.CancelAsync();

            if (!Worker_UpdateTimer.IsBusy) 
            {
                Worker_UpdateTimer.RunWorkerAsync();
            }
        }

        // update time
        private void HandleUpdateTime(List<Order> orders)
        {
            foreach (TableUIElements table in tables)
            {
                table.TimerLabel.Text = "No running order";

                if (!orders.Any(order => order.Table.Id == table.Table.Id))
                {
                    table.Order = null;
                }
            }

            foreach (Order order in orders)
            {
                tables[order.Table.Id - 1].Order = order;

                if (order.OrderItems.All(item => item.State == OrderItemState.ReadyToServe))
                {
                    ReadyTable(tables[order.Table.Id - 1]);
                    UpdateTimeSince(order.OrderItems[0].TakenAt, tables[order.Table.Id - 1].TimerLabel);
                }
                else if (order.OrderItems.All(item => item.State == OrderItemState.Served))
                {
                    ServeTable(tables[order.Table.Id - 1], false);
                    tables[order.Table.Id - 1].TimerLabel.Text = "Order served";
                }
                else
                {
                    OrderTaken(tables[order.Table.Id - 1]);
                    UpdateTimeSince(order.OrderItems[0].TakenAt, tables[order.Table.Id - 1].TimerLabel);
                }
            }
        }

        private void UpdateTimeSince(DateTime takenAt, Label timerLabel)
        {
            TimeSpan ts = DateTime.Now.Subtract(takenAt);
            timerLabel.Text = FormatTimeSpan(ts);
        }

        /// <summary>
        /// Occupy a table.
        /// </summary>
        /// <param name="table">The table elements that need to be updated.</param>
        /// <param name="shouldUpdateDatabase">Will only update database while this is true.</param>
        private void OccupyTable(TableUIElements table, bool shouldUpdateDatabase = true)
        {
            table.TableImage.Visible = false;
            table.TableOccupiedImage.Visible = true;
            table.TableReadyImage.Visible = false;
            table.TableOrderTakenImage.Visible = false;
            table.PayBillButton.Visible = false;

            table.PlaceOrderButton.Visible = true;
            table.OccupyButton.Visible = false;
            table.OrderReadyButton.Visible = false;
            table.ClearButton.Visible = true;

            try
            {
                if (shouldUpdateDatabase)
                {
                    table.Table.State = TableState.Occupied;
                    tableService.Update(table.Table);
                }
            }
            catch (Exception error)
            {
                ErrorUI.ShowErrorDialog(error.Message);
            }
        }

        /// <summary>
        /// Mark a table as ready.
        /// </summary>
        /// <param name="table">The table elements that need to be updated.</param>
        private void ReadyTable(TableUIElements table)
        {
            table.TableImage.Visible = false;
            table.TableOccupiedImage.Visible = false;
            table.TableReadyImage.Visible = true;
            table.TableOrderTakenImage.Visible = false;

            table.PayBillButton.Visible = false;
            table.PlaceOrderButton.Visible = false;
            table.OccupyButton.Visible = false;
            table.OrderReadyButton.Visible = true;
            table.ClearButton.Visible = false;
        }

        /// <summary>
        /// Mark a table as served.
        /// </summary>
        /// <param name="table">Mark table as served.</param>
        /// <param name="shouldUpdateDatabase">Should the order be updated in the database to mark items as served.</param>
        private void ServeTable(TableUIElements table, bool shouldUpdateDatabase = true)
        {
            table.TableImage.Visible = false;
            table.TableOccupiedImage.Visible = false;
            table.TableReadyImage.Visible = true;
            table.TableOrderTakenImage.Visible = false;

            table.PayBillButton.Visible = true;
            table.PlaceOrderButton.Visible = false;
            table.OccupyButton.Visible = false;
            table.OrderReadyButton.Visible = false;
            table.ClearButton.Visible = false;

            try
            {
                // Make sure there is an order & and only update database if desired. This way we can do UI updates without updating the database.
                if (shouldUpdateDatabase && table.Order != null)
                {
                    Order order = table.Order;

                    foreach (OrderItem orderItem in order.OrderItems)
                    {
                        orderItem.State = OrderItemState.Served;
                    }

                    orderService.Update(order);
                }
                else if (table.Order == null)
                {
                    ErrorUI.ShowErrorDialog("Application couldn't find the order for the table.");
                }
            }
            catch (Exception error)
            {
                ErrorUI.ShowErrorDialog(error.Message);
            }
        }
        
        /// <summary>
        /// Clear a table.
        /// </summary>
        /// <param name="table">The table UI elements to update.</param>
        /// <param name="shouldUpdateDatabase">Should the database data be updated.</param>
        private void ClearTable(TableUIElements table, bool shouldUpdateDatabase = true)
        {
            table.TableImage.Visible = true;
            table.TableOccupiedImage.Visible = false;
            table.TableReadyImage.Visible = false;
            table.TableOrderTakenImage.Visible = false;

            table.PlaceOrderButton.Visible = false;
            table.PayBillButton.Visible = false;
            table.OccupyButton.Visible = true;
            table.OrderReadyButton.Visible = false;
            table.ClearButton.Visible = false;

            try
            {
                if (shouldUpdateDatabase)
                {
                    table.Table.State = TableState.Free;
                    tableService.Update(table.Table);
                }
            }
            catch (Exception error)
            {
                ErrorUI.ShowErrorDialog(error.Message);
            }
        }

        /// <summary>
        /// Mark a table as having an active order.
        /// </summary>
        /// <param name="table">The table elements to be updated.</param>
        private void OrderTaken(TableUIElements table)
        {
            table.TableImage.Visible = false;
            table.TableOccupiedImage.Visible = false;
            table.TableReadyImage.Visible = false;
            table.TableOrderTakenImage.Visible = true;

            table.PlaceOrderButton.Visible = false;
            table.OccupyButton.Visible = false;
            table.OrderReadyButton.Visible = false;
            table.OrderReadyButton.Enabled = false;
            table.ClearButton.Visible = false;
        }

        private void Logout_Click(object sender, EventArgs e)
        {
            Program.Logout();
        }

        private void Occupy1_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[0]);
        }

        private void Ready1_Click_1(object sender, EventArgs e)
        {
            ServeTable(tables[0]);
        }

        private void Clear1_Click(object sender, EventArgs e)
        {
            ClearTable(tables[0]);
        }

        // starting page
        private void Tables_Load(object sender, EventArgs e)
        {
            table1.Visible = true;
            table2.Visible = true;
            table3.Visible = true;
            table4.Visible = true;
            table5.Visible = true;
            table6.Visible = true;
            table7.Visible = true;
            table8.Visible = true;
            table9.Visible = true;
            table10.Visible = true;

            ready1.Visible = false;
            ready2.Visible = false;
            ready3.Visible = false;
            ready4.Visible = false;
            ready5.Visible = false;
            ready6.Visible = false;
            ready7.Visible = false;
            ready8.Visible = false;
            ready9.Visible = false;
            ready10.Visible = false;

            InitUI();

            foreach (TableUIElements tableUIElements in tables)
            {
                tableUIElements.PlaceOrderButton.Click += (SenderTable, eTable) =>
                {
                    OrderUI orderUI = new OrderUI(tableUIElements.Table, employee);
                    orderUI.Show();
                };

                tableUIElements.PayBillButton.Click += (SenderTable, eTable) =>
                {
                    BillUI billUI = new BillUI(tableUIElements.Table, employee);
                    billUI.Show();
                };
            }
        }

        /// <summary>
        /// Initialize the UI of the application.
        /// </summary>
        private void InitUI()
        {
            try
            {
                List<Table> allTables = tableService.GetAll();
                CreateTableClasses(allTables);

                foreach (TableUIElements tableUIElements in tables)
                {
                    switch (tableUIElements.Table.State)
                    {
                        case TableState.Free:
                            ClearTable(tableUIElements, false);
                            break;
                        case TableState.Occupied:
                            OccupyTable(tableUIElements, false);
                            break;
                        case TableState.Reserved:
                            // Not implemented
                            break;
                        default:
                            ClearTable(tableUIElements, false);
                            break;
                    }
                }

                UpdateTakenAtInWorker();
            }
            catch
            {
                ErrorUI.ShowErrorDialog("Application ran into a fatal issue, it has been caught now but will likely not be able to recover.");
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            Btn_Refresh.Enabled = false;
            InitUI();
            Btn_Refresh.Enabled = true;
        }

        private void Occupy2_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[1]);
        }

        private void Occupy3_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[2]);
        }

        private void Occupy4_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[3]);
        }

        private void Occupy5_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[4]);
        }

        private void Occupy6_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[5]);
        }

        private void Occupy7_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[6]);
        }

        private void Occupy8_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[7]);
        }

        private void Occupy9_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[8]);
        }

        private void Occupy10_Click(object sender, EventArgs e)
        {
            OccupyTable(tables[9]);
        }

        private void Ready2_Click(object sender, EventArgs e)
        {
            ServeTable(tables[1]);
        }

        private void Clear2_Click(object sender, EventArgs e)
        {
            ClearTable(tables[1]);
        }
        
        // table3   
        private void Ready3_Click(object sender, EventArgs e)
        {
            ServeTable(tables[2]);
        }

        private void Clear3_Click(object sender, EventArgs e)
        {
            ClearTable(tables[2]);
        }

        // table 4
        private void Ready4_Click(object sender, EventArgs e)
        {
            ServeTable(tables[3]);
        }

        private void Clear4_Click(object sender, EventArgs e)
        {
            ClearTable(tables[3]);
        }

        // table 5
        private void Ready5_Click(object sender, EventArgs e)
        {
            ServeTable(tables[4]);
        }

        private void Clear5_Click(object sender, EventArgs e)
        {
            ClearTable(tables[4]);
        }

        // table 6
        private void Ready6_Click(object sender, EventArgs e)
        {
            ServeTable(tables[5]);
        }

        private void Clear6_Click(object sender, EventArgs e)
        {
            ClearTable(tables[5]);
        }
        
        // table 7
        private void Ready7_Click(object sender, EventArgs e)
        {
            ServeTable(tables[6]);
        }

        private void Clear7_Click(object sender, EventArgs e)
        {
            ClearTable(tables[6]);
        }

        // table 8
        private void Ready8_Click(object sender, EventArgs e)
        {
            ServeTable(tables[7]);
        }

        private void Clear8_Click(object sender, EventArgs e)
        {
            ClearTable(tables[7]);
        }

        // table 9
        private void Ready9_Click(object sender, EventArgs e)
        {
            ServeTable(tables[8]);
        }

        private void Clear9_Click(object sender, EventArgs e)
        {
            ClearTable(tables[8]);
        }

        // table 10
        private void Ready10_Click(object sender, EventArgs e)
        {
            ServeTable(tables[9]);
        }

        private void Clear10_Click(object sender, EventArgs e)
        {
            ClearTable(tables[9]);
        }

        /// <summary>
        /// Create a list of all the tables in the UI.
        /// </summary>
        /// <param name="allTables">A list of all Tables.</param>
        private void CreateTableClasses(List<Table> allTables)
        {
            List<TableUIElements> tablesList = new List<TableUIElements>();

            for (int i = 1; i < 11; i++)
            {
                tablesList.Add(CreateTableClass(allTables[i - 1], i));
            }

            tables = tablesList;
        }

        /// <summary>
        /// Create a element table class, this allows for easily updating a table element.
        /// </summary>
        /// <param name="table">The table that this element is related to.</param>
        /// <param name="tableNumber">The number of the table.</param>
        /// <returns>A class containing all table elements.</returns>
        private TableUIElements CreateTableClass(Table table, int tableNumber)
        {
            TableUIElements tableClass = new TableUIElements()
            {
                Table = table,
                TableImage = (PictureBox)Controls[$"table{tableNumber}"],
                TableOccupiedImage = (PictureBox)Controls[$"table{tableNumber}oc"],
                TableReadyImage = (PictureBox)Controls[$"table{tableNumber}ready"],
                TableOrderTakenImage = (PictureBox)Controls[$"pb_OrderTaken{tableNumber}"],
                OccupyButton = (Button)Controls[$"occupy{tableNumber}"],
                OrderReadyButton = (Button)Controls[$"ready{tableNumber}"],
                PlaceOrderButton = (Button)Controls[$"po{tableNumber}"],
                TimerLabel = (Label)Controls[$"timer{tableNumber}"],
                PayBillButton = (Button)Controls[$"pb{tableNumber}"],
                ClearButton = (Button)Controls[$"clear{tableNumber}"]
            };

            return tableClass;
        }

        /// <summary>
        /// Formats the timespan to a human readable string.
        /// Not written by us, credits go to user2676274
        /// Source: https://stackoverflow.com/a/41966914
        /// </summary>
        /// <param name="timeSpan">The timespan to format</param>
        /// <returns>Human readable timespan</returns>
        private string FormatTimeSpan(TimeSpan timeSpan)
        {
            Func<Tuple<int, string>, string> tupleFormatter = t => $"{t.Item1} {t.Item2}{(t.Item1 == 1 ? string.Empty : "s")}";
            
            var components = new List<Tuple<int, string>>
            {
                Tuple.Create((int)timeSpan.TotalHours, "H"),
                Tuple.Create(timeSpan.Minutes, "M")
            };

            components.RemoveAll(i => i.Item1 == 0);

            string extra = string.Empty;

            if (components.Count > 1)
            {
                var finalComponent = components[components.Count - 1];
                components.RemoveAt(components.Count - 1);
                extra = $", {tupleFormatter(finalComponent)}";
            }

            if (timeSpan.TotalMinutes < 1)
            {
                return "Less then a minute";
            }

            return $"{string.Join(", ", components.Select(tupleFormatter))}{extra}";
        }

        private void Worker_UpdateTimer_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<Order> orders = GetOpenOrders();
            e.Result = orders;
        }

        private void Worker_UpdateTimer_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ErrorUI.ShowErrorDialog("Something went wrong while updating the updated at, times might be incorrect.");
            }
            else if (!e.Cancelled)
            {
                try
                {
                    HandleUpdateTime((List<Order>)e.Result);
                }
                catch (Exception error)
                {
                    ErrorUI.ShowErrorDialog(error.Message);
                }
            }
        }
    }
}
