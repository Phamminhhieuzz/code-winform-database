namespace WindowsFormsApp3
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnproduct = new System.Windows.Forms.Button();
            this.btncustomer = new System.Windows.Forms.Button();
            this.btnimport = new System.Windows.Forms.Button();
            this.Btnoder = new System.Windows.Forms.Button();
            this.btnMangeEmployee = new System.Windows.Forms.Button();
            this.btncategory = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnproduct
            // 
            this.btnproduct.Location = new System.Drawing.Point(168, 262);
            this.btnproduct.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnproduct.Name = "btnproduct";
            this.btnproduct.Size = new System.Drawing.Size(159, 66);
            this.btnproduct.TabIndex = 0;
            this.btnproduct.Text = "Product";
            this.btnproduct.UseVisualStyleBackColor = true;
            this.btnproduct.Click += new System.EventHandler(this.btnproduct_Click);
            // 
            // btncustomer
            // 
            this.btncustomer.Location = new System.Drawing.Point(168, 157);
            this.btncustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btncustomer.Name = "btncustomer";
            this.btncustomer.Size = new System.Drawing.Size(159, 86);
            this.btncustomer.TabIndex = 0;
            this.btncustomer.Text = "customer";
            this.btncustomer.UseVisualStyleBackColor = true;
            this.btncustomer.Click += new System.EventHandler(this.btncustomer_Click);
            // 
            // btnimport
            // 
            this.btnimport.Location = new System.Drawing.Point(516, 252);
            this.btnimport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnimport.Name = "btnimport";
            this.btnimport.Size = new System.Drawing.Size(153, 85);
            this.btnimport.TabIndex = 0;
            this.btnimport.Text = "import";
            this.btnimport.UseVisualStyleBackColor = true;
            // 
            // Btnoder
            // 
            this.Btnoder.Location = new System.Drawing.Point(168, 55);
            this.Btnoder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Btnoder.Name = "Btnoder";
            this.Btnoder.Size = new System.Drawing.Size(159, 92);
            this.Btnoder.TabIndex = 0;
            this.Btnoder.Text = "Oder";
            this.Btnoder.UseVisualStyleBackColor = true;
            this.Btnoder.Click += new System.EventHandler(this.Btnoder_Click);
            // 
            // btnMangeEmployee
            // 
            this.btnMangeEmployee.Location = new System.Drawing.Point(516, 52);
            this.btnMangeEmployee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMangeEmployee.Name = "btnMangeEmployee";
            this.btnMangeEmployee.Size = new System.Drawing.Size(153, 92);
            this.btnMangeEmployee.TabIndex = 0;
            this.btnMangeEmployee.Text = "Mange Employee ";
            this.btnMangeEmployee.UseVisualStyleBackColor = true;
            this.btnMangeEmployee.Click += new System.EventHandler(this.btnMangeEmployee_Click);
            // 
            // btncategory
            // 
            this.btncategory.Location = new System.Drawing.Point(516, 157);
            this.btncategory.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btncategory.Name = "btncategory";
            this.btncategory.Size = new System.Drawing.Size(153, 86);
            this.btncategory.TabIndex = 0;
            this.btncategory.Text = "category";
            this.btncategory.UseVisualStyleBackColor = true;
            this.btncategory.Click += new System.EventHandler(this.btncategory_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(372, 377);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 35);
            this.button9.TabIndex = 1;
            this.button9.Text = "Exit";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1605, 705);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.btncategory);
            this.Controls.Add(this.btnMangeEmployee);
            this.Controls.Add(this.Btnoder);
            this.Controls.Add(this.btnimport);
            this.Controls.Add(this.btncustomer);
            this.Controls.Add(this.btnproduct);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Admin ";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnproduct;
        private System.Windows.Forms.Button btncustomer;
        private System.Windows.Forms.Button btnimport;
        private System.Windows.Forms.Button Btnoder;
        private System.Windows.Forms.Button btnMangeEmployee;
        private System.Windows.Forms.Button btncategory;
        private System.Windows.Forms.Button button9;
    }
}