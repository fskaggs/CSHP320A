using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TradingCardTracker.Models;

namespace TradingCardTracker
{
    public enum SearchBy
    {
        None,
        CardNumber,
        CardTitle,
        CardFranchise
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private CardModel selectedCard;
        private SearchBy SearchFilterType { get; set; }
        private string ValueToFind { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            LoadCards();
        }

        private void LoadCards()
        {
            var cards = App.CardRepository.GetAll();

            uxCardList.ItemsSource = cards
                .Select(t => CardModel.ToModel(t))
                .ToList();

            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxCardList.ItemsSource);
            switch (SearchFilterType)
            {
                case SearchBy.CardNumber: { view.Filter = CardNumberFilter; break; }
                case SearchBy.CardTitle: { view.Filter = CardTitleFilter; break; }
                case SearchBy.CardFranchise: { view.Filter = CardFranchiseFilter; break; }
                default: { view.Filter = null; break; }
            }

            uxCardsLoaded.Text = $"Number of Cards Available: {uxCardList.Items.Count}";
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new CardWindow();

            if (window.ShowDialog() == true)
            {
                var uiCardModel = window.Card;

                var repositoryCardModel = CardModel.ToRepositoryModel(uiCardModel);

                App.CardRepository.Add(repositoryCardModel);

                LoadCards();
            }
        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new CardWindow();

            if (selectedCard != null)
            {
                CardModel cardClone = selectedCard.Clone() as CardModel;
                window.Card = cardClone;


                if (window.ShowDialog() == true)
                {
                    App.CardRepository.Update(CardModel.ToRepositoryModel(cardClone));
                    LoadCards();
                }
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedCard != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxCardsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                uxCardList.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            uxCardList.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        public class SortAdorner : System.Windows.Documents.Adorner
        {
            private static Geometry ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                    (
                        AdornedElement.RenderSize.Width - 15,
                        (AdornedElement.RenderSize.Height - 5) / 2
                    );
                drawingContext.PushTransform(transform);

                Geometry geometry = ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }

        private void uxCardList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedCard = (CardModel)uxCardList.SelectedValue;
            if (selectedCard != null)
            {
                uxDetailTitle.Text = selectedCard.Title;
                uxDetailType.Text = Enum.GetName(selectedCard.TypeOfCard);
                uxDetailFranchise.Text = selectedCard.CardFranchise;
                uxDetailCardCount.Text = selectedCard.CardCount.ToString();
                uxDetailReleaseYear.Text = selectedCard.ReleaseYear;
                uxDetailValue.Text = selectedCard.Value.ToString();
                uxDetailNotes.Text = selectedCard.Notes;
                uxDetailsPanel.Visibility = Visibility.Visible;
                uxCardImage.Visibility = Visibility.Visible;

                // Convert the image from a byte array back to a displayable image type
                if (selectedCard.Image != null)
                    uxCardImage.Source = (BitmapSource)new ImageSourceConverter().ConvertFrom(selectedCard.Image);
                else
                    uxCardImage.Source = null;
            }
            else
            {
                uxDetailsPanel.Visibility = Visibility.Hidden;
                uxCardImage.Visibility = Visibility.Hidden;
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.CardRepository.Remove(selectedCard.CardID);
            selectedCard = null;
            LoadCards();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedCard != null);
            uxContextFileDelete.IsEnabled = (selectedCard != null);
        }

        private BitmapSource ByteArrayToBitmapSource(byte[] image)
        {
            using (var stream = new System.IO.MemoryStream(image))
            {
                var encoder = new JpegBitmapEncoder();
                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                return bitmap;
            }
        }

        private void uxFileExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxCardList_Loaded(object sender, RoutedEventArgs e)
        {
            uxCardsLoaded.Text = $"Number of Cards Available: {uxCardList.Items.Count}";
        }

        private void uxSearchByCardTitle_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchByCardNumber(SearchBy.CardTitle);
            SearchFilterType = SearchBy.CardTitle;

            if (window.ShowDialog() == true)
            {
                ValueToFind = window.uxValueToFind.Text;
                LoadCards();
            }
        }

        private void uxSearchByCardNumber_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchByCardNumber(SearchBy.CardNumber);
            SearchFilterType = SearchBy.CardNumber;

            if (window.ShowDialog() == true)
            {
                ValueToFind = window.uxValueToFind.Text;
                LoadCards();
            }
        }

        private void uxSearchByCardFranchise_Click(object sender, RoutedEventArgs e)
        {
            var window = new SearchByCardNumber(SearchBy.CardFranchise);
            SearchFilterType = SearchBy.CardFranchise;

            if (window.ShowDialog() == true)
            {
                ValueToFind = window.uxValueToFind.Text;
                LoadCards();
            }
        }

        private bool CardNumberFilter(object item)
        {
            if (string.IsNullOrEmpty(ValueToFind))
                return true;
            else
                return (item as CardModel).CardNumber.ToString().IndexOf(ValueToFind, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool CardTitleFilter(object item)
        {
            if (string.IsNullOrEmpty(ValueToFind))
                return true;
            else
                return (item as CardModel).Title.IndexOf(ValueToFind, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private bool CardFranchiseFilter(object item)
        {
            if (string.IsNullOrEmpty(ValueToFind))
                return true;
            else
                return (item as CardModel).CardFranchise.IndexOf(ValueToFind, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        private void uxSearchClearFilter_Click(object sender, RoutedEventArgs e)
        {
            ValueToFind = string.Empty;
            SearchFilterType = SearchBy.None;
            LoadCards();
        }
    }
}
