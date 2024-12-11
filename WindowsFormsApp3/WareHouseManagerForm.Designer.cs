namespace WindowsFormsApp3
{
    partial class WareHouseManagerForm
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
            this.btncategory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btncategory
            // 
            this.btncategory.Location = new System.Drawing.Point(320, 170);
            this.btncategory.Name = "btncategory";
            this.btncategory.Size = new System.Drawing.Size(145, 50);
            this.btncategory.TabIndex = 0;
            this.btncategory.Text = "Category";
            this.btncategory.UseVisualStyleBackColor = true;
            this.btncategory.Click += new System.EventHandler(this.btncategory_Click);
            // 
            // WareHouseManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btncategory);
            this.Name = "WareHouseManagerForm";
            this.Text = "WareHouseManagerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btncategory;
    }
}