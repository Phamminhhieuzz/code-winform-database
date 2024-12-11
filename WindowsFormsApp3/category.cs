using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class category : Form
    {
        private string connectionString = @"Data Source=DESKTOP-7PU6JC6\SQLEXPRESS02;Initial Catalog=sell laptop;Integrated Security=True;TrustServerCertificate=True;";
        public category()
        {
            InitializeComponent();
            
        }

        private void dtgcategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndowload_Click(object sender, EventArgs e)
        {
            LoadCategoryData();
        }
        private void LoadCategoryData()
        {
            // SQL query to fetch data from the category table
            string query = "SELECT * FROM Category"; // Replace 'Category' with your actual table name

            // Create a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Use SqlDataAdapter to fetch data
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Fill a DataTable with the retrieved data
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dtgcategory.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Display an error message in case of any exception
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
    

