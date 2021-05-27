using ChapeauModel;
using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ChapeauUI
{
    /// <summary>
    /// Interaction logic for OrderItemUI.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/06/07</remarks>
    public partial class OrderItemUI : UserControl
    {
        public OrderItemUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The OrderItem to display.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public OrderItem OrderItem { get; set; }

        /// <summary>
        /// The method that handles updating the order.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public Action<OrderItem> UpdateOrder { get; set; }

        /// <summary>
        /// The method that handles removing a order item from the order.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public Action<OrderItem> RemoveOrderItem { get; set; }

        /// <summary>
        /// Gets the content of the Lbl_ItemName. 
        /// Sets the content of Lbl_ItemName.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public string Title
        {
            get
            {
                return Lbl_ItemName.Content.ToString();
            }

            set
            {
                Lbl_ItemName.Content = value;
            }
        }

        /// <summary>
        /// The Quantity of the order item.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public int Quantity
        {
            get
            {
                if (Inp_ProductAmount.Text.Length > 0)
                {
                    return int.Parse(Inp_ProductAmount.Text);
                }

                return 1;
            }

            set
            {
                if (value > 0 && value <= OrderItem.Item.Stock)
                {
                    Inp_ProductAmount.Text = $"{value}";
                }
            }
        }

        /// <summary>
        /// Event handler for the increase button. Increases Quantity by 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_Increase_Click(object sender, RoutedEventArgs e)
        {
            Quantity++;
            OrderItem.Quantity = Quantity;
            UpdateOrder(OrderItem);
        }

        /// <summary>
        /// Event handler for the decrease button. Decreases Quantity by 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_Decrease_Click(object sender, RoutedEventArgs e)
        {
            Quantity--;
            OrderItem.Quantity = Quantity;
            UpdateOrder(OrderItem);
        }

        /// <summary>
        /// Validates that the user input is only a number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        /// <summary>
        /// Updates the quantity of the order item in the order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Inp_ProductAmount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (OrderItem != null && UpdateOrder != null)
            {
                OrderItem.Quantity = Quantity;
                UpdateOrder(OrderItem);
            }
        }

        /// <summary>
        /// Event handler for the user clicking the delete button.
        /// Removes the order item from the order.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_DeleteItem_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RemoveOrderItem(OrderItem);
        }
    }
}
