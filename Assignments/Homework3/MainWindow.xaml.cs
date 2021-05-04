//CSHP320A
//Frederick J. Skaggs - Homework 3
// See SecondWindow.xaml and SecondWindow.xaml.cs

using System.Windows;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }
    }
}
