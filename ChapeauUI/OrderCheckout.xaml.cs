using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChapeauUI
{
    /// <summary>
    /// Interaction logic for OrderCheckout.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/06/07</remarks>
    public partial class OrderCheckout : UserControl
    {
        private Order order;

        public OrderCheckout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Method that closes the orderCheckout overview.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public Action<Order> CloseOverview { get; set; }

        /// <summary>
        /// Deletes the current order.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public Action DeleteOrder { get; set; }

        /// <summary>
        /// Informs the user that an order was successfully created.
        /// </summary>
        /// <remarks>Yannick, 2020/06/11</remarks>
        public Action CreatedSuccessfully { get; set; }

        /// <summary>
        /// Shows the order in the OrderCheckout user control.
        /// </summary>
        /// <param name="order">The order to display.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public void ShowOrder(Order order)
        {
            this.order = order;
            Stack_Items.Children.Clear();

            foreach (OrderItem orderItem in order.OrderItems)
            {
                ShowOrderItem(orderItem);
            }

            UpdateCreateOrderBtnStatus();
            UpdateTotal();
        }

        /// <summary>
        /// Create a OrderItemUI for the order item, and display it.
        /// Fires: ShowOrderItemComment
        /// </summary>
        /// <param name="orderItem">The order item to display.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public void ShowOrderItem(OrderItem orderItem)
        {
            OrderItemUI orderItemUI = new OrderItemUI
            {
                OrderItem = orderItem,
                Title = orderItem.Item.Name,
                Quantity = orderItem.Quantity
            };

            // Add Update and remove handlers
            orderItemUI.UpdateOrder = UpdateOrder;
            orderItemUI.RemoveOrderItem = RemoveOrderItem;

            Stack_Items.Children.Add(orderItemUI);
            ShowOrderItemComment(orderItem);
        }

        /// <summary>
        /// Show the comment for an order item.
        /// </summary>
        /// <param name="orderItem">The order item to show the comment of.</param>
        /// <remarks>Yannick, 2020/06/08</remarks>
        private void ShowOrderItemComment(OrderItem orderItem)
        {
            if (orderItem.Comment != null && orderItem.Comment != string.Empty)
            {
                OrderItemCommentUI orderItemCommentUI = new OrderItemCommentUI(orderItem.Comment);
                Stack_Items.Children.Add(orderItemCommentUI);
            }
        }

        /// <summary>
        /// Check if there is at least 1 item in the order.
        /// Disables button if not, enables if true.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void UpdateCreateOrderBtnStatus()
        {
            if (order.OrderItems.Count > 0)
            {
                Btn_CreateOrder.IsEnabled = true;
            }
            else
            {
                Btn_CreateOrder.IsEnabled = false;
            }
        }

        /// <summary>
        /// Update the quantity in the order to match the new quantity.
        /// Fires: UpdateTotal();
        /// </summary>
        /// <param name="update">The updated order item.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void UpdateOrder(OrderItem update)
        {
            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (orderItem.Id == update.Id)
                {
                    orderItem.Quantity = update.Quantity;
                }
            }

            UpdateTotal();
        }

        /// <summary>
        /// Calculate and show the total price of the order.
        /// </summary>
        /// <remarks>Yannick, 2020/06/08</remarks>
        private void UpdateTotal()
        {
            decimal total = 0;

            foreach (OrderItem orderItem in order.OrderItems)
            {
                decimal itemTotal = orderItem.Item.Price * orderItem.Quantity;
                total += itemTotal;
            }

            Lbl_OrderTotal.Content = $"€{total:0.00}";
        }

        /// <summary>
        /// Remove a item from the order.
        /// </summary>
        /// <param name="update">The order item that should be deleted.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void RemoveOrderItem(OrderItem update)
        {
            OrderItem deleteOrderItem = new OrderItem();

            // Find the orderItem to delete.
            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (orderItem.Id == update.Id)
                {
                    deleteOrderItem = orderItem;
                    continue;
                }
            }

            // Delete the item.
            order.OrderItems.Remove(deleteOrderItem);

            // Update the UI elements.
            UpdateCreateOrderBtnStatus();
            UpdateTotal();
            ShowOrder(order);
        }

        /// <summary>
        /// Fires if the user clicks the close button.
        /// Fires: CloseOverview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_Close_MouseDown(object sender, MouseButtonEventArgs e)
        {
            CloseOverview(order);
        }

        /// <summary>
        /// Store the order to the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Order_Service orderService = new Order_Service();
                orderService.Store(order);
                CreatedSuccessfully();
            }
            catch (Exception error)
            {
                ErrorUI.ShowErrorDialog(error.Message);
            }
        }

        /// <summary>
        /// Handles deleting the entire order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_DeleteOrder_Click(object sender, RoutedEventArgs e)
        {
            DeleteOrder();
        }
    }
}
