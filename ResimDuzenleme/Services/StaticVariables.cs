using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services
{
    public  class ConnectionString
    {
         string serverName = "192.168.1.37";
         string userName = "sa";
         string password = "1524";
         string database = "assur";
         string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

        public string GetConnectionString()
        {
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password}";

            return connectionString;
        }

    }
}
