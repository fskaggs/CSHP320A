using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DatabaseManager
    {
        private static readonly RepositoryDBContext dBContext;

        // Initialize and open the database connection
        static DatabaseManager()
        {
            dBContext = new RepositoryDBContext();
        }

        // Provide an accessor to the database
        public static RepositoryDBContext DBContext
        {
            get
            {
                return dBContext;
            }
        }
    }
}
