using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Repository;

namespace TradingCardTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static CardRepository cardRepository;

        static App()
        {
            cardRepository = new CardRepository();
        }

        public static CardRepository CardRepository
        {
            get
            {
                return cardRepository;
            }
        }
    }
}
