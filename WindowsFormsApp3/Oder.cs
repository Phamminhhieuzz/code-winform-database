using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp3
{
    public partial class Oder : Form
    {
        private string authorityLevel;
        private int userId;

        public Oder()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Oder_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndowload_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-7PU6JC6\SQLEXPRESS02;Initial Catalog='sell laptop';Integrated Security=True";
            // Câu truy vấn để lấy dữ liệu
            string query = "SELECT * FROM Orders";

            // Kết nối với cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Mở kết nối
                    connection.Open();

                    // Tạo SqlDataAdapter để thực hiện truy vấn
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Tạo DataTable để chứa dữ liệu
                    DataTable dataTable = new DataTable();

                    // Điền dữ liệu từ adapter vào DataTable
                    adapter.Fill(dataTable);

                    // Gán DataTable vào DataGridView
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có
                    MessageBox.Show("Lỗi: " + ex.Message);
                }


            }
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form2 adminForm = new Form2(this.authorityLevel, this.userId);
            this.Hide();
            adminForm.Show();
        }
    }
}
    

