
using System;
using System.Data.SqlClient;

namespace Luxe_Studio
{
    internal class Database
    {
        // DATABASE CONNECTION STRING
        public static string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        // GET DATABASE CONNECTION
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // TEST DATABASE CONNECTION
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection con = GetConnection())
                {
                    con.Open();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
