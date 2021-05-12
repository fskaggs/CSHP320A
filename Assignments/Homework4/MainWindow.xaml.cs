using Homework4.Models;
using System.Windows;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ZipCode zipCode = new ZipCode();

        public MainWindow()
        {
            InitializeComponent();
            stackPanelZipCode.DataContext = zipCode;
        }
    }
}
