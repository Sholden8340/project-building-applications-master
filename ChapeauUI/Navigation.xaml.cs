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
    /// Interaction logic for Navigation.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/06/07</remarks>
    public partial class Navigation : UserControl
    {
        public Navigation()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Program.Logout();
        }
    }
}
