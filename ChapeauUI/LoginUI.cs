using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ChapeauModel;
using ChapeauLogic;

namespace ChapeauUI
{
    public partial class LoginUI : Form
    {
        Employee_Service employeeService;
        private Employee employee;

        public LoginUI()
        {
            InitializeComponent();
            employeeService = new Employee_Service();
        }

        /// <summary>
        /// Get the UI form based on the Employee.Role.
        /// </summary>
        /// <param name="employee">The employee that logged in.</param>
        /// <returns>The form that fulfills the role for the employee.</returns>
        /// <remarks>Samih, 2020/05/23</remarks>
        public Form EmployeeLoggedIn(Employee employee)
        {
            Form form;

            switch (employee.Role)
            {
                case Role.Bar:
                    form = new BarKitchenUI(employee);
                    break;
                case Role.Kitchen:
                    form = new BarKitchenUI(employee);
                    break;
                case Role.Manager:
                    form = new ManagerUI(employee);
                    break;
                case Role.Waiter:
                    form = new Tables(employee);
                    break;
                default:
                    ErrorUI.ShowErrorDialog($"{employee.Role} is not a valid employee role, please contact an IT specialist.");
                    form = this;
                    break;
            }

            return form;
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Program.Close();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            progressBar1.PerformStep();

            string employeeName;
            int password;

            // 1. Get value of name.
            // 2. Get the value of password.
            try
            {
                employeeName = EmployeeNameField.Text.ToLower();
                password = int.Parse(PasswordField.Text);

                progressBar1.PerformStep();
            }
            catch (Exception)
            {
                ErrorUI.ShowErrorDialog("Please only use numbers in the password!");
                progressBar1.Visible = false;
                return;
            }

            try
            {
                progressBar1.PerformStep();

                // Try to login.
                employee = employeeService.Login(employeeName, password);
                progressBar1.PerformStep();

                // Show the Employee related UI.
                Form form = EmployeeLoggedIn(employee);
                form.Show();

                // If we showed successfully: Close form.
                Hide();
            }
            catch (Exception)
            {
                ErrorUI.ShowErrorDialog("Invalid login!");
            }

            progressBar1.Value = 0;
        }

        private void LoginUI_Load(object sender, EventArgs e)
        {
        }

        private void LoginUI_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Close();
        }
    }
}
