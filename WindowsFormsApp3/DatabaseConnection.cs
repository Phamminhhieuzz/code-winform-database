using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    internal class DatabaseConnection
    {
        private static string connectionString = "Data Source=DESKTOP-7PU6JC6\\SQLEXPRESS02;Initial Catalog=sell laptop;Integrated Security=True;TrustServerCertificate=True;";


        public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);

            }catch (SqlException)
            {
                MessageBox.Show("Error while connecting to the database","Warning",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return connection;
        }
    }
}
