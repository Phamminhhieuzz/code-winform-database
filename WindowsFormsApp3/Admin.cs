using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        int employeeId;
        string authorityLevel;
        

        public Form2( string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;

        }

        public Form2(int employeeId)
        {
            this.employeeId = employeeId;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnproduct_Click(object sender, EventArgs e)
        {
            product product = new product(this.authorityLevel, (int)this.employeeId);
            this.Hide();
            product.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMangeEmployee_Click(object sender, EventArgs e)
        {
            MangeEmployee mangeEmployee = new MangeEmployee();
            this.Hide();
            mangeEmployee.Show();
        }

        private void btncustomer_Click(object sender, EventArgs e)
        {
            // Tạo một đối tượng customer (form)
            customer customerForm = new customer();

            // Ẩn form hiện tại
            this.Hide();

            // Hiển thị form customer
            customerForm.Show();
        }

        private void Btnoder_Click(object sender, EventArgs e)
        {
            Oder oderForm = new Oder();

            // Hiển thị form Oder (chế độ không chặn form chính)
            oderForm.Show();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void btncategory_Click(object sender, EventArgs e)
        {

        }
    }
}







