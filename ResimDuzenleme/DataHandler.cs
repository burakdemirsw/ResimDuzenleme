using System;

using System.Data.SqlClient;
using System.IO;



namespace ResimDuzenleme
{
    public class DataHandler
    {





        private string serverName = Properties.Settings.Default.SunucuAdi;
        private string userName = Properties.Settings.Default.KullaniciAdi;
        private string password = Properties.Settings.Default.Sifre;
        private string database = Properties.Settings.Default.database;
        private string storedProcedureName = Properties.Settings.Default.StoredProcedureAdi;

        private string connectionString;

        public DataHandler()
        {
            connectionString = $"Server={serverName};Database={database};User Id={userName};Password={password};";
        }

        public void SaveData(string data)
        {
            if (TestSqlConnection())
            {
                InsertIntoSql(data);
            }
            else
            {
                SaveToTextFile(data);
            }
        }

        private bool TestSqlConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void InsertIntoSql(string data)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO YourTable (YourColumn) VALUES (@data)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@data", data);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveToTextFile(string data)
        {
            File.AppendAllText("data.txt", data + Environment.NewLine);
        }
    }
}
