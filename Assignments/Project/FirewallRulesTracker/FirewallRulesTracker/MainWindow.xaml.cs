using FirewallRulesTracker.ViewModels;
using Repository.Models;
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

namespace FirewallRulesTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FirewallRulesViewModel ViewModel = new FirewallRulesViewModel();

        public MainWindow()
        {
            InitializeComponent();

            DataContext = ViewModel;
            uxRuleList.DataContext = ViewModel.FWRules;
            uxRuleList.ItemsSource = ViewModel.FWRules;
        }

        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var Rule = new FWRuleEntity()
            {
                Direction = DataDirection.Inbound,
                Port = 80,
                Protocol = ProtocolType.TCP,
                RoleID = 2,
                SRA = "SRA06052021",
                WorkItem = "VSO93533",
                Version = 1
            };

            ViewModel.fwRepo.Add(Rule);
            ViewModel.fwRepo.Get(2);
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {

        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
