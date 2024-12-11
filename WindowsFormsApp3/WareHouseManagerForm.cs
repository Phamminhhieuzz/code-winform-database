using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class WareHouseManagerForm : Form
    {
        private string selectedRole;
        private int employeeId;

        public WareHouseManagerForm()
        {
            InitializeComponent();
        }

        public WareHouseManagerForm(string selectedRole, int employeeId)
        {
            InitializeComponent();
            this.selectedRole = selectedRole;
            this.employeeId = employeeId;
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            category categoryForm = new category();

            // Hide the current form
            this.Hide();

            // Show the category form
            categoryForm.Show();

            // Ensure the current form is closed when the category form is closed
            categoryForm.FormClosed += (s, args) => this.Close();

        }
    }
}
