using System.Windows.Controls;

namespace ChapeauUI
{
    /// <summary>
    /// Interaction logic for OrderItemCommentUI.xaml
    /// </summary>
    /// <remarks>Yannick, 2020/06/09</remarks>
    public partial class OrderItemCommentUI : UserControl
    {
        /// <summary>
        /// Show the comment of a order.
        /// </summary>
        /// <param name="comment">The comment to display.</param>
        /// <remarks>Yannick, 2020/06/09</remarks>
        public OrderItemCommentUI(string comment)
        {
            InitializeComponent();
            Lbl_OrderComment.Text = comment;
        }
    }
}
