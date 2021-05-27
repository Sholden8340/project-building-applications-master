using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace ChapeauUI
{
    public partial class BarKitchenUI : Form
    {
        private readonly Order_Service orderService;
        private readonly Timer timer;
        private readonly Employee employee;
        private bool isViewingFinishedOrders = false;

        public BarKitchenUI(Employee employee)
        {
            InitializeComponent();

            this.employee = employee;
            orderService = new Order_Service();
            Text = $"{employee.Role} - {employee.FirstName} {employee.LastName}";

            timer = new Timer
            {
                Interval = 10000
            };

            timer.Tick += (sender, e) => UpdateData();
            timer.Start();
        }

        /// <summary>
        /// Update the data that is shown in the UI.
        /// </summary>
        private void UpdateData()
        {
            // Disable the toggle view button (prevent worker trying to run multiple times).
            Btn_ToggleView.Enabled = false;

            try
            {
                RunWorker(Worker_UpdateData);
            }
            catch
            {
                ErrorUI.ShowErrorDialog("System was not able to update the data.");
            }
        }

        /// <summary>
        /// Run a task in a BackgroundWorker.
        /// </summary>
        /// <param name="worker">The background worker to run.</param>
        private void RunWorker(BackgroundWorker worker)
        {
            // Cancel the worker if it's running.
            worker.CancelAsync();

            // Check if the worker is busy, if so show an error.
            if (!worker.IsBusy)
            {
                worker.RunWorkerAsync();
            }
            else
            {
                ErrorUI.ShowErrorDialog("System was unable to update the data because the worker was busy.");
            }
        }

        /// <summary>
        /// Get all open orders of today.
        /// </summary>
        /// <returns>A list of open orders of today.</returns>
        private List<Order> GetOpenOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                orders = orderService.GetAllOpenOrders(employee);
            }
            catch (Exception error)
            {
                ErrorUI.ShowErrorDialog(error.Message);
            }

            return orders;
        }

        /// <summary>
        /// Get all finished orders of today.
        /// </summary>
        /// <returns>A list of finished orders of today.</returns>
        private List<Order> GetFinishedOrders()
        {
            List<Order> orders = new List<Order>();

            try
            {
                orders = orderService.GetAllFinishedOrders(employee);
            }
            catch (Exception error)
            {
                ErrorUI.ShowErrorDialog(error.Message);
            }

            return orders;
        }

        /// <summary>
        /// Display the orders in the UI.
        /// </summary>
        /// <param name="orders">The list of orders to display.</param>
        private void ShowOrders(List<Order> orders)
        {
            // Clear the list.
            Lst_Orders.Items.Clear();
            Lst_Orders.Groups.Clear();

            foreach (Order order in orders)
            {
                // Create a list view group for the order.
                ListViewGroup listViewGroup = new ListViewGroup($"Order {order.Id} - Table {order.Table.Id}")
                {
                    Tag = order
                };

                Lst_Orders.Groups.Add(listViewGroup);

                // Add each order item in the order to the order list view group.
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    ListViewItem listViewItem = new ListViewItem(
                        new string[]
                        {
                            orderItem.Quantity.ToString(),
                            orderItem.Item.Name,
                            orderItem.Comment,
                            ToStringOrderItemState(orderItem.State),
                            GetTimeSince(orderItem.TakenAt)
                        }, 
                        listViewGroup)
                    {
                        Tag = orderItem
                    };

                    Lst_Orders.Items.Add(listViewItem);
                }
            }
        }

        /// <summary>
        /// Convert an OrderItemState to a string.
        /// </summary>
        /// <param name="orderItemState">The order item state.</param>
        /// <returns>The order item state in human readable form.</returns>
        private string ToStringOrderItemState(OrderItemState orderItemState)
        {
            switch (orderItemState)
            {
                case OrderItemState.Taken:
                    return "Taken";
                case OrderItemState.InProgress:
                    return "In progress";
                case OrderItemState.ReadyToServe:
                    return "Ready to serve";
                case OrderItemState.Served:
                    return "Served";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Get the formatted time since the order was taken.
        /// </summary>
        /// <param name="dateTime">The date time when the order was taken.</param>
        /// <returns>The formatted time since the order was taken.</returns>
        private string GetTimeSince(DateTime dateTime)
        {
            TimeSpan ts = DateTime.Now.Subtract(dateTime);
            return $"{(ts.TotalHours > 1 ? $"{ts.TotalHours:0}h" : string.Empty)} {ts.Minutes}m {ts.Seconds}s";
        }

        /// <summary>
        /// Fetch the orders for the ListView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Worker_UpdateOrders_DoWork(object sender, DoWorkEventArgs e)
        {
            List<Order> orders;

            if (isViewingFinishedOrders)
            {
                orders = GetFinishedOrders();
            }
            else
            {
                orders = GetOpenOrders();
            }

            e.Result = orders;
        }

        /// <summary>
        /// Display the orders in the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">The event arguments, if successful result should be a list of orders.</param>
        private void Worker_UpdateOrders_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                ErrorUI.ShowErrorDialog("Something went wrong while getting orders.");
            }
            else if (!e.Cancelled)
            {
                try
                {
                    ShowOrders((List<Order>)e.Result);
                }
                catch (Exception error)
                {
                    ErrorUI.ShowErrorDialog(error.Message);
                }
            }

            // Enable the switch between open and finished orders.
            Btn_ToggleView.Enabled = true;
        }

        /// <summary>
        /// The load event of the KitchenUI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarKitchenUI_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        /// <summary>
        /// Event handler for marking an entire order as ready to serve.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_MarkAsReady_Click(object sender, EventArgs e)
        {
            // Make sure at least 1 order is selected.
            if (Lst_Orders.SelectedItems.Count > 0)
            {
                // Get the order the selected OrderItem belongs to.
                Order order = (Order)Lst_Orders.SelectedItems[0].Group.Tag;

                // Update the state of all order items.
                foreach (OrderItem orderItem in order.OrderItems)
                {
                    orderItem.State = OrderItemState.ReadyToServe;
                }

                // Save the updated order.
                try
                {
                    orderService.Update(order);
                }
                catch
                {
                    ErrorUI.ShowErrorDialog("The system was unable to mark the order as ready.");
                }

                UpdateData();
            }
        }

        /// <summary>
        /// Switch between the Open and Finished orders view.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_ToggleView_Click(object sender, EventArgs e)
        {
            // Disable the button.
            Btn_ToggleView.Enabled = false;

            // Update the UI elements to reflect the new state.
            if (isViewingFinishedOrders)
            {
                isViewingFinishedOrders = false;

                Lbl_PageTitle.Text = $"{employee.Role} - Open orders".ToUpper();
                Btn_MarkAsReady.Enabled = true;
                Btn_ToggleView.Text = "VIEW FINSIHED ORDERS";
            }
            else
            {
                isViewingFinishedOrders = true;

                Lbl_PageTitle.Text = $"{employee.Role} - Finished orders".ToUpper();
                Btn_MarkAsReady.Enabled = false;
                Btn_ToggleView.Text = "VIEW OPEN ORDERS";
            }

            // Update the data to the correct orders.
            UpdateData();
        }
    }
}
