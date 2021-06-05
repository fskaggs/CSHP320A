using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseManager
    {
        private static readonly FWDBContext dBContext;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            dBContext = new FWDBContext();
        }

        // Provide an accessor to the database
        public static FWDBContext DBContext
        {
            get
            {
                return dBContext;
            }
        }
    }
}
