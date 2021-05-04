//CSHP320A
//Frederick J. Skaggs - Homework 1

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly int STRONG_PASSWORD_MIN = 35;

        public int passwordStrength { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            uxName.Focus();
        }

        /// <summary>
        /// Handle the UI button click by presenting a brief hello message, the entered password and
        /// a simple grading of the password strength.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            string strength = (passwordStrength < STRONG_PASSWORD_MIN) ? "not very strong" : "strong";
            string message = $"Hello, {uxName.Text}\nYou entered password: {uxPassword.Text}\nYour password is {strength}";
            MessageBox.Show(message);
        }

        private void ux_InputRecieved(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            // Ensure the button is only enabled if the user name and password are entered.
            if (!string.IsNullOrEmpty(uxName.Text) && !string.IsNullOrEmpty(uxPassword.Text))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }

            // Perform a basic password strength calculation if letters are added or removed from the password box
            // and update the progress bar with the current relative strength display. Just for fun.
            if (tb.Name == "uxPassword")
            {
                string password = uxPassword.Text;
                int upperScore = password.Where(x => char.IsUpper(x)).Count<char>() > 0 ? 10 : 0;
                int lowerScore = password.Where(x => char.IsLower(x)).Count<char>() > 0 ? 10 : 0;
                int digitScore = password.Where(x => char.IsDigit(x)).Count<char>() > 0 ? 10 : 0;
                passwordStrength = Math.Min(20, password.Length) + upperScore + lowerScore + digitScore;
                progBarPwdStr.Value = passwordStrength;
                progBarPwdStr.Foreground = passwordStrength > STRONG_PASSWORD_MIN ? Brushes.Green : Brushes.Red;
            }
        }
    }
}
