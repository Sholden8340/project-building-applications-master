using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MenuItem = ChapeauModel.MenuItem;

namespace ChapeauUI
{
    /// <summary>
    /// Interaction logic for MenuItemUI.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/05/20</remarks>
    public partial class MenuItemUI : UserControl
    {
        private MenuItem menuItem;
        private int stock;

        public MenuItemUI()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The menu item that is displayed in this UI.
        /// Fires: ShowInStock()
        /// </summary>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public MenuItem MenuItem 
        {
            get
            {
                return menuItem;
            }

            set
            {
                menuItem = value;
                stock = value.Stock;

                ShowInStock(value);
            }
        }

        /// <summary>
        /// The quantity of the menu item to add to the order.
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

            private set
            {
                if (value > 0 && value <= stock)
                {
                    Inp_ProductAmount.Text = $"{value}";
                }
            }
        }

        /// <summary>
        /// The name of the item.
        /// </summary>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public string ItemName 
        { 
            get 
            { 
                return LabelItemName.Content.ToString(); 
            }

            set 
            {
                LabelItemName.Content = value;
            } 
        }

        /// <summary>
        /// The price of the item.
        /// </summary>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public decimal ItemPrice
        {
            get
            {
                string removedEuroSign = LabelPrice.Content.ToString().Replace('€', ' ');
                return decimal.Parse(removedEuroSign);
            }

            set
            {
                LabelPrice.Content = $"€{value:0.00}";
            }
        }

        /// <summary>
        /// Sets the handler for clicking the add button.
        /// </summary>
        /// <param name="handler">The method that should fire when the user clicks add.</param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public void SetAddItemHandler(Action<MenuItem, int> handler)
        {
            Btn_AddItem.Click += async (sender, e) =>
            {
                handler(MenuItem, Quantity);

                // Show that the item has been added.
                Lbl_AddedToOrder.Content = $"{Quantity} item{(Quantity > 1 ? "'s" : "")} added";
                Lbl_AddedToOrder.Visibility = Visibility.Visible;

                // Wait 2s and then make the label invisible again.
                await Task.Delay(1000);
                Lbl_AddedToOrder.Visibility = Visibility.Collapsed;
            };
        }

        /// <summary>
        /// Sets the handler for clicking the comment button.
        /// </summary>
        /// <param name="handler">The method that should fire when the user clicks comment.</param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        public void SetAddWithComment(Action<MenuItem> handler)
        {
            btn_AddWithComment.Click += (sender, e) => handler(MenuItem);
        }

        /// <summary>
        /// Checks if the item is in stock, and updates the UI accordingly.
        /// </summary>
        /// <param name="menuItem">The menu item to check the stock of.</param>
        /// <remarks>Yannick, 2020/06/09</remarks>
        private void ShowInStock(MenuItem menuItem)
        {
            if (menuItem.Stock == 0)
            {
                Lbl_OutOfStock.Visibility = Visibility.Visible;
                Btn_AddItem.IsEnabled = false;
                Btn_Decrease.IsEnabled = false;
                Btn_Increase.IsEnabled = false;
                btn_AddWithComment.IsEnabled = false;
            }
            else
            {
                Lbl_OutOfStock.Visibility = Visibility.Collapsed;
                Btn_AddItem.IsEnabled = true;
                Btn_Decrease.IsEnabled = true;
                Btn_Increase.IsEnabled = true;
                btn_AddWithComment.IsEnabled = true;
            }
        }

        /// <summary>
        /// Increase the Quantity by 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/06</remarks>
        private void Btn_Increase_Click(object sender, RoutedEventArgs e)
        {
            Quantity++;
        }

        /// <summary>
        /// Decrease the Quantity by 1.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/06</remarks>
        private void Btn_Decrease_Click(object sender, RoutedEventArgs e)
        {
            Quantity--;
        }

        /// <summary>
        /// Make sure that only numbers can be entered in the input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/06</remarks>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
