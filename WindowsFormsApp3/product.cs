using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class product : Form
    {
        private int productId;
        private string authorityLevel;
        private int userId;


        public product(string authorityLevel, int userId)
        {
            this.authorityLevel = authorityLevel;
            this.userId = userId;
            productId = 0;
            InitializeComponent();

        }

        public product()
        {
        }

        private void product_Load(object sender, EventArgs e)
        {

            SqlConnection connection = DatabaseConnection.GetConnection();
            if (connection != null)
            {
                try
                {
                    connection.Open();

                    string query = "SELECT CategoryID, CategoryName FROM Category";

                    // Creating and filling a DataTable
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);


                    cbCategory.DataSource = dataTable;
                    cbCategory.DisplayMember = "CategoryName";
                    cbCategory.ValueMember = "CategoryID";
                }
                catch (Exception ex)
                {

                    MessageBox.Show($"Error: {ex.Message}");
                }
                finally
                {

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Failed to establish database connection.");
            }
        }
        private bool ValidateData(string productCode, string productName, string productPrice, string productQuantity)
        {
            double temp;
            int tempz;

            // Check if productName is empty or null
            if (string.IsNullOrEmpty(productName))
            {
                return false;
            }

            // Check if productPrice is empty or null
            if (string.IsNullOrEmpty(productPrice))
            {
                return false;
            }

            // Check if productPrice is a valid double
            if (!double.TryParse(productPrice, out temp))
            {
                return false;
            }

            // Check if productQuantity is empty or null
            if (string.IsNullOrEmpty(productQuantity))
            {
                return false;
            }

            // Check if productQuantity is a valid integer
            return int.TryParse(productQuantity, out tempz);
        }

        private void LoadProductData()
        {
            // Get a database connection
            using (SqlConnection connection = DatabaseConnection.GetConnection())
            {
                if (connection != null)
                {
                    try
                    {
                        // Open the database connection
                        connection.Open();

                        // Query to retrieve all product data
                        string query = "SELECT * FROM Product";

                        // Create and configure a SqlDataAdapter
                        SqlDataAdapter adapter = new SqlDataAdapter(query, connection);

                        // Fill a DataTable with the query results
                        DataTable dataTable = new DataTable();
                        int rowsAffected = adapter.Fill(dataTable);

                        // Check if any rows were returned
                        if (rowsAffected > 0)
                        {
                            // Bind the data to the DataGridView
                            dtgProduct.DataSource = dataTable;
                        }
                        else
                        {
                            MessageBox.Show("No data found", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions (e.g., connection errors, query errors)
                        MessageBox.Show($"Error loading product data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Handle the case where the connection is null
                    MessageBox.Show("Unable to connect to the database.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ClearData()
        {
            // Reset product ID
            FlushProductId();

            // Clear text fields
            txtProductCode.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtProductImg.Text = string.Empty;
            txtProductPrice.Text = string.Empty;
            txtProductQuantity.Text = string.Empty;


        }

        private void FlushProductId()
        {
            this.productId = 0;

        }

        private void AddProduct()
        {
            try
            {
                // Open connection by calling the GetConnection function in DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();

                // Check if connection is valid
                if (connection != null)
                {
                    // Open the connection
                    connection.Open();

                    // Get data from input fields
                    string productCode = txtProductCode.Text;
                    string productName = txtProductName.Text;
                    string productImg = txtProductImg.Text;
                    string price = txtProductPrice.Text;
                    string quantity = txtProductQuantity.Text;
                    int categoryId = Convert.ToInt32(cbCategory.SelectedValue);

                    // Validate input data
                    if (ValidateData(productCode, productName, price, quantity))
                    {
                        // Declare query
                        string sql = "INSERT INTO Product (ProductCode, ProductName, Price, InventoryQuantity, ProductImage, CategoryId) " +
                                     "VALUES (@productCode, @productName, @productPrice, @productQuantity, @productImg, @categoryId)";

                        // Initialize SqlCommand to execute the query
                        SqlCommand command = new SqlCommand(sql, connection);

                        // Add parameters to the query
                        command.Parameters.AddWithValue("@productCode", productCode);
                        command.Parameters.AddWithValue("@productName", productName);
                        command.Parameters.AddWithValue("@productPrice", Convert.ToDouble(price));
                        command.Parameters.AddWithValue("@productQuantity", Convert.ToInt32(quantity));
                        command.Parameters.AddWithValue("@productImg", productImg);
                        command.Parameters.AddWithValue("@categoryId", categoryId);

                        // Execute the query and get the result
                        int result = command.ExecuteNonQuery();

                        // Check the result
                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Successfully added a new product.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // Clear input fields and reload product data
                            ClearData();
                            LoadProductData();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to add a new product.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid input data. Please check and try again.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    // Close the connection
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Failed to establish a database connection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateProduct()
        {
            try
            {
                // Open connection by calling the GetConnection function in DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();

                // Check if connection is valid
                if (connection != null)
                {
                    // Open the connection
                    connection.Open();

                    // Get input data
                    string productCode = txtProductCode.Text;
                    string productName = txtProductName.Text;
                    string productImg = txtProductImg.Text;
                    string price = txtProductPrice.Text;
                    string quantity = txtProductQuantity.Text;
                    int categoryId = Convert.ToInt32(cbCategory.SelectedValue);

                    // Validate input data
                    if (ValidateData(productCode, productName, price, quantity))
                    {
                        // Declare query
                        string sql = "UPDATE Product SET " +
                                     "ProductCode = @productCode, " +
                                     "ProductName = @productName, " +
                                     "Price = @productPrice, " +
                                     "InventoryQuantity = @productQuantity, " +
                                     "ProductImage = @productImg, " +
                                     "CategoryID = @categoryId " +
                                     "WHERE ProductID = @productId";

                        // Initialize SqlCommand to execute the query
                        SqlCommand command = new SqlCommand(sql, connection);

                        // Add parameters to the query
                        command.Parameters.AddWithValue("@productCode", productCode);
                        command.Parameters.AddWithValue("@productName", productName);
                        command.Parameters.AddWithValue("@productPrice", Convert.ToDouble(price));
                        command.Parameters.AddWithValue("@productQuantity", Convert.ToInt32(quantity));
                        command.Parameters.AddWithValue("@productImg", productImg);
                        command.Parameters.AddWithValue("@categoryId", categoryId);
                        command.Parameters.AddWithValue("@productId", this.productId); // Assuming 'this.productid' holds the ProductID

                        // Execute the query and get the result
                        int result = command.ExecuteNonQuery();

                        // Check the result
                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Successfully updated the product.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // Clear input fields and reload product data
                            ClearData();
                            LoadProductData();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to update the product.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }
                    }
                    else
                    {
                        MessageBox.Show(
                            "Invalid input data. Please check and try again.",
                            "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning
                        );
                    }

                    // Close the connection
                    connection.Close();
                }
                else
                {
                    MessageBox.Show(
                        "Failed to establish a database connection.",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void DeleteProduct()
        {
            try
            {
                // Ask for confirmation
                DialogResult dialogResult = MessageBox.Show(
                    "Do you want to delete the product?",
                    "Warning",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.OK)
                {
                    // Check if the product is part of any order
                    if (IsProductInOrder(this.productId))
                    {
                        MessageBox.Show(
                            "Product is associated with an order and cannot be deleted.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        return;
                    }

                    // Open connection by calling the GetConnection function in DatabaseConnection class
                    SqlConnection connection = DatabaseConnection.GetConnection();

                    if (connection != null)
                    {
                        // Open the connection
                        connection.Open();

                        // Declare query
                        string sql = "DELETE FROM Product WHERE ProductID = @productId";

                        // Initialize SqlCommand to execute the query
                        SqlCommand command = new SqlCommand(sql, connection);

                        // Add parameters to the query
                        command.Parameters.AddWithValue("@productId", this.productId);

                        // Execute the query and get the result
                        int result = command.ExecuteNonQuery();

                        // Check the result
                        if (result > 0)
                        {
                            MessageBox.Show(
                                "Successfully deleted the product.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );

                            // Clear input fields and reload product data
                            ClearData();
                            LoadProductData();
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to delete the product.",
                                "Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error
                            );
                        }

                        // Close the connection
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Failed to establish a database connection.",
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool IsProductInOrder(int productId)
        {
            try
            {
                // Open connection by calling the GetConnection function in DatabaseConnection class
                SqlConnection connection = DatabaseConnection.GetConnection();

                if (connection != null)
                {
                    // Open the connection
                    connection.Open();

                    // Query to count records where ProductID matches the given productId
                    string sql = "SELECT COUNT(*) FROM OrderDetail WHERE ProductID = @productId";

                    // Initialize SqlCommand
                    SqlCommand command = new SqlCommand(sql, connection);

                    // Add parameter
                    command.Parameters.AddWithValue("@productId", productId);

                    // Execute the query and get the count
                    int result = (int)command.ExecuteScalar();

                    // Close the connection
                    connection.Close();

                    // Return true if product exists in any order
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                MessageBox.Show($"Error checking product in orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false;
        }



        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProduct();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddProduct();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteProduct();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Call UploadFile method with a filter for image file types (JPG, JPEG, PNG)
            UploadFile("Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png");
        }

        private void UploadFile(string v)
        {
            throw new NotImplementedException();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            Form2 adminForm = new Form2(this.authorityLevel, this.userId);
            this.Hide();
            adminForm.Show();
        
            //switch (authorityLevel)
            //{
            //    case "Admin":
            //        Form2 adminForm = new Form2(this.authorityLevel, this.userId);
            //        this.Hide();
            //        adminForm.Show();
            //        break;

            //    case "Warehouse":
            //        WarehouseManager warehouseManagerForm = new WarehouseManagerForm(this.authorityLevel, this.userId);
            //        this.Hide();
            //        warehouseManagerForm.Show();
            //        break;

            //    case "Sale":
            //        SaleForm saleForm = new SaleForm(this.authorityLevel, this.userId);
            //        this.Hide();
            //        saleForm.Show();
            //        break;

            //    default:
            //        MessageBox.Show("Invalid authority level.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        break;
            //}
        }

        private void dtgProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                        string query = "SELECT * FROM Product";

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
                            dtgProduct.DataSource = dataTable;
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
        

        private void btndowload_Click(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void dtgProduct_Click(object sender, EventArgs e)
        {
            if (dtgProduct.SelectedRows.Count == 1)
            {
                string Code = dtgProduct.SelectedRows[0].Cells[1].Value.ToString();

                string Name = dtgProduct.SelectedRows[0].Cells[2].Value.ToString();

                string Price = dtgProduct.SelectedRows[0].Cells[3].Value.ToString();
                string Quantity = dtgProduct.SelectedRows[0].Cells[4].Value.ToString();
                string Img = dtgProduct.SelectedRows[0].Cells[5].Value.ToString();
                string Category = dtgProduct.SelectedRows[0].Cells[6].Value.ToString();
             

                txtProductCode.Text = Code;
                txtProductName.Text = Name;
                txtProductPrice.Text = Price;
                txtProductImg.Text = Img;
                txtProductQuantity.Text = Quantity;
                cbCategory.Text = Category;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

}
    


