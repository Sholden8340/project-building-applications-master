using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using ChapeauLogic;
using ChapeauModel;
using Menu = ChapeauModel.Menu;
using MenuItem = ChapeauModel.MenuItem;

namespace ChapeauUI
{
    /// <summary>
    /// The orderUI of the application.
    /// </summary>
    /// <remarks>Yannick, 2020/05/10</remarks>
    public partial class OrderUI : Form
    {
        readonly Item_Service menuItemService;
        readonly Menu_Service menuService;
        readonly Table table;
        readonly Employee employee;
        Order order;

        /// <summary>
        /// Initialize the Order UI.
        /// </summary>
        /// <remarks>2020/05/10</remarks>
        public OrderUI(Table table, Employee employee)
        {
            InitializeComponent();

            // Initialize logic layer.
            menuItemService = new Item_Service();
            menuService = new Menu_Service();

            // Store the table and employee.
            this.table = table;
            this.employee = employee;
            Text = $"New order - {employee.FirstName} {employee.LastName}";
            
            // Create a fresh empty order.
            ResetOrder();

            // Give the sidebarNav a reference to this form.
            sidebarNav1.ParentForm = this;

            // Reduce flickering of the UserControls.
            DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.ContainerControl, false);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        /// <summary>
        /// Handles the OrderUI loading.
        /// Gets the menus.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>2020/05/10</remarks>
        private void OrderUI_Load(object sender, EventArgs e)
        {
            GetMenus();
        }

        /// <summary>
        /// Resets the current order.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void ResetOrder()
        {
            // TODO: This should also include the table & employee.
            order = new Order()
            {
                OrderItems = new List<OrderItem>(),
                IsPayed = false,
                Employee = employee,
                Table = table
            };

            orderCheckout1.ShowOrder(order);
            ShowOrderTotal();
        }

        private void RefreshData()
        {
            GetMenus();
        }

        /// <summary>
        /// Get the menus from the database.
        /// </summary>
        /// <remarks>Yannick, 2020/05/11</remarks>
        private void GetMenus()
        {
            try
            {
                List<Menu> menus = menuService.GetAll();
                ShowMenus(menus);
            }
            catch
            {
                ErrorUI.ShowErrorDialog("Something went wrong while trying to get the MenuItems.");
            }
        }

        /// <summary>
        /// Get the Menu Items of a menu category.
        /// </summary>
        /// <param name="menuCategory">The menu category to get the items for.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void GetMenuItemsByMenuCategory(MenuCategory menuCategory)
        {
            try
            {
                List<MenuItem> menuItems = menuItemService.GetByMenuCategoryId(menuCategory.Id);
                ShowMenuItems(menuItems);
            }
            catch
            {
                ErrorUI.ShowErrorDialog("Something went wrong while trying to get the MenuItems.");
            }
        }

        /// <summary>
        /// Display the menu items.
        /// </summary>
        /// <param name="menuItems">A list of menu items that should be displayed.</param>
        /// <remarks>Yannick, 2020/05/10</remarks>
        private void ShowMenuItems(List<MenuItem> menuItems)
        {
            // Clear all existing items
            FlowLayoutMenuItems.Controls.Clear();
            ShowActiveCategory(menuItems[0].Menu, menuItems[0].Category);

            try
            {
                foreach (MenuItem menuItem in menuItems)
                {
                    ElementHost elementHost = new ElementHost();

                    MenuItemUI menuItemUI = new MenuItemUI
                    {
                        MenuItem = menuItem,
                        ItemName = menuItem.Name,
                        ItemPrice = menuItem.Price
                    };

                    menuItemUI.SetAddItemHandler(AddItemToOrder);
                    menuItemUI.SetAddWithComment(AddItemWithComment);

                    // Add the menuItem to the element host so that it can be used in a windows form application.
                    elementHost.Child = menuItemUI;
                    elementHost.Size = new Size(771, 123);
                    elementHost.Margin = new Padding(0, 0, 0, 0);

                    // Add it to the FlowLayout.
                    FlowLayoutMenuItems.Controls.Add(elementHost);
                }
            }
            catch
            {
                ErrorUI.ShowErrorDialog("Something went wrong while trying to display the menu items. Please try again later!");
            }
        }

        /// <summary>
        /// Display the menus.
        /// </summary>
        /// <param name="menus">The menus to display</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void ShowMenus(List<Menu> menus)
        {
            try
            {
                sidebarNav1.GetMenuItemsByMenuCategory = GetMenuItemsByMenuCategory;
                sidebarNav1.UpdateMenus(menus);
                sidebarNav1.ParentForm = this;
                sidebarNav1.SetRefreshAction(RefreshData);
            }
            catch
            {
                ErrorUI.ShowErrorDialog("Something went wrong while displaying the Menus please try again later.");
            }
        }

        /// <summary>
        /// Show the title of the active category.
        /// </summary>
        /// <param name="menu">The active menu.</param>
        /// <param name="menuCategory">The active menu category.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void ShowActiveCategory(Menu menu, MenuCategory menuCategory)
        {
            Lbl_MenuTitle.Text = $"{menu.Name} {menuCategory.Name.Replace("Lunch ", "")}".ToUpper();
        }

        /// <summary>
        /// Displays the total amount of items in the order.
        /// </summary>
        /// <remarks>Yannick, 2020/06/09</remarks>
        private void ShowOrderTotal()
        {
            int itemTotal = 0;
            
            // Calculate the total
            foreach (OrderItem orderItem in order.OrderItems)
            {
                itemTotal += orderItem.Quantity;
            }

            // Display the total in the UI.
            Lbl_OrderTotal.Text = $"{itemTotal}";
        }

        /// <summary>
        /// Add an item to the order.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        /// <param name="quantity">The amount that should be in the order.</param>
        private void AddItemToOrder(MenuItem item, int quantity)
        {
            bool isUpdated = false;
            
            // Check if similar item already exists.
            foreach (OrderItem orderItem in order.OrderItems)
            {
                if (orderItem.Item == item && (orderItem.Comment == null || orderItem.Comment.Length < 1))
                {
                    orderItem.Quantity += quantity;
                    isUpdated = true;
                    continue;
                }
            }

            if (!isUpdated)
            {
                OrderItem orderItem = new OrderItem()
                {
                    Id = order.OrderItems.Count,
                    Item = item,
                    Quantity = quantity,
                    State = OrderItemState.Taken
                };

                order.OrderItems.Add(orderItem);
            }

            ShowOrderTotal();
        }

        /// <summary>
        /// Add an item with a comment to the order.
        /// </summary>
        /// <param name="item">The menu item to add.</param>
        /// <param name="quantity">The amount that should be in the order.</param>
        /// <param name="comment">The comment that should be added to the order item.</param>
        private void AddItemToOrder(MenuItem item, int quantity, string comment)
        {
            // Create a new order item, and add it to the order.
            OrderItem orderItem = new OrderItem()
            {
                Id = order.OrderItems.Count,
                Comment = comment,
                Item = item,
                Quantity = quantity,
                State = OrderItemState.Taken
            };

            order.OrderItems.Add(orderItem);

            // Reset the element host.
            ResetAddWithComment();

            // Update the order total.
            ShowOrderTotal();
        }

        /// <summary>
        /// Displays the UI for adding a item to the order with a comment.
        /// </summary>
        /// <param name="item">The menu item that should be added.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void AddItemWithComment(MenuItem item)
        {
            AddWithCommentUI addWithCommentUI = new AddWithCommentUI(AddItemToOrder, item, ResetAddWithComment);

            Elem_AddWithCommentHost.Visible = true;
            Elem_AddWithCommentHost.Child = addWithCommentUI;
        }

        /// <summary>
        /// Hides the AddWithCommentUI.
        /// </summary>
        /// <remarks>Yannick, 2020/06/09</remarks>
        private void ResetAddWithComment()
        {
            // Reset the element host.
            Elem_AddWithCommentHost.Visible = false;
            Elem_AddWithCommentHost.Child = null;
        }

        /// <summary>
        /// Inform the user that the order has been successfully created.
        /// </summary>
        /// <remarks>Yannick, 2020/06/11</remarks>
        private void SuccessfullyCreatedOrder()
        {
            // Inform the user that the order was successfully created.
            MessageBox.Show(
                "Successfully created order!",
                "Chapeau",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Close the OrderUI.
            Close();
        }

        /// <summary>
        /// Hides the order overview UI element.
        /// And saves any changes made to the Order.
        /// </summary>
        /// <param name="order">The updated order.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void CloseOverview(Order order)
        {
            this.order = order;
            ShowOrderTotal();
            Elem_CheckoutOverview.Visible = false;
        }

        /// <summary>
        /// Handles the scrolling in the MenuItems UI.
        /// This aims to reduce ghosting/flickering while scrolling the UI elements.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/05/20</remarks>
        private void FlowLayoutMenuItems_Scroll(object sender, ScrollEventArgs e)
        {
            // This method refreshes each element in the control on scroll, we do this to reduce visible "ghosting" while scrolling.
            if (sender is FlowLayoutPanel panel)
            {
                foreach (Control control in panel.Controls)
                {
                    if (control is ElementHost)
                    {
                        control.Refresh();
                    }
                }
            }
        }

        /// <summary>
        /// Handles opening the Order Overview/Cart.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void Btn_OpenCart_Click(object sender, EventArgs e)
        {
            Elem_CheckoutOverview.Visible = true;
            Elem_CheckoutOverview.Size = new Size(1024, 573);
            orderCheckout1.CloseOverview = CloseOverview;
            orderCheckout1.DeleteOrder = ResetOrder;
            orderCheckout1.ShowOrder(order);
            orderCheckout1.CreatedSuccessfully = SuccessfullyCreatedOrder;
        }
    }
}
