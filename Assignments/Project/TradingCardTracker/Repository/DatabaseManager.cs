using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardDB;

namespace Repository
{
    class DatabaseManager
    {
        private static readonly TradingCardDBContext entities;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            entities = new TradingCardDBContext();
        }

        // Provide an accessor to the database
        public static TradingCardDBContext Instance
        {
            get
            {
                return entities;
            }
        }
    }
}
