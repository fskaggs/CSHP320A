using SharedComponents;
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
using TradingCardTracker.Models;

namespace TradingCardTracker
{
    /// <summary>
    /// Interaction logic for CardWindow.xaml
    /// </summary>
    public partial class CardWindow : Window
    {
        public CardWindow()
        {
            InitializeComponent();
            ShowInTaskbar = false;

            uxCondition.ItemsSource = Enum.GetValues(typeof(SharedComponents.Condition)).Cast<SharedComponents.Condition>();
            uxCardType.ItemsSource = Enum.GetValues(typeof(SharedComponents.CardType)).Cast<SharedComponents.CardType>();
        }

        public CardModel Card { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            Card.TypeOfCard = (CardType)uxCardType.SelectedItem;
            DialogResult = true;
            Close();
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            // This is the return value of ShowDialog( ) below
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Card != null)
            {
                uxCardWindowAction.Text = "Updating An Existing Trading Card";
                uxCardType.SelectedItem = Card.TypeOfCard;
                uxSubmit.Content = "Save Updates";
            }
            else
            {
                Card = new CardModel();
                uxCardWindowAction.Text = "Adding A New Trading Card";
                uxCardType.SelectedItem = CardType.Movie;
                uxSubmit.Content = "Add Card";
            }

            uxGrid.DataContext = Card;
        }
    }
}
