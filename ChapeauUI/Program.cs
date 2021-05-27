using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;

namespace ChapeauUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginUI());
        }

        public static void Logout()
        {
            List<Form> openForms = new List<Form>();

            foreach (Form form in Application.OpenForms)
            {
                openForms.Add(form);
            }

            foreach (Form form in openForms)
            {
                if (form.Name != "LoginUI")
                {
                    form.Close();
                }
            }

            // Show the Login UI
            LoginUI loginUI = new LoginUI();
            loginUI.ShowDialog();
        }

        public static void Close()
        {
            Application.Exit();
        }
    }
}
