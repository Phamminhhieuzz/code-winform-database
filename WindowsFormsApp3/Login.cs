using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            InitializeCombobox();
        }


        private void InitializeCombobox()
        {
            cbRole.Items.AddRange(new string[] { "Admin", "Warehouse", "Sale" });
            cbRole.SelectedIndex = 0;
        }

        private bool ValidateData(string username, string password, string role)
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show(
                    "Username cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show(
                    "Password cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(role))
            {
                MessageBox.Show(
                    "No role selected",
                    "Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                isValid = false;
                cbRole.Focus();
            }

            return isValid;
        }
        

        private void ShowErrorMessage(string message, Control controlToFocus)
        {
            MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            controlToFocus.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            // Lấy dữ liệu từ đầu vào của người dùng
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string role = cbRole.SelectedItem?.ToString();

            // Xác thực dữ liệu
            bool isValid = ValidateData(username, password, role);

            if (isValid)
            {
                // Mở kết nối đến cơ sở dữ liệu
                SqlConnection connection = DatabaseConnection.GetConnection();

                if (connection != null)
                {
                    // Truy vấn để xác thực thông tin đăng nhập
                    string query = @"
                SELECT EmployeeId, PasswordChanged 
                FROM Employee 
                WHERE Username = @username 
                AND Password = @password 
                AND AuthorityLevel = @role";

                    connection.Open();

                    // Khởi tạo lệnh SQL
                    SqlCommand command = new SqlCommand(query, connection);

                    // Gán tham số cho truy vấn
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@role", role);

                    // Đọc dữ liệu từ cơ sở dữ liệu
                    SqlDataReader reader = command.ExecuteReader();
                    int employeeId = 0;
                    bool passwordChanged = false;

                    while (reader.Read())
                    {
                        employeeId = reader.GetInt32(reader.GetOrdinal("EmployeeId"));
                        passwordChanged = reader.GetBoolean(reader.GetOrdinal("PasswordChanged"));
                    }

                    reader.Close();

                    // Kiểm tra kết quả truy vấn
                    if (employeeId > 0)
                    {
                        MessageBox.Show(
                            "Login successful!",
                            "Information",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);

                        // Chuyển hướng dựa trên vai trò và trạng thái mật khẩu
                        RedirectPage(role, employeeId, passwordChanged);
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid login credentials!",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        ClearData();
                    }

                    connection.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Unable to connect to the database.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    ClearData();
                }
                connection.Close ();
            }
        }
        

        private void RedirectPage(string selectedRole, int employeeId, bool passwordChanged)
        {
            if (selectedRole != null)
            {
                // Chuyển hướng người dùng dựa trên vai trò
                if (selectedRole == "Admin")
                {
                    Form2 adminForm = new Form2(selectedRole, employeeId);

                    // Ẩn form hiện tại
                    this.Hide();

                    // Hiển thị form Login
                    adminForm.Show();
                }
                else if (selectedRole == "Warehouse")
                {
                    WareHouseManagerForm warehouseManagerForm = new WareHouseManagerForm(selectedRole, employeeId);
                    this.Hide();
                    warehouseManagerForm.Show();
                }
                else if (selectedRole == "Sale")
                {
                    SaleForm saleForm = new SaleForm(selectedRole, employeeId);
                    this.Hide();
                    saleForm.Show();
                }
            }
        }


        private void ClearData()
        {
            txtUserName.Clear();
            txtPassword.Clear();
            cbRole.SelectedIndex = 0;
            txtUserName.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit the application?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
