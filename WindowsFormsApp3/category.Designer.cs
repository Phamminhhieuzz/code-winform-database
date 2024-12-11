namespace WindowsFormsApp3
{
    partial class category
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
            this.dtgcategory = new System.Windows.Forms.DataGridView();
            this.btndowload = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgcategory)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgcategory
            // 
            this.dtgcategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgcategory.Location = new System.Drawing.Point(12, 12);
            this.dtgcategory.Name = "dtgcategory";
            this.dtgcategory.RowHeadersWidth = 62;
            this.dtgcategory.RowTemplate.Height = 28;
            this.dtgcategory.Size = new System.Drawing.Size(786, 266);
            this.dtgcategory.TabIndex = 0;
            this.dtgcategory.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgcategory_CellContentClick);
            // 
            // btndowload
            // 
            this.btndowload.Location = new System.Drawing.Point(296, 379);
            this.btndowload.Name = "btndowload";
            this.btndowload.Size = new System.Drawing.Size(123, 48);
            this.btndowload.TabIndex = 1;
            this.btndowload.Text = "dowload";
            this.btndowload.UseVisualStyleBackColor = true;
            this.btndowload.Click += new System.EventHandler(this.btndowload_Click);
            // 
            // category
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btndowload);
            this.Controls.Add(this.dtgcategory);
            this.Name = "category";
            this.Text = "category";
            ((System.ComponentModel.ISupportInitialize)(this.dtgcategory)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgcategory;
        private System.Windows.Forms.Button btndowload;
    }
}