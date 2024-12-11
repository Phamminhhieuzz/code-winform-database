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
using System.Xml.Linq;

namespace WindowsFormsApp3
{
    public partial class customer : Form
    {
        private int customerId;
        private int employeeId;  // Fixed the typo from employeeld to employeeId
        private string authorityLevel;
        private object degCustomer;
        private object dgCustomer;
        private int customerid;
        private int userId;
        private object dtgcustomer;

        public DataTable DataSource { get; private set; }
        public string CustomerCode { get; private set; }
        public object PhoneNumber { get; private set; }
        public object CustomerName { get; private set; }
        public object Address { get; private set; }

        // Constructor with parameters to initialize authorityLevel and employeeId
        public customer(string authorityLevel, int employeeId)
        {
            InitializeComponent();  // Make sure InitializeComponent() is called to set up the form

            this.employeeId = employeeId;  // Assign the passed employeeId to the class-level field
            this.authorityLevel = authorityLevel;  // Assign the passed authorityLevel to the class-level field
        }
        private void ChangeButtonStatus(bool buttonStatus)
        {
            // When customer is selected, disable the 'Add' button and enable 'Update', 'Delete', and 'Clear' buttons
            btnAdd.Enabled = !buttonStatus;   // Add button is disabled if buttonStatus is true
            btnUpdate.Enabled = buttonStatus; // Update button is enabled if buttonStatus is true
            btnDelete.Enabled = buttonStatus; // Delete button is enabled if buttonStatus is true
            btnClear.Enabled = buttonStatus;  // Clear button is enabled if buttonStatus is true
        }
        private bool ValidateData(string customerCode, string customerName, string customerAddress, string phoneNumber)
        {
            // Validate user input data
            bool isValid = true;

            // Check if customerCode is empty or null
            if (string.IsNullOrEmpty(customerCode))
            {
                MessageBox.Show(
                    "Customer Code cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                isValid = false;
                txtCustomerCode.Focus();
            }
            // Check if customerName is empty or null
            else if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show(
                    "Customer Name cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                isValid = false;
                txtCustomerName.Focus();
            }
            // Check if customerAddress is empty or null
            else if (string.IsNullOrEmpty(customerAddress))
            {
                MessageBox.Show(
                    "Customer Address cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                isValid = false;
                txtCustomerAddress.Focus();
            }
            // Check if phoneNumber is empty or null
            else if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show(
                    "Phone number cannot be blank",
                    "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Error
                );
                isValid = false;
                txtPhonenumber.Focus();
            }

            return isValid;
        }
        private void FlushCustomerId()
        {
            // Flush customerId value to check button and set up status for buttons
            this.customerId = 0;
            ChangeButtonStatus(false);  // Disable buttons when customerId is reset
        }
        private void LoadCustomerData()
        {
            try
            {
                // Mở kết nối bằng cách gọi hàm GetConnection trong lớp DatabaseConnection
                SqlConnection connection = DatabaseConnection.GetConnection();

                // Kiểm tra xem kết nối có phải null không
                if (connection != null)
                {
                    // Mở kết nối
                    connection.Open();

                    // Đặt câu truy vấn để lấy dữ liệu từ cơ sở dữ liệu
                    string query = "SELECT * FROM Customer";

                    // Khởi tạo SqlDataAdapter để thực thi câu truy vấn và điền vào DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Khởi tạo DataTable
                    DataTable table = new DataTable();

                    // Điền dữ liệu vào DataTable từ cơ sở dữ liệu
                    adapter.Fill(table);

                    // Gán DataTable làm nguồn dữ liệu cho DataGridView


                    // Đóng kết nối
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private bool CheckUserExistence(int customerId)
        {
            bool isExist = false;

            // Get the database connection
            SqlConnection connection = DatabaseConnection.GetConnection();

            // Check if the connection is not null
            if (connection != null)
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Query to check if a customer exists with the given CustomerID
                    string checkCustomerQuery = "SELECT * FROM Customer WHERE CustomerID = @customerId";

                    // Initialize SqlCommand and add parameter
                    SqlCommand command = new SqlCommand(checkCustomerQuery, connection);
                    command.Parameters.AddWithValue("@customerId", customerId);

                    // Execute the command and use SqlDataReader to fetch data
                    SqlDataReader reader = command.ExecuteReader();

                    // Check if any rows are returned
                    isExist = reader.HasRows;

                    // Close the reader
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Log or display the exception message
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is closed
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Failed to establish a connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return isExist;
        }
        private void AddCustomer(string customerCode, string customerName, string customerAddress, string phoneNumber)
        {
            // Get the database connection
            SqlConnection connection = DatabaseConnection.GetConnection();

            // Check if the connection is not null
            if (connection != null)
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Query to insert a new customer
                    string query = "INSERT INTO Customer (CustomerCode, CustomerName, Phonenumber, Address) " +
                                   "VALUES (@customerCode, @customerName, @phoneNumber, @customerAddress)";

                    // Initialize SqlCommand and add parameters
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerCode", customerCode);
                    command.Parameters.AddWithValue("@customerName", customerName);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@customerAddress", customerAddress);

                    // Execute the command
                    int result = command.ExecuteNonQuery();

                    // Check the result and display appropriate messages
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Successfully added new customer.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "An error occurred while adding the customer.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    // Log or display the exception message
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is closed
                    connection.Close();
                }

                // Clear all user input data and reset customerId
                ClearData();

                // Reload the data grid view to reflect new data
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("Failed to establish a connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateCustomer(int customerId, string customerCode, string customerName, string customerAddress, string phoneNumber)
        {
            // Initialize database connection
            SqlConnection connection = DatabaseConnection.GetConnection();

            // Check if the connection is not null
            if (connection != null)
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Query to update the customer record
                    string query = "UPDATE Customer SET " +
                                   "CustomerCode = @customerCode, " +
                                   "CustomerName = @customerName, " +
                                   "Address = @customerAddress, " +
                                   "Phonenumber = @phoneNumber " +
                                   "WHERE CustomerID = @customerId";

                    // Initialize SqlCommand and add parameters
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@customerCode", customerCode);
                    command.Parameters.AddWithValue("@customerName", customerName);
                    command.Parameters.AddWithValue("@customerAddress", customerAddress);
                    command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                    command.Parameters.AddWithValue("@customerId", customerId);

                    // Execute the command
                    int result = command.ExecuteNonQuery();

                    // Check the result and display appropriate messages
                    if (result > 0)
                    {
                        MessageBox.Show(
                            "Customer updated successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "An error occurred while updating the customer.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    // Log or display the exception message
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is closed
                    connection.Close();
                }

                // Clear all user input data and reset customerId
                ClearData();

                // Reload the data grid view to reflect updated data
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("Failed to establish a connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteCustomer(int customerId)
        {
            // Initialize database connection by calling GetConnection from DatabaseConnection class
            SqlConnection connection = DatabaseConnection.GetConnection();

            // Check if the connection is not null
            if (connection != null)
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Query to delete OrderDetail records related to the customer
                    string deleteOrderDetailQuery = "DELETE OrderDetail WHERE OrderDetailID IN " +
                                                    "(SELECT OrderID FROM Orders WHERE CustomerID = @customerId)";
                    SqlCommand command = new SqlCommand(deleteOrderDetailQuery, connection);

                    // Add parameter
                    command.Parameters.AddWithValue("@customerId", customerId);

                    // Execute query (no result check needed here)
                    command.ExecuteNonQuery();

                    // Query to delete Orders records related to the customer
                    string deleteOrderQuery = "DELETE Orders WHERE CustomerID = @customerId";
                    command = new SqlCommand(deleteOrderQuery, connection);

                    // Add parameter
                    command.Parameters.AddWithValue("@customerId", customerId);

                    // Execute query (no result check needed here)
                    command.ExecuteNonQuery();

                    // Query to delete Customer record
                    string deleteCustomerQuery = "DELETE Customer WHERE CustomerID = @customerId";
                    command = new SqlCommand(deleteCustomerQuery, connection);

                    // Add parameter
                    command.Parameters.AddWithValue("@customerId", customerId);

                    // Execute query and check the result
                    int deleteCustomerResult = command.ExecuteNonQuery();

                    if (deleteCustomerResult > 0)
                    {
                        MessageBox.Show(
                            "Customer deleted successfully.",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                    }
                    else
                    {
                        MessageBox.Show(
                            "An error occurred while deleting the customer.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                catch (Exception ex)
                {
                    // Log or display the exception message
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is closed
                    connection.Close();
                }

                // Clear all user input data and reset customerId
                ClearData();

                // Reload the data grid view to reflect updated data
                LoadCustomerData();
            }
            else
            {
                MessageBox.Show("Failed to establish a connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchCustomer(string search)
        {
            // Check if the search string is null or empty
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Please enter a valid search term.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Initialize database connection by calling GetConnection from DatabaseConnection class
            SqlConnection connection = DatabaseConnection.GetConnection();

            // Check if the connection is not null
            if (connection != null)
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Declare query to search customers in the database
                    string query = "SELECT * FROM Customer " +
                                   "WHERE CustomerCode LIKE @search OR " +
                                   "CustomerName LIKE @search OR " +
                                   "Phonenumber LIKE @search OR " +
                                   "Address LIKE @search";

                    // Initialize SqlDataAdapter to execute the query and retrieve results
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                    // Add the search parameter with wildcards for partial matching
                    adapter.SelectCommand.Parameters.AddWithValue("@search", "%" + search + "%");

                    // Initialize a DataTable to store query results
                    DataTable table = new DataTable();

                    // Fill the DataTable with the query results
                    adapter.Fill(table);

                    // Set the data source of the DataGridView to the DataTable

                }
                catch (Exception ex)
                {
                    // Handle exceptions and display an error message
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // Ensure the connection is closed
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Failed to establish a connection to the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ManageCustomer_Load(object sender, EventArgs e)
        {
            // Load customer data into the DataGridView when the form loads
            LoadCustomerData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Get data from user input
            string customerCode = txtCustomerCode.Text.Trim();
            string customerName = txtCustomerName.Text.Trim();
            string customerAddress = txtCustomerAddress.Text.Trim();
            string phoneNumber = txtPhonenumber.Text.Trim();

            // Validate data
            bool isValid = ValidateData(customerCode, customerName, customerAddress, phoneNumber);

            if (isValid)
            {
                // Add the new customer
                AddCustomer(customerCode, customerName, customerAddress, phoneNumber);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Check if a customer is selected
            if (customerId > 0)
            {
                // Check if the customer exists in the database
                bool isUserExist = CheckUserExistence(customerId);

                if (isUserExist)
                {
                    // Get data from user input
                    string customerCode = txtCustomerCode.Text.Trim();
                    string customerName = txtCustomerName.Text.Trim();
                    string customerAddress = txtCustomerAddress.Text.Trim();
                    string phoneNumber = txtPhonenumber.Text.Trim();

                    // Validate the input data
                    bool isValid = ValidateData(customerCode, customerName, customerAddress, phoneNumber);

                    if (isValid)
                    {
                        // Update customer details
                        UpdateCustomer(customerId, customerCode, customerName, customerAddress, phoneNumber);
                    }
                }
                else
                {
                    MessageBox.Show(
                        "No customer found with the selected ID.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            else
            {
                MessageBox.Show(
                    "Please select a customer to update.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Check if a customer is selected
            if (customerId > 0)
            {
                // Ask user for confirmation before deletion
                DialogResult result = MessageBox.Show(
                    "Do you want to delete this customer and all related data?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.OK)
                {
                    // Check if the customer exists in the database
                    bool isUserExist = CheckUserExistence(customerId);

                    if (isUserExist)
                    {
                        // Delete the customer
                        DeleteCustomer(customerId);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "No customer selected for deletion.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            Form2 adminForm = new Form2(this.authorityLevel, this.userId);
            this.Hide();
            adminForm.Show();
        }
        private void dtgCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lấy chỉ mục của hàng đang chọn
            int index = dtgCustomer.CurrentCell.RowIndex;

            // Kiểm tra chỉ mục hợp lệ
            if (index > -1)
            {
                // Lấy giá trị từ các ô của hàng đã chọn và gán cho các điều khiển tương ứng
                customerid = (int)dtgCustomer.Rows[index].Cells[0].Value;
                txtCustomerCode.Text = dtgCustomer.Rows[index].Cells[1].Value.ToString();
                txtCustomerName.Text = dtgCustomer.Rows[index].Cells[2].Value.ToString();
                txtPhonenumber.Text = dtgCustomer.Rows[index].Cells[3].Value.ToString();
                txtCustomerAddress.Text = dtgCustomer.Rows[index].Cells[4].Value.ToString();

                // Thay đổi trạng thái của các nút
                ChangeButtonStatus(true);
            }
        }
        private void dtgCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dtgCustomer.CurrentCell.RowIndex;

            // Kiểm tra nếu chỉ mục hợp lệ
            if (index > -1)
            {
                // Lấy customerId từ DataGridView
                customerId = (int)dtgCustomer.Rows[index].Cells[0].Value;

                // Lấy customerName từ DataGridView
                string customerName = dtgCustomer.Rows[index].Cells[2].Value.ToString();

                // Tạo đối tượng Order và mở form Order
                Order order = new Order(customerId, employeeId, customerName);
                order.ShowDialog();
            }
        }
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string search = txtSearch.Text;
            SearchCustomer(search);
        }

        private void ClearData()
        {
            throw new NotImplementedException();
        }

        public customer()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void customer_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btndowload_Click(object sender, EventArgs e)
        {

            loadCustomerData();
        }

        private void loadCustomerData()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=DESKTOP-7PU6JC6\SQLEXPRESS02;Initial Catalog=sell laptop;Integrated Security=True;TrustServerCertificate=True;";

            // Truy vấn SQL để lấy dữ liệu khách hàng
            string query = "SELECT * FROM Customer"; // Sử dụng tên bảng của bạn

            // Tạo kết nối và lệnh SQL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable cho DataGridView
                    dtgCustomer.DataSource = dataTable; // Giả sử bạn có một DataGridView tên dataGridView
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi nếu có
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }


        private void loadProductData()
        {
            // Chuỗi kết nối đến cơ sở dữ liệu
            string connectionString = @"Data Source=DESKTOP-7PU6JC6\SQLEXPRESS02;Initial Catalog=sell laptop;Integrated Security=True;TrustServerCertificate=True;";

            // Truy vấn SQL để lấy dữ liệu sản phẩm
            string query = "SELECT * FROM Customer"; // Sử dụng tên bảng của bạn

            // Tạo kết nối và lệnh SQL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();

                try
                {
                    // Điền dữ liệu vào DataTable
                    dataAdapter.Fill(dataTable);

                    // Gán DataTable cho DataGridView
                    DataSource = dataTable; // Giả sử bạn có một DataGridView tên dataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }



        private void dtgcustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    try
                    {
                        // Mở kết nối
                        connection.Open();

                        // Câu lệnh SQL để lấy tất cả dữ liệu sản phẩm
                        string query = "SELECT * FROM Customer";

                        // Tạo SqlDataAdapter để thực thi câu lệnh và đưa dữ liệu vào DataTable
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Tạo DataTable để lưu dữ liệu
                        DataTable dataTable = new DataTable();

                        // Điền dữ liệu vào DataTable
                        int rowsAffected = adapter.Fill(dataTable);

                        // Kiểm tra nếu có dữ liệu
                        if (rowsAffected > 0)
                        {
                            // Gán DataTable vào DataGridView

                        }
                        else
                        {
                            // Nếu không có dữ liệu
                            MessageBox.Show("Không có dữ liệu sản phẩm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Xử lý lỗi nếu có
                        MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Đảm bảo đóng kết nối dù thành công hay không
                        connection.Close();
                    }
                }
                else
                {
                    // Nếu kết nối không thành công
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu.", "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dtgCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = DatabaseConnection.GetConnection();

            // Kiểm tra kết nối
            // Đảm bảo rằng các tham số được truyền vào không phải là null hoặc giá trị không hợp lệ
            if (string.IsNullOrEmpty(CustomerCode))
            {
                MessageBox.Show("CustomerCode cannot be empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;  // Dừng việc thực hiện câu lệnh SQL
            }

            // Tạo câu lệnh SQL để thêm khách hàng
            string query = "INSERT INTO Customer (CustomerCode, CustomerName, Phonenumber, Address) VALUES (@CustomerCode, @CustomerName, @PhoneNumber, @Address)";

            // Tạo SqlCommand với câu lệnh SQL
            SqlCommand command = new SqlCommand(query, connection);

            // Thêm tham số vào câu lệnh SQL
            command.Parameters.AddWithValue("@CustomerCode", CustomerCode);  // Thêm tham số CustomerCode
            command.Parameters.AddWithValue("@CustomerName", CustomerName);  // Thêm tham số CustomerName
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);    // Thêm tham số PhoneNumber
            command.Parameters.AddWithValue("@Address", Address);            // Thêm tham số Address

            // Thực thi câu lệnh SQL
            int result = command.ExecuteNonQuery();

            // Kiểm tra kết quả
            if (result > 0)
            {
                MessageBox.Show("Successfully added new customer", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("An error occurred while adding customer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (customerId > 0)
            {
                // Ask user for confirmation before deletion
                DialogResult result = MessageBox.Show(
                    "Do you want to delete this customer and all related data?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.OK)
                {
                    // Check if the customer exists in the database
                    bool isUserExist = CheckUserExistence(customerId);

                    if (isUserExist)
                    {
                        // Delete the customer
                        DeleteCustomer(customerId);
                    }
                }
            }
            else
            {
                MessageBox.Show(
                    "No customer selected for deletion.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Form2 adminForm = new Form2(this.authorityLevel, this.userId);
            this.Hide();
            adminForm.Show();
        }
    }
}
