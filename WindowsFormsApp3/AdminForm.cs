using System;
using System.Drawing;
using System.Windows.Forms;

namespace Grocery_Shop
{
    public partial class AdminForm : Form
    {
        private int employeeId;
        private string authorityLevel;

        // Constructor
        public AdminForm(string authorityLevel, int employeeId)
        {
            InitializeComponent();
            this.authorityLevel = authorityLevel;
            this.employeeId = employeeId;
        }

        // Implement InitializeComponent
        private void InitializeComponent()
        {
            this.Text = "Admin Panel";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Example: Adding a welcome label
            Label welcomeLabel = new Label
            {
                Text = $"Welcome, {authorityLevel} (ID: {employeeId})",
                AutoSize = true,
                Location = new Point(20, 20),
                Font = new Font("Arial", 12, FontStyle.Bold)
            };

            // Add label to the form
            this.Controls.Add(welcomeLabel);

            // Add more components here if needed
        }
    }
}
