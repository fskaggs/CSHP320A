using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using TradingCardTracker.Models;

namespace TradingCardTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        private CardModel selectedCard;

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
    }
}
