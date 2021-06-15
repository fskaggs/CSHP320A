using Microsoft.Win32;
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

        private void uxUpload_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            openFileDialog.Filter = "JPEG Files (*.jpg)|*.jpg;*.jpeg";
            openFileDialog.DefaultExt = ".jpg";
            string fileName = openFileDialog.FileName;

            if (fileName != string.Empty)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(fileName));
                byte[] image = BitmapSourceToByteArray(bitmap);
                Card.Image = image;
            }
        }

        private byte[] BitmapSourceToByteArray(BitmapSource image)
        {
            using (var stream = new System.IO.MemoryStream())
            {
                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(image));
                encoder.Save(stream);
                return stream.ToArray();
            }
        }
    }
}
