namespace Luxe_Studio
{
    partial class FrmStaff
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
            this.lblstaff = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtsearchstaff = new System.Windows.Forms.TextBox();
            this.dgvstaff = new System.Windows.Forms.DataGridView();
            this.ColStaff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRole = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnaddnew = new System.Windows.Forms.Button();
            this.grpstaffdetails = new System.Windows.Forms.GroupBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtname = new System.Windows.Forms.TextBox();
            this.cboRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblname = new System.Windows.Forms.Label();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).BeginInit();
            this.grpstaffdetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblstaff
            // 
            this.lblstaff.AutoSize = true;
            this.lblstaff.BackColor = System.Drawing.Color.White;
            this.lblstaff.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstaff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblstaff.Location = new System.Drawing.Point(81, 34);
            this.lblstaff.Name = "lblstaff";
            this.lblstaff.Size = new System.Drawing.Size(87, 45);
            this.lblstaff.TabIndex = 4;
            this.lblstaff.Text = "Staff";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkViolet;
            this.panel2.Location = new System.Drawing.Point(58, 82);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 10);
            this.panel2.TabIndex = 10;
            // 
            // txtsearchstaff
            // 
            this.txtsearchstaff.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchstaff.ForeColor = System.Drawing.Color.Black;
            this.txtsearchstaff.Location = new System.Drawing.Point(58, 121);
            this.txtsearchstaff.Name = "txtsearchstaff";
            this.txtsearchstaff.Size = new System.Drawing.Size(257, 34);
            this.txtsearchstaff.TabIndex = 11;
            this.txtsearchstaff.Text = "Search  staff";
            this.txtsearchstaff.TextChanged += new System.EventHandler(this.txtsearchstaff_TextChanged);
            // 
            // dgvstaff
            // 
            this.dgvstaff.AllowUserToAddRows = false;
            this.dgvstaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvstaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColStaff,
            this.ColPhone,
            this.ColRole});
            this.dgvstaff.EnableHeadersVisualStyles = false;
            this.dgvstaff.Location = new System.Drawing.Point(64, 177);
            this.dgvstaff.Name = "dgvstaff";
            this.dgvstaff.ReadOnly = true;
            this.dgvstaff.RowHeadersWidth = 62;
            this.dgvstaff.RowTemplate.Height = 28;
            this.dgvstaff.Size = new System.Drawing.Size(508, 325);
            this.dgvstaff.TabIndex = 12;
            this.dgvstaff.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvstaff_CellContentClick);
            // 
            // ColStaff
            // 
            this.ColStaff.HeaderText = "Staff";
            this.ColStaff.MinimumWidth = 8;
            this.ColStaff.Name = "ColStaff";
            this.ColStaff.ReadOnly = true;
            this.ColStaff.Width = 150;
            // 
            // ColPhone
            // 
            this.ColPhone.HeaderText = "Phone";
            this.ColPhone.MinimumWidth = 8;
            this.ColPhone.Name = "ColPhone";
            this.ColPhone.ReadOnly = true;
            this.ColPhone.Width = 150;
            // 
            // ColRole
            // 
            this.ColRole.HeaderText = "Role";
            this.ColRole.MinimumWidth = 8;
            this.ColRole.Name = "ColRole";
            this.ColRole.ReadOnly = true;
            this.ColRole.Width = 150;
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(466, 114);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(106, 41);
            this.btnsearch.TabIndex = 13;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnaddnew
            // 
            this.btnaddnew.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddnew.Location = new System.Drawing.Point(594, 114);
            this.btnaddnew.Name = "btnaddnew";
            this.btnaddnew.Size = new System.Drawing.Size(149, 41);
            this.btnaddnew.TabIndex = 14;
            this.btnaddnew.Text = "+ Add New";
            this.btnaddnew.UseVisualStyleBackColor = true;
            this.btnaddnew.Click += new System.EventHandler(this.btnaddnew_Click);
            // 
            // grpstaffdetails
            // 
            this.grpstaffdetails.Controls.Add(this.btnsave);
            this.grpstaffdetails.Controls.Add(this.btncancel);
            this.grpstaffdetails.Controls.Add(this.btnClear);
            this.grpstaffdetails.Controls.Add(this.txtname);
            this.grpstaffdetails.Controls.Add(this.cboRole);
            this.grpstaffdetails.Controls.Add(this.lblRole);
            this.grpstaffdetails.Controls.Add(this.lblname);
            this.grpstaffdetails.Controls.Add(this.txtphone);
            this.grpstaffdetails.Controls.Add(this.lblPhone);
            this.grpstaffdetails.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpstaffdetails.Location = new System.Drawing.Point(629, 176);
            this.grpstaffdetails.Name = "grpstaffdetails";
            this.grpstaffdetails.Size = new System.Drawing.Size(324, 427);
            this.grpstaffdetails.TabIndex = 15;
            this.grpstaffdetails.TabStop = false;
            this.grpstaffdetails.Text = "Staff Details";
            this.grpstaffdetails.Enter += new System.EventHandler(this.grpstaffdetails_Enter);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(47)))), ((int)(((byte)(168)))));
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(20, 359);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(81, 41);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save ";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btncancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(227, 359);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(91, 41);
            this.btncancel.TabIndex = 23;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(119, 359);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(79, 41);
            this.btnClear.TabIndex = 22;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtname
            // 
            this.txtname.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtname.ForeColor = System.Drawing.Color.Black;
            this.txtname.Location = new System.Drawing.Point(20, 78);
            this.txtname.Name = "txtname";
            this.txtname.Size = new System.Drawing.Size(257, 34);
            this.txtname.TabIndex = 21;
            this.txtname.Text = "Name";
            this.txtname.TextChanged += new System.EventHandler(this.txtname_TextChanged);
            // 
            // cboRole
            // 
            this.cboRole.FormattingEnabled = true;
            this.cboRole.Items.AddRange(new object[] {
            "Stylist"});
            this.cboRole.Location = new System.Drawing.Point(20, 260);
            this.cboRole.Name = "cboRole";
            this.cboRole.Size = new System.Drawing.Size(257, 36);
            this.cboRole.TabIndex = 20;
            this.cboRole.SelectedIndexChanged += new System.EventHandler(this.cboRole_SelectedIndexChanged);
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.BackColor = System.Drawing.Color.White;
            this.lblRole.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblRole.Location = new System.Drawing.Point(29, 221);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(46, 25);
            this.lblRole.TabIndex = 19;
            this.lblRole.Text = "Role";
            // 
            // lblname
            // 
            this.lblname.AutoSize = true;
            this.lblname.BackColor = System.Drawing.Color.White;
            this.lblname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblname.Location = new System.Drawing.Point(26, 50);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(59, 25);
            this.lblname.TabIndex = 18;
            this.lblname.Text = "Name";
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.ForeColor = System.Drawing.Color.Black;
            this.txtphone.Location = new System.Drawing.Point(20, 168);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(257, 34);
            this.txtphone.TabIndex = 17;
            this.txtphone.Text = "Phone";
            this.txtphone.TextChanged += new System.EventHandler(this.txtphone_TextChanged);
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.White;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblPhone.Location = new System.Drawing.Point(26, 124);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(62, 25);
            this.lblPhone.TabIndex = 16;
            this.lblPhone.Text = "Phone";
            // 
            // FrmStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(965, 615);
            this.Controls.Add(this.grpstaffdetails);
            this.Controls.Add(this.btnaddnew);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.dgvstaff);
            this.Controls.Add(this.txtsearchstaff);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblstaff);
            this.Name = "FrmStaff";
            this.Text = "FrmStaff";
            this.Load += new System.EventHandler(this.FrmStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvstaff)).EndInit();
            this.grpstaffdetails.ResumeLayout(false);
            this.grpstaffdetails.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblstaff;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtsearchstaff;
        private System.Windows.Forms.DataGridView dgvstaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRole;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnaddnew;
        private System.Windows.Forms.GroupBox grpstaffdetails;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.ComboBox cboRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblname;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.TextBox txtname;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.Button btnsave;
    }
}