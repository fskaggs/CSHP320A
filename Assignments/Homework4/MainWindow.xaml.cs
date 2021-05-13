using System.Text.RegularExpressions;
using System.Windows;

namespace Homework4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void tbZipCode_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            bool code = false;
            Regex regexZipCode = new Regex(@"^[0-9]{5}(?:-[0-9]{4})?$");
            Regex regexPostCode = new Regex(@"^(?!.*[DFIOQU])[A-VXY][0-9][A-Z]●?[0-9][A-Z][0-9]$");
            string postCode = tbZipCode.Text.ToUpper();
            
            if (string.IsNullOrEmpty(postCode) == false)
            {
                code = regexZipCode.IsMatch(postCode) | regexPostCode.IsMatch(postCode);
            }
          
            btnZipCode.IsEnabled = code;
        }
    }
}
