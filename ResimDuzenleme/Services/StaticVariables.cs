using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResimDuzenleme.Services
{
    public  class ConnectionString
    {
        string serverName = Properties.Settings.Default.SunucuAdi;
        string userName = Properties.Settings.Default.KullaniciAdi;
        string password = Properties.Settings.Default.Sifre;
        string database = Properties.Settings.Default.database;
        string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

        public string GetConnectionString()
        {
            string connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password}";

            return connectionString;
        }

    }
}
