using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MenuItem = ChapeauModel.MenuItem;

namespace ChapeauUI
{
    public partial class ManagerUI : Form
    {
        private Menu_Service menu_Service;
        private Employee_Service employee_Service;
        private Item_Service item_Service;
        private Order_Service order_Service;
        private Employee employee;

        public ManagerUI(Employee employee)
        {
            InitializeComponent();
            menu_Service = new Menu_Service();
            employee_Service = new Employee_Service();
            item_Service = new Item_Service();
            order_Service = new Order_Service();

            this.employee = employee;
        }

        private void PanelStock_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Manager_UI_Load(object sender, EventArgs e)
        {
            PanelHome.Dock = DockStyle.Fill;
            PanelIncome.Dock = DockStyle.Fill;
            PanelMenu.Dock = DockStyle.Fill;
            PanelStock.Dock = DockStyle.Fill;
            PanelUser.Dock = DockStyle.Fill;
            ShowPanel("home");
        }

        private void ButtonMenuIncome_Click(object sender, EventArgs e) // Income overview
        {
            ShowPanel("income");
            List<Order> orders = order_Service.GetFromToday();
            int drinksCount = 0, kitchenCount = 0;
            double lunchKitchenTotal = 0, lunchBarTotal = 0, dinnerKitchenTotal = 0, dinnerBarTotal = 0; // Total income

            // Total Orders
            int lunchMainCount = 0, lunchSpecialCount = 0, lunchBiteCount = 0;
            int dinnerMainCount = 0, dinnerDessertCount = 0, dinnerStarterCount = 0;
            int drinksSoftCount = 0, drinksHotCount = 0, drinksWineCount = 0, drinksBeerCount = 0;

            foreach (Order order in orders)
            {
                foreach (OrderItem item in order.OrderItems)
                {
                    // if time is before 17:00 menu is lunch
                    if (DateTime.Compare(item.TakenAt, DateTime.Today.AddHours(17)) < 0)
                    {
                        if (item.Item.Menu.Id == 2)
                        {
                            lunchBarTotal += item.Quantity;
                            lunchBarTotal += item.Quantity * (double)item.Item.Price;
                        }
                        else
                        {
                            kitchenCount += item.Quantity;
                            lunchKitchenTotal += item.Quantity * (double)item.Item.Price;
                        }
                    }
                    else
                    {
                        if (item.Item.Menu.Id == 2)
                        {
                            lunchBarTotal += item.Quantity;
                            dinnerBarTotal += item.Quantity * (double)item.Item.Price;
                        }
                        else
                        {
                            kitchenCount += item.Quantity;
                            dinnerKitchenTotal += item.Quantity * (double)item.Item.Price;
                        }
                    }

                    // if item is lunch or dinner
                    if (item.Item.Menu.Id == 2)
                    {
                        drinksCount += item.Quantity;
                    }
                    else
                    {
                        kitchenCount += item.Quantity;
                    }

                    switch (item.Item.Category.Id)
                    {
                        case 1: // Lunch Main
                            lunchMainCount += item.Quantity;
                            break;
                        case 2: // Lunch Special
                            lunchSpecialCount += item.Quantity;
                            break;
                        case 3: // Lunch Bites
                            lunchBiteCount += item.Quantity;
                            break;
                        case 4: // Dinner Starter
                            dinnerStarterCount += item.Quantity;
                            break;
                        case 5: // Dinner Main
                            dinnerMainCount += item.Quantity;
                            break;
                        case 6: // Dinner Dessert
                            dinnerDessertCount += item.Quantity;
                            break;
                        case 7: // Soft Drink
                            drinksSoftCount += item.Quantity;
                            break;
                        case 8: // Hot drink
                            drinksHotCount += item.Quantity;
                            break;
                        case 9: // Beer
                            drinksBeerCount += item.Quantity;
                            break;
                        case 10: // Wine
                            drinksWineCount += item.Quantity;
                            break;
                    }
                }
            }

            labelLunchMainOrders.Text = lunchMainCount.ToString();
            labelSpecialOrders.Text = lunchSpecialCount.ToString();
            labelBiteOrders.Text = lunchBiteCount.ToString();

            labelStarterOrders.Text = dinnerStarterCount.ToString();
            labelMainOrders.Text = dinnerMainCount.ToString();
            labelDessertOrders.Text = dinnerDessertCount.ToString();

            labelSoftOrders.Text = drinksSoftCount.ToString();
            labelHotOrders.Text = drinksHotCount.ToString();
            labelBeerOrders.Text = drinksBeerCount.ToString();
            labelWineOrders.Text = drinksWineCount.ToString();

            labelKitchenOrders.Text = kitchenCount.ToString();
            labelBarOrders.Text = drinksCount.ToString();

            labelKitchenLunchIncome.Text = string.Format("€{0:0.00}", lunchKitchenTotal);
            labelKitchenDinnerIncome.Text = string.Format("€{0:0.00}", dinnerKitchenTotal);

            labelBarLunchIncome.Text = string.Format("€{0:0.00}", lunchBarTotal);
            labelBarDinnerIncome.Text = string.Format("€{0:0.00}", dinnerBarTotal);

            labelKitchenIncome.Text = string.Format("€{0:0.00}", dinnerKitchenTotal + lunchKitchenTotal);
            labelBarIncome.Text = string.Format("€{0:0.00}", dinnerBarTotal + lunchBarTotal);
        }

        private void ButtonMenuStock_Click(object sender, EventArgs e) // Stock manage
        {
            ShowPanel("stock");
        }

        private void ButtonMenuUsers_Click(object sender, EventArgs e) // Users manage
        {
            ShowPanel("user");
        }

        private void ButtonMenuEditMenu_Click(object sender, EventArgs e) // Menu manage
        {
            ShowPanel("menu");
        }

        private void ShowPanel(string panelName)
        {
            PanelHome.Hide();
            PanelIncome.Hide();
            PanelMenu.Hide();
            PanelStock.Hide();
            PanelUser.Hide();

            switch (panelName.ToLower().Trim())
            {
                case "user":
                    labelTitle.Text = "User Management";
                    ShowUserPanel();
                    break;
                case "income":
                    ShowIncomePanel();
                    labelTitle.Text = "Income Overview";
                    break;
                case "stock":
                    ShowStockPanel();
                    labelTitle.Text = "Stock Management";
                    break;
                case "menu":
                    ShowMenuPanel();
                    labelTitle.Text = "Menu Management";
                    break;
                case "home":
                    ShowHomePanel();
                    labelTitle.Text = "Chapeau Managment";
                    break;
            }
        }

        private void ShowHomePanel()
        {
            PanelHome.Show();
        }

        private void ShowMenuPanel()
        {
            ShowMenuEdit("lunch_all");
            PanelMenu.Show();
        }

        private void ShowStockPanel()
        {
            PanelStock.Show();

            List<MenuItem> items = item_Service.GetAll();
            ListViewStock.Items.Clear();

            foreach (MenuItem menuItem in items)
            {
                ListViewItem li = new ListViewItem(new String[] { menuItem.Id.ToString(), menuItem.Name, menuItem.Stock.ToString() });
                ListViewStock.Items.Add(li);
                li.Tag = menuItem.Id;
            }

            ListViewStock.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // Auto resize colums to fit data
            ListViewStock.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // Make sure headers fit
        }

        private void ShowIncomePanel()
        {
            PanelIncome.Show();
        }

        private void ShowUserPanel()
        {
            groupBox1.Hide();
            comboBoxRole.Text = "Waiter";
            PanelUser.Show();
            listViewUser.Items.Clear();
            List<Employee> employees = employee_Service.GetAll();

            foreach (Employee employee in employees)
            {
                ListViewItem listViewItem = new ListViewItem(new String[] { employee.Id.ToString(), $"{employee.FirstName} {employee.LastName}", employee.Passcode.ToString(), employee.Role.ToString() });
                listViewUser.Items.Add(listViewItem);
                listViewItem.Tag = employee.Id;
            }

            listViewUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // Auto resize colums to fit data
            listViewUser.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // Make sure headers fit
        }

        private void Label1_Click(object sender, EventArgs e)
        {
        }

        private void PanelIncome_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PanelHome_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            ShowPanel("home"); // Show Home Panel. Should have more obvious way to return or switch views
        }

        private void Button_Logout_Click(object sender, EventArgs e) // Logout
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Program.Logout();
            }
        }

        private void ListViewStock_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListViewStock.SelectedIndices.Count == 0)
            {
                return;
            }

            labelName.Text = ListViewStock.SelectedItems[0].SubItems[1].Text;
            numberStock.Value = int.Parse(ListViewStock.SelectedItems[0].SubItems[2].Text);
        }

        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        { 
        }

        private void Button_Stock_Edit_Click(object sender, EventArgs e)
        {
            // Make sure an item is selected
            if (ListViewStock.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a stock item to change", "Please Select an item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MenuItem stock = item_Service.GetByMenuItemId(int.Parse(ListViewStock.SelectedItems[0].Tag.ToString()));
            stock.Stock = (int)numberStock.Value; // Change Amount

            item_Service.UpdateItem(stock);
            ShowStockPanel();
        }

        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void ListViewUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewUser.SelectedIndices.Count == 0)
            {
                return;
            }

            ShowUserEditMenu("Update");
            textBoxName.Text = listViewUser.SelectedItems[0].SubItems[1].Text;
            textBoxPasscode.Text = listViewUser.SelectedItems[0].SubItems[2].Text;
            comboBoxRole.SelectedItem = listViewUser.SelectedItems[0].SubItems[3].Text;
        }

        private void LabelName_Click(object sender, EventArgs e)
        {
        }

        private void ButtonUpdateUser_Click(object sender, EventArgs e)
        {
            Employee user;
            int passcode;

            if (buttonUpdateUser.Text == "Update User")
            {
                // Make sure an item is selected
                if (listViewUser.SelectedItems.Count == 0)
                {
                    warningMessageBox("You must select an employee to change", "Please Select an Employee");
                    return;
                }

                user = employee_Service.GetById(int.Parse(listViewUser.SelectedItems[0].Tag.ToString()));
            }
            else
            {
                user = new Employee();
            }

            // Check textbox is not empty and contains a first and last name
            if (textBoxName.Text.Length < 1 || textBoxName.Text.Split(' ').Length < 1) 
            {
                warningMessageBox("Please enter a name for the employee", "Please Enter a name");
                return;
            }
            else if (textBoxPasscode.Text.Length != 4)
            {
                warningMessageBox("Passcode should be 4 characters", "Passcode");
                return;
            }
            else if (!int.TryParse(textBoxPasscode.Text, out passcode))
            {
                warningMessageBox("Only numbers can be used in the passcode", "Passcode");
                return;
            }

            void warningMessageBox(string message, string title)
            {
                MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            string[] names = textBoxName.Text.Split(' ');
            user.FirstName = names[0];
            user.Passcode = passcode;
            
            if (!(buttonUpdateUser.Text == "Update User"))
            {
                user.Id = int.Parse(listViewUser.Items[listViewUser.Items.Count - 1].SubItems[0].Text.ToString());
                user.Id++; // Database doesn't auto increment Id
            }

            for (int i = 1; i < names.Length; i++)
            {
                user.LastName = names[i]; // In case user has more than 1 last name
            }

            user.Passcode = int.Parse(textBoxPasscode.Text);
            Enum.TryParse(comboBoxRole.SelectedItem.ToString(), out Role role);
            user.Role = role;

            if (groupBox1.Text == "Update User")
            {
                employee_Service.UpdateEmployee(user);
            }
            else if (groupBox1.Text == "Add New User")
            {
                employee_Service.AddEmployee(user);
            }

            ShowUserPanel();
        }

        private void GroupBox1_Enter_1(object sender, EventArgs e)
        {
        }

        private void ButtonAddNewUser_Click(object sender, EventArgs e)
        {
            ShowUserEditMenu("Add");
        }

        private void ShowUserEditMenu(string type)
        {
            groupBox1.Show();
            switch (type.ToLower().Trim())
            {
                case "add":
                    groupBox1.Text = "Add New User";
                    buttonUpdateUser.Text = "Add New User";
                    buttonDeleteUser.Hide();
                    break;
                case "update":
                    buttonDeleteUser.Show();
                    groupBox1.Text = "Update User";
                    buttonUpdateUser.Text = "Update User";
                    break;
            }
        }

        private void ButtonDeleteUser_Click(object sender, EventArgs e)
        {
            // Maybe check ifmore than one manager?
            if (MessageBox.Show($"Are you sure you want to delete the user {textBoxName.Text}?", "Delete User", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            Employee user = employee_Service.GetById(int.Parse(listViewUser.SelectedItems[0].Tag.ToString()));

            employee_Service.RemoveEmployee(user.Id);
            ShowUserPanel();
        }

        private void LabelDrinksAll_Click(object sender, EventArgs e) // Drinks
        {
            ShowMenuEdit("drinks_all");
        }

        private void LabelLunchMain_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("lunch_main");
        }

        private void LabelSpecial_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("special");
        }

        private void LabelBites_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("bites");
        }

        private void LabelStarter_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("starter");
        }

        private void LabelDinnerMain_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("dinner_main");
        }

        private void LabelDesserts_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("dessert");
        }

        private void LabelDrinkSoft_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("drink_soft");
        }

        private void LabelDrinkHot_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("drink_hot");
        }

        private void LabelDrinkBeer_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("drink_beer");
        }

        private void LabelDrinkWine_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("drink_wine");
        }

        private void ShowMenuEdit(string menu)
        {
            List<MenuItem> items;
            labelLunchMain.ForeColor = MenuColourDeselected();
            labelSpecial.ForeColor = MenuColourDeselected();
            labelBites.ForeColor = MenuColourDeselected();
            labelStarter.ForeColor = MenuColourDeselected();
            labelDinnerMain.ForeColor = MenuColourDeselected();
            labelDesserts.ForeColor = MenuColourDeselected();
            labelDrinkSoft.ForeColor = MenuColourDeselected();
            labelDrinkHot.ForeColor = MenuColourDeselected();
            labelDrinkBeer.ForeColor = MenuColourDeselected();
            labelDrinkWine.ForeColor = MenuColourDeselected();
            labelDinnerAll.ForeColor = MenuColourDeselected();
            labelLunchAll.ForeColor = MenuColourDeselected();
            labelDrinksAll.ForeColor = MenuColourDeselected();
            buttonAddMenu.Show(); 
            buttonAddMenu.Show(); 
            buttonUpdateMenu.Show();

            switch (menu)
            {
                case "lunch_main":
                    labelLunchMain.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Lunch Mains";
                    items = item_Service.GetByMenuCategoryId(1);
                    break;
                case "special":
                    labelSpecial.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Specials";
                    items = item_Service.GetByMenuCategoryId(2);
                    break;
                case "bites":
                    labelBites.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Bites";
                    items = item_Service.GetByMenuCategoryId(3);
                    break;
                case "starter":
                    labelStarter.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Starters";
                    items = item_Service.GetByMenuCategoryId(4);
                    break;
                case "dinner_main":
                    labelDinnerMain.ForeColor = MenuColourSelected();
                    items = item_Service.GetByMenuCategoryId(5);
                    labelMenuTitle.Text = "Dinner Mains";
                    break;
                case "dessert":
                    labelDesserts.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Desserts";
                    items = item_Service.GetByMenuCategoryId(6);
                    break;
                case "drink_soft":
                    labelDrinkSoft.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Soft Drinks";
                    items = item_Service.GetByMenuCategoryId(7);
                    break;
                case "drink_hot":
                    labelDrinkHot.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Hot Drinks";
                    items = item_Service.GetByMenuCategoryId(8);
                    break;
                case "drink_beer":
                    labelDrinkBeer.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Beers";
                    items = item_Service.GetByMenuCategoryId(9);
                    break;
                case "drink_wine":
                    labelDrinkWine.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Wines";
                    items = item_Service.GetByMenuCategoryId(10);
                    break;
                case "drinks_all":
                    labelDrinksAll.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Drinks";
                    items = item_Service.GetByMenuId(2);
                    break;
                case "dinner_all":
                    labelDinnerAll.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Dinner";
                    items = item_Service.GetByMenuId(1);
                    break;
                case "lunch_all":
                    labelLunchAll.ForeColor = MenuColourSelected();
                    labelMenuTitle.Text = "Lunch";
                    items = item_Service.GetByMenuId(0);
                    break;

                default:
                    items = item_Service.GetAll();
                    break;
            }

            Color MenuColourSelected() 
            { 
                return Color.FromArgb(231, 218, 255); 
            }
            
            Color MenuColourDeselected() 
            { 
                return Color.FromArgb(69, 65, 77); 
            }

            listViewMenu.Items.Clear();

            foreach (MenuItem menuItem in items)
            {
                ListViewItem li = new ListViewItem(new String[] { menuItem.Name, String.Format("€{0:0.00}", menuItem.Price), menuItem.Category.Name }); // Catgorey doesn't work
                listViewMenu.Items.Add(li);
                li.Tag = menuItem.Id;
            }

            listViewMenu.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); // Auto resize colums to fit data
            listViewMenu.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // Make sure headers fit
        }

        private void ChangeMenuItem()
        {
            if (listViewMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a menu item to change", "Please Select an item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MenuItem item = item_Service.GetById(int.Parse(listViewMenu.SelectedItems[0].Tag.ToString()));
            item.Category.Name = comboBoxMenuCategory.Text;
            item.Name = textBoxMenuName.Text;
            item.Price = numericUpDownMenuPrice.Value;
            item_Service.UpdateItem(item);
            ShowMenuPanel();
        }

        private void AddMenuItem()
        {
            int taxCategory = 0;
            if (comboBoxMenuCategory.Text.Equals("Beer") || comboBoxMenuCategory.Text.Equals("Wine"))
            {
                taxCategory = 1;
            }

            MenuItem newItem = new MenuItem
            {
                Name = textBoxMenuName.Text,
                Stock = 0,
                Price = numericUpDownMenuPrice.Value,
                Category = new MenuCategory { Name = comboBoxMenuCategory.Text },
                TaxCategory = new TaxCategory { Id = taxCategory }
            };

            item_Service.Store(newItem);
            ShowMenuPanel();
        }

        private void DeleteMenuItem()
        {
            if (listViewMenu.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select a menu item to change", "Please Select an item", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to delete the menuItem {textBoxName.Text}?", "Delete Menu Item", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            item_Service.RemoveItem(int.Parse(listViewMenu.SelectedItems[0].Tag.ToString()));
            ShowMenuPanel();
        }

        private void SplitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Label12_Click(object sender, EventArgs e)
        {
        }

        private void ButtonAddMenu_Click(object sender, EventArgs e)
        {
            AddMenuItem();
        }

        private void ButtonUpdateMenu_Click(object sender, EventArgs e)
        {
            ChangeMenuItem();
        }

        private void ButtonDeleteMenu_Click(object sender, EventArgs e)
        {
            DeleteMenuItem();
        }

        private void LabelLunchAll_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("lunch_all");
        }

        private void LabelDinnerAll_Click(object sender, EventArgs e)
        {
            ShowMenuEdit("dinner_all");
        }

        private void PanelMenu_Paint(object sender, PaintEventArgs e)
        {
        }

        private void SplitContainerMenuNav_Panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ListViewMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewMenu.SelectedIndices.Count == 0)
            {
                return;
            }

            textBoxMenuName.Text = listViewMenu.SelectedItems[0].SubItems[0].Text;
            numericUpDownMenuPrice.Value = decimal.Parse(listViewMenu.SelectedItems[0].SubItems[1].Text.Split('€')[1]);
            comboBoxMenuCategory.SelectedItem = listViewMenu.SelectedItems[0].SubItems[2].Text;
        }

        private void GroupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void Label19_Click(object sender, EventArgs e)
        {
        }

        private void Label20_Click(object sender, EventArgs e)
        {
        }

        private void Label21_Click(object sender, EventArgs e)
        {
        }

        private void Label18_Click(object sender, EventArgs e)
        {
        }

        private void Label13_Click(object sender, EventArgs e)
        {
        }

        private void Label14_Click(object sender, EventArgs e)
        {
        }

        private void Label15_Click(object sender, EventArgs e)
        {
        }

        private void Label16_Click(object sender, EventArgs e)
        {
        }

        private void Label31_Click(object sender, EventArgs e)
        {
        }

        private void TextBoxMenuName_TextChanged(object sender, EventArgs e)
        {
        }
    }
}