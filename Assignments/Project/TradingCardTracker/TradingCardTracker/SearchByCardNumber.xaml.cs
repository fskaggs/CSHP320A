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
using System.Windows.Shapes;

namespace TradingCardTracker
{
    /// <summary>
    /// Interaction logic for SearchByCardNumber.xaml
    /// </summary>
    public partial class SearchByCardNumber : Window
    {
        public SearchByCardNumber(SearchBy SearchType = SearchBy.CardNumber)
        {
            InitializeComponent();

            switch(SearchType)
            {
                case SearchBy.CardNumber:
                    {
                        this.Title = "Search by Card Number";
                        xSearchMsg.Text = "Enter the Card Number to search for:";
                        break;
                    }
                case SearchBy.CardTitle:
                    {
                        this.Title = "Search by Card Title";
                        xSearchMsg.Text = "Enter the Card Title to search for:";
                        break;
                    }
                case SearchBy.CardFranchise:
                    {
                        this.Title = "Search by Card Franchise";
                        xSearchMsg.Text = "Enter the Card franchise name to search for:";
                        break;
                    }
            }
        }

        private void Button_ClickSearchCardNumber(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
