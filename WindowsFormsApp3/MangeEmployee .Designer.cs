namespace WindowsFormsApp3
{
    partial class MangeEmployee
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmployeeCode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtEmployeeCode = new System.Windows.Forms.TextBox();
            this.txtEmployeeFirst = new System.Windows.Forms.TextBox();
            this.txtEmployeeAddress = new System.Windows.Forms.TextBox();
            this.txtEmployeePhone = new System.Windows.Forms.TextBox();
            this.txtEmployeeEmail = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDeleted = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblEmployeeList = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.DataGridView1 = new System.Windows.Forms.DataGridView();
            this.btndowload = new System.Windows.Forms.Button();
            this.txtEmployeeLast = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEmployeeDate = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mange Employee ";
            // 
            // lblEmployeeCode
            // 
            this.lblEmployeeCode.AutoSize = true;
            this.lblEmployeeCode.Location = new System.Drawing.Point(47, 98);
            this.lblEmployeeCode.Name = "lblEmployeeCode";
            this.lblEmployeeCode.Size = new System.Drawing.Size(44, 20);
            this.lblEmployeeCode.TabIndex = 0;
            this.lblEmployeeCode.Text = "code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 20);
            this.label3.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(353, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Employee list";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee Information";
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Location = new System.Drawing.Point(47, 146);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(73, 20);
            this.lblEmployeeName.TabIndex = 0;
            this.lblEmployeeName.Text = "full name";
            // 
            // lblPosition
            // 
            this.lblPosition.AutoSize = true;
            this.lblPosition.Location = new System.Drawing.Point(47, 232);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(35, 20);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "role";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(47, 325);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(69, 20);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "pasword";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(143, 98);
            this.txtEmployeeCode.Multiline = true;
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Size = new System.Drawing.Size(208, 36);
            this.txtEmployeeCode.TabIndex = 1;
            // 
            // txtEmployeeFirst
            // 
            this.txtEmployeeFirst.Location = new System.Drawing.Point(143, 140);
            this.txtEmployeeFirst.Multiline = true;
            this.txtEmployeeFirst.Name = "txtEmployeeFirst";
            this.txtEmployeeFirst.Size = new System.Drawing.Size(208, 26);
            this.txtEmployeeFirst.TabIndex = 1;
            // 
            // txtEmployeeAddress
            // 
            this.txtEmployeeAddress.Location = new System.Drawing.Point(143, 221);
            this.txtEmployeeAddress.Multiline = true;
            this.txtEmployeeAddress.Name = "txtEmployeeAddress";
            this.txtEmployeeAddress.Size = new System.Drawing.Size(208, 31);
            this.txtEmployeeAddress.TabIndex = 1;
            // 
            // txtEmployeePhone
            // 
            this.txtEmployeePhone.Location = new System.Drawing.Point(143, 281);
            this.txtEmployeePhone.Multiline = true;
            this.txtEmployeePhone.Name = "txtEmployeePhone";
            this.txtEmployeePhone.Size = new System.Drawing.Size(208, 26);
            this.txtEmployeePhone.TabIndex = 1;
            // 
            // txtEmployeeEmail
            // 
            this.txtEmployeeEmail.Location = new System.Drawing.Point(143, 325);
            this.txtEmployeeEmail.Multiline = true;
            this.txtEmployeeEmail.Name = "txtEmployeeEmail";
            this.txtEmployeeEmail.Size = new System.Drawing.Size(208, 26);
            this.txtEmployeeEmail.TabIndex = 1;
            this.txtEmployeeEmail.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(7, 443);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(87, 44);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(206, 443);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(88, 34);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDeleted
            // 
            this.btnDeleted.BackColor = System.Drawing.Color.AliceBlue;
            this.btnDeleted.Location = new System.Drawing.Point(7, 493);
            this.btnDeleted.Name = "btnDeleted";
            this.btnDeleted.Size = new System.Drawing.Size(87, 37);
            this.btnDeleted.TabIndex = 3;
            this.btnDeleted.Text = "Deleted";
            this.btnDeleted.UseVisualStyleBackColor = false;
            this.btnDeleted.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(207, 493);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(87, 37);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(889, 424);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(79, 34);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblEmployeeList
            // 
            this.lblEmployeeList.Location = new System.Drawing.Point(461, 25);
            this.lblEmployeeList.Multiline = true;
            this.lblEmployeeList.Name = "lblEmployeeList";
            this.lblEmployeeList.Size = new System.Drawing.Size(228, 35);
            this.lblEmployeeList.TabIndex = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(47, 271);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(80, 20);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "username";
            // 
            // DataGridView1
            // 
            this.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView1.Location = new System.Drawing.Point(357, 66);
            this.DataGridView1.Name = "DataGridView1";
            this.DataGridView1.RowHeadersWidth = 62;
            this.DataGridView1.RowTemplate.Height = 28;
            this.DataGridView1.Size = new System.Drawing.Size(1001, 346);
            this.DataGridView1.TabIndex = 4;
            this.DataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgEmployee_CellContentClick);
            this.DataGridView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DataGridView1_MouseClick);
            // 
            // btndowload
            // 
            this.btndowload.Location = new System.Drawing.Point(565, 430);
            this.btndowload.Name = "btndowload";
            this.btndowload.Size = new System.Drawing.Size(91, 28);
            this.btndowload.TabIndex = 5;
            this.btndowload.Text = "Dowload";
            this.btndowload.UseVisualStyleBackColor = true;
            this.btndowload.Click += new System.EventHandler(this.btndowload_Click);
            // 
            // txtEmployeeLast
            // 
            this.txtEmployeeLast.Location = new System.Drawing.Point(143, 176);
            this.txtEmployeeLast.Multiline = true;
            this.txtEmployeeLast.Name = "txtEmployeeLast";
            this.txtEmployeeLast.Size = new System.Drawing.Size(208, 26);
            this.txtEmployeeLast.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "postion";
            // 
            // txtEmployeeDate
            // 
            this.txtEmployeeDate.Location = new System.Drawing.Point(143, 369);
            this.txtEmployeeDate.Multiline = true;
            this.txtEmployeeDate.Name = "txtEmployeeDate";
            this.txtEmployeeDate.Size = new System.Drawing.Size(208, 26);
            this.txtEmployeeDate.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(47, 369);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Date";
            // 
            // MangeEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1319, 545);
            this.Controls.Add(this.txtEmployeeDate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtEmployeeLast);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btndowload);
            this.Controls.Add(this.DataGridView1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDeleted);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmployeeAddress);
            this.Controls.Add(this.txtEmployeeEmail);
            this.Controls.Add(this.txtEmployeePhone);
            this.Controls.Add(this.txtEmployeeFirst);
            this.Controls.Add(this.lblEmployeeList);
            this.Controls.Add(this.txtEmployeeCode);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblEmployeeCode);
            this.Controls.Add(this.label1);
            this.Name = "MangeEmployee";
            this.Text = "MangeEmployee";
            this.Load += new System.EventHandler(this.MangeEmployee_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEmployeeCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtEmployeeCode;
        private System.Windows.Forms.TextBox txtEmployeeFirst;
        private System.Windows.Forms.TextBox txtEmployeeAddress;
        private System.Windows.Forms.TextBox txtEmployeePhone;
        private System.Windows.Forms.TextBox txtEmployeeEmail;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDeleted;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.TextBox lblEmployeeList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.DataGridView DataGridView1;
        private System.Windows.Forms.Button btndowload;
        private System.Windows.Forms.TextBox txtEmployeeLast;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEmployeeDate;
        private System.Windows.Forms.Label label6;
    }
}