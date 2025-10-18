using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDattendanceSystem.database
{
    public class DatabaseConnector
    {
        public String connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public string GetConnection()
            { 
            return connectionString ?? string.Empty;
            }
    }
}
