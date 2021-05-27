using System.Windows;

namespace ChapeauUI
{
    /// <summary>
    /// The error UI elements of the Chapeau application.
    /// </summary>
    /// <remarks>Yannick, 2020/06/09</remarks>
    public class ErrorUI
    {
        /// <summary>
        /// Show a error model, to inform the user something went wrong.
        /// </summary>
        /// <param name="errorMessage">The message to display.</param>
        /// <remarks>Yannick, 2020/06/09</remarks>
        public static void ShowErrorDialog(string errorMessage)
        {
            MessageBox.Show(
                errorMessage,
                "Something went wrong!",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}
