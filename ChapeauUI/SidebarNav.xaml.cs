using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

using ChapeauModel;
using Menu = ChapeauModel.Menu;
using Form = System.Windows.Forms.Form;

namespace ChapeauUI
{
    /// <summary>
    /// Interaction logic for SidebarNav.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/06/07</remarks>
    public partial class SidebarNav : UserControl
    {
        private bool isOpen = false;

        public SidebarNav()
        {
            InitializeComponent();
        }
        
        /// <summary>
        /// Get the menu items of a menu category.
        /// </summary>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public Action<MenuCategory> GetMenuItemsByMenuCategory { get; set; }

        /// <summary>
        /// A reference to the parent form.
        /// </summary>
        /// <remarks>Yannick, 2020/06/11</remarks>
        public Form ParentForm { get; set; }

        /// <summary>
        /// Set the handler that refreshes the data in the UI.
        /// </summary>
        /// <param name="refreshAction">The method that handles refreshing the data.</param>
        /// <remarks>Yannick, 2020/06/11</remarks>
        public void SetRefreshAction(Action refreshAction)
        {
            Btn_Refresh.Click += (sender, e) => refreshAction();
        }

        /// <summary>
        /// Display the given menus in the sidebar.
        /// </summary>
        /// <param name="menus">The menus to display.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        public void UpdateMenus(List<Menu> menus)
        {
            // Clear the current sidebar
            Stack_Buttons.Children.Clear();

            // Create the elements for the sidebar.
            foreach (Menu menu in menus)
            {
                CreateMenuElement(menu);
            }

            // Make first item active.
            ButtonAutomationPeer peer = new ButtonAutomationPeer((Button)Stack_Buttons.Children[0]);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        /// <summary>
        /// Event handler for clicking a menu category.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="category">The category that was clicked.</param>
        /// <param name="colors">The colors that belong to that category.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void MenuSwitchClick(object sender, RoutedEventArgs e, MenuCategory category, Dictionary<string, Color> colors)
        {
            // Reset all colors
            foreach (Button btn in Stack_Buttons.Children)
            {
                Menu btnMenu = (Menu)btn.Tag.GetType().GetProperty("Menu").GetValue(btn.Tag, null);
                Dictionary<string, Color> menuColors = GetMenuColor(btnMenu);
                btn.Background = new SolidColorBrush(menuColors["default"]);
                btn.BorderBrush = new SolidColorBrush(menuColors["default"]);
            }

            // Set clicked as active.
            if (sender is Button clickedBtn)
            {
                clickedBtn.Background = new SolidColorBrush(colors["active"]);
                clickedBtn.BorderBrush = new SolidColorBrush(colors["active"]);
            }

            // Update the menu items.
            GetMenuItemsByMenuCategory(category);
        }

        /// <summary>
        /// Render out the menu categories of a menu to the UI.
        /// </summary>
        /// <param name="menu">The menu to display.</param>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private void CreateMenuElement(Menu menu)
        {
            Dictionary<string, Color> colors = GetMenuColor(menu);

            foreach (MenuCategory menuCategory in menu.MenuCategories)
            {
                // Create a new category button.
                Button btn = new Button
                {
                    Tag = new { Menu = menu, Category = menuCategory },
                    Content = menuCategory.Name.Replace("Lunch m", "M"),
                    Name = $"Btn_Menu{menu.Name.Trim()}{menuCategory.Name.Replace(" ", "")}",

                    Background = new SolidColorBrush(colors["default"]),
                    Margin = new Thickness(0, 0, 0, 8),
                    Padding = new Thickness(0, 4, 0, 4),
                    Foreground = new SolidColorBrush(Color.FromRgb(69, 65, 77)),
                    BorderBrush = new SolidColorBrush(colors["default"]),
                    FontSize = 24
                };

                // Add click handler for item.
                btn.Click += (sender, e) => MenuSwitchClick(sender, e, menuCategory, colors);

                // Add button to UI.
                Stack_Buttons.Children.Add(btn);
            }
        }

        /// <summary>
        /// Get the correct color based on the Menu name.
        /// </summary>
        /// <param name="menu">The menu to get the color for.</param>
        /// <returns>A active and default color of the given menu.</returns>
        /// <remarks>Yannick, 2020/06/07</remarks>
        private Dictionary<string, Color> GetMenuColor(Menu menu)
        {
            Dictionary<string, Color> menuColor = new Dictionary<string, Color>();

            switch (menu.Name)
            {
                case "Lunch":
                    menuColor.Add("active", Color.FromRgb(191, 216, 189));
                    menuColor.Add("default", Color.FromRgb(221, 231, 199));
                    break;
                case "Dinner":
                    menuColor.Add("active", Color.FromRgb(244, 151, 142));
                    menuColor.Add("default", Color.FromRgb(251, 196, 171));
                    break;
                case "Drinks":
                    menuColor.Add("active", Color.FromRgb(124, 205, 244));
                    menuColor.Add("default", Color.FromRgb(188, 227, 250));
                    break;
                default:
                    menuColor.Add("active", Color.FromRgb(231, 218, 255));
                    menuColor.Add("default", Color.FromRgb(184, 146, 255));
                    break;
            }

            return menuColor;
        }

        /// <summary>
        /// Open the menu that allows for returning to table overview & refreshing the UI.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/11</remarks>
        private void Btn_ToggleMenu_Click(object sender, MouseButtonEventArgs e)
        {
            if (isOpen)
            {
                Lbl_Menu.Content = "MENU";
                Stack_Open.Visibility = Visibility.Collapsed;
                isOpen = false;
            }
            else
            {
                Lbl_Menu.Content = "CLOSE";
                Stack_Open.Visibility = Visibility.Visible;
                isOpen = true;
            }
        }

        /// <summary>
        /// Go back to the table overview.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Yannick, 2020/06/11</remarks>
        private void Btn_Overview_MouseDown(object sender, RoutedEventArgs e)
        {
            ParentForm.Close();
        }
    }
}
