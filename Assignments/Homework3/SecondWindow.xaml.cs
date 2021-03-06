//CSHP320A
//Frederick J. Skaggs - Homework 3

using Homework3.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace Homework3
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();

            var users = new List<User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
        }

        private void NameColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private void PasswordColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
            view.SortDescriptions.Clear();
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }
    }
}
