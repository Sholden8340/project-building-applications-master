using System;
using System.Windows.Controls;
using MenuItem = ChapeauModel.MenuItem;

namespace ChapeauUI
{
    /// <summary>
    /// Interaction logic for AddWithCommentUI.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/06/09</remarks>
    public partial class AddWithCommentUI : UserControl
    {
        /// <summary>
        /// Constructor for the AddWithCommentUI.
        /// </summary>
        /// <param name="submitHandler">The method that handles adding with comment.</param>
        /// <param name="menuItem">The menu item that the comment is being added to.</param>
        /// <param name="cancelHandler">The method that handles the user clicking cancel.</param>
        /// <remarks>Yannick, 2020/06/09</remarks>
        public AddWithCommentUI(Action<MenuItem, int, string> submitHandler, MenuItem menuItem, Action cancelHandler)
        {
            InitializeComponent();

            // Save a reference to the menu item.
            MenuItem = menuItem;

            // Add the handlers to the click event of the relevant button.
            Btn_AddWithComment.Click += (sender, e) => submitHandler(MenuItem, 1, Inp_Comments.Text);
            Btn_Cancel.Click += (sender, e) => cancelHandler();
        }

        /// <summary>
        /// The menu item that the comment is being added to.
        /// </summary>
        /// <remarks>Yannick, 2020/06/09</remarks>
        public MenuItem MenuItem { get; set; }
    }
}
