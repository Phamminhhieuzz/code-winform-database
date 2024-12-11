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
    public partial class SaleForm : Form
    {
        private string selectedRole;
        private int employeeId;
        private string authorityLevel;
        private int userId;

        public SaleForm()
        {
            InitializeComponent();
        }

        public SaleForm(string selectedRole, int employeeId)
        {
            InitializeComponent();
            this.selectedRole = selectedRole;
            this.employeeId = employeeId;
        }

        private void button2_Click(string selectedRole ,object sender, EventArgs e)
        {
            Oder newForm = new Oder();

            // Hide the current form
            this.Hide();

            // Show the new form
            newForm.Show();

            // Ensure the application exits properly when the new form is closed
            newForm.FormClosed += (s, args) => this.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
          
           
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            customer customerForm = new customer(selectedRole, employeeId);

            // Hide the current form
            this.Hide();

            // Show the customer form
            customerForm.Show();

            // Ensure the application exits properly when the customer form is closed
            customerForm.FormClosed += (s, args) => this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 adminForm = new Form2(this.authorityLevel, this.userId);
            this.Hide();
            adminForm.Show();
        }
    }
}
