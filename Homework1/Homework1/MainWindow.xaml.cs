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

namespace Homework1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int passwordStrength { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            uxName.Focus();
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            string strength = (passwordStrength < 40) ? "not very strong" : "strong";
            string message = $"Hello, {uxName.Text}\nYou entered password: {uxPassword.Text}\nYour password is {strength}";
            MessageBox.Show(message);
        }

        private void ux_InputRecieved(object sender, TextChangedEventArgs e)
        {
            TextBox tb = sender as TextBox;

            if (tb.Name == "uxPassword")
            {
                string password = uxPassword.Text;
                int upperScore = password.Where(x => char.IsUpper(x)).Count<char>() > 0 ? 10 : 0;
                int lowerScore = password.Where(x => char.IsLower(x)).Count<char>() > 0 ? 10 : 0;
                int digitScore = password.Where(x => char.IsDigit(x)).Count<char>() > 0 ? 10 : 0;
                passwordStrength = Math.Clamp(password.Length, 0, 20) + upperScore + lowerScore + digitScore;
                progBarPwdStr.Value = passwordStrength;
            }

            if (!string.IsNullOrEmpty(uxName.Text) && !string.IsNullOrEmpty(uxPassword.Text))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }
    }
}
