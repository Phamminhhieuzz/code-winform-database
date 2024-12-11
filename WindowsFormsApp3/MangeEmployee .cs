using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;



namespace WindowsFormsApp3
{
    public partial class MangeEmployee : Form

    {

        SqlConnection con;

        public int EmployeeId { get; set; } = 0;
        public string EmployeePosition { get; set; }

        // Constructor mặc định
        public MangeEmployee() : this("Default Position")
        {

        }

        // Constructor có tham số
        public MangeEmployee(string employeePosition)
        {
            InitializeComponent();
            this.EmployeePosition = employeePosition;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void MangeEmployee_Load(object sender, EventArgs e)
        {

        }

        // Thêm sự kiện chuyển đổi form từ một nút
        private void buttonSwitchForm_Click(object sender, EventArgs e)
        {
            // Tạo instance của form khác, ví dụ: Form2
            Form2 form2 = new Form2("Manager", EmployeeId); // Truyền dữ liệu cần thiết qua constructor
            form2.Show(); // Hiển thị form mới
            this.Hide(); // Ẩn form hiện tại (nếu cần quay lại sau)
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close(); // Đóng form
        }

        private void dtgEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndowload_Click(object sender, EventArgs e)
        {
            try
            {
                NewMethod();

                var dataAdapter = new SqlDataAdapter("Select * from Employee", con);
                var commandBuilder = new SqlCommandBuilder(dataAdapter);
                var ds = new DataSet();
                dataAdapter.Fill(ds);
                DataGridView1.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void NewMethod()
        {
            con = new SqlConnection("server=DESKTOP-7PU6JC6\\SQLEXPRESS02;database=sell laptop;Trusted_Connection=True");
            con.Open();
        }

        private void DataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (DataGridView1.SelectedRows.Count == 1)
            {
                string id = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string first = DataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                string last = DataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                string email = DataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                string phone = DataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                string date = DataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                string address = DataGridView1.SelectedRows[0].Cells[6].Value.ToString();

                txtEmployeeCode.Text = id;
                txtEmployeeFirst.Text = first;
                txtEmployeeLast.Text = last;
                txtEmployeeAddress.Text = address;
                txtEmployeePhone.Text = phone;
                txtEmployeeDate.Text = date;
                txtEmployeeEmail.Text = email;
            }
        }

        [Obsolete]
        private void btnAdd_Click(object sender, EventArgs e)
        {
            String query = "INSERT INTO dbo.Employee (First_name, Last_name, Email, Phone, Hire_date, Address) VALUES (@First_name, @Last_name, @Email, @Phone, @Hire_date, @Address)";
            string insertQuery = "INSERT INTO Employee (First_name, Last_name, Email, Phone, Hire_date, Address) VALUES (@First_name, @Last_name, @Email, @Phone, @Hire_date, @Address)";
            SqlCommand insertCommand = new SqlCommand(insertQuery, con);
            insertCommand.Parameters.AddWithValue("@First_name", txtEmployeeFirst.Text);
            insertCommand.Parameters.AddWithValue("@Last_name", txtEmployeeLast.Text);
            insertCommand.Parameters.AddWithValue("@Email", txtEmployeeEmail.Text);
            insertCommand.Parameters.AddWithValue("@Phone", txtEmployeePhone.Text);
            insertCommand.Parameters.AddWithValue("@Hire_date", txtEmployeeDate.Text);
            insertCommand.Parameters.AddWithValue("@Address", txtEmployeeAddress.Text);

            int rowsAffected = insertCommand.ExecuteNonQuery();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                // Kết nối cơ sở dữ liệu
                SqlConnection connection = DatabaseConnection.GetConnection();
                if (connection == null)
                {
                    MessageBox.Show("Failed to establish database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Kiểm tra dòng được chọn
                if (DataGridView1.SelectedRows.Count == 1)
                {
                    string employeeId = DataGridView1.SelectedRows[0].Cells[0].Value.ToString();

                    // Xác nhận xóa
                    DialogResult confirm = MessageBox.Show($"Do you want to delete Employee ID: {employeeId}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        string sql = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeID", employeeId);

                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btndowload_Click(sender, e); // Cập nhật lại dữ liệu
                            }
                            else
                            {
                                MessageBox.Show("No matching EmployeeID found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a single row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (DatabaseConnection.GetConnection().State == ConnectionState.Open)
                {
                    DatabaseConnection.GetConnection().Close();
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2("authorityLevel", 123);
            form2.Show();
            this.Close();
        }
    }
}
