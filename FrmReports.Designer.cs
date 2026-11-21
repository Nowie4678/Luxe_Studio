namespace Luxe_Studio
{
    partial class FrmReports
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
            this.lblReports = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblfrom = new System.Windows.Forms.Label();
            this.lblto = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpTop = new System.Windows.Forms.DateTimePicker();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.ColService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColBookings = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRevenue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Print = new System.Windows.Forms.Button();
            this.btnexportpdf = new System.Windows.Forms.Button();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.BackColor = System.Drawing.Color.White;
            this.lblReports.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblReports.Location = new System.Drawing.Point(77, 29);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(133, 45);
            this.lblReports.TabIndex = 3;
            this.lblReports.Text = "Reports";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.DarkViolet;
            this.pnl.Controls.Add(this.panel2);
            this.pnl.Location = new System.Drawing.Point(58, 77);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(685, 10);
            this.pnl.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkViolet;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(685, 10);
            this.panel2.TabIndex = 9;
            // 
            // lblfrom
            // 
            this.lblfrom.AutoSize = true;
            this.lblfrom.BackColor = System.Drawing.Color.White;
            this.lblfrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblfrom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblfrom.Location = new System.Drawing.Point(80, 103);
            this.lblfrom.Name = "lblfrom";
            this.lblfrom.Size = new System.Drawing.Size(54, 25);
            this.lblfrom.TabIndex = 9;
            this.lblfrom.Text = "From";
            // 
            // lblto
            // 
            this.lblto.AutoSize = true;
            this.lblto.BackColor = System.Drawing.Color.White;
            this.lblto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblto.Location = new System.Drawing.Point(413, 103);
            this.lblto.Name = "lblto";
            this.lblto.Size = new System.Drawing.Size(30, 25);
            this.lblto.TabIndex = 10;
            this.lblto.Text = "To";
            // 
            // dtpFrom
            // 
            this.dtpFrom.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFrom.Location = new System.Drawing.Point(140, 98);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 31);
            this.dtpFrom.TabIndex = 27;
            // 
            // dtpTop
            // 
            this.dtpTop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpTop.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTop.Location = new System.Drawing.Point(449, 103);
            this.dtpTop.Name = "dtpTop";
            this.dtpTop.Size = new System.Drawing.Size(200, 31);
            this.dtpTop.TabIndex = 28;
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColService,
            this.ColBookings,
            this.ColRevenue});
            this.dgvServices.EnableHeadersVisualStyles = false;
            this.dgvServices.Location = new System.Drawing.Point(85, 155);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersWidth = 62;
            this.dgvServices.RowTemplate.Height = 28;
            this.dgvServices.Size = new System.Drawing.Size(512, 156);
            this.dgvServices.TabIndex = 30;
            this.dgvServices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvServices_CellContentClick);
            // 
            // ColService
            // 
            this.ColService.HeaderText = "Service";
            this.ColService.MinimumWidth = 8;
            this.ColService.Name = "ColService";
            this.ColService.ReadOnly = true;
            this.ColService.Width = 150;
            // 
            // ColBookings
            // 
            this.ColBookings.HeaderText = "Bookings";
            this.ColBookings.MinimumWidth = 8;
            this.ColBookings.Name = "ColBookings";
            this.ColBookings.ReadOnly = true;
            this.ColBookings.Width = 150;
            // 
            // ColRevenue
            // 
            this.ColRevenue.HeaderText = "Revenue";
            this.ColRevenue.MinimumWidth = 8;
            this.ColRevenue.Name = "ColRevenue";
            this.ColRevenue.ReadOnly = true;
            this.ColRevenue.Width = 150;
            // 
            // Print
            // 
            this.Print.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Print.Location = new System.Drawing.Point(105, 415);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(105, 46);
            this.Print.TabIndex = 31;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // btnexportpdf
            // 
            this.btnexportpdf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnexportpdf.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnexportpdf.ForeColor = System.Drawing.Color.White;
            this.btnexportpdf.Location = new System.Drawing.Point(386, 415);
            this.btnexportpdf.Name = "btnexportpdf";
            this.btnexportpdf.Size = new System.Drawing.Size(183, 46);
            this.btnexportpdf.TabIndex = 32;
            this.btnexportpdf.Text = "Export Pdf";
            this.btnexportpdf.UseVisualStyleBackColor = false;
            this.btnexportpdf.Click += new System.EventHandler(this.btnexportpdf_Click);
            // 
            // FrmReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 493);
            this.Controls.Add(this.btnexportpdf);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.dtpTop);
            this.Controls.Add(this.dtpFrom);
            this.Controls.Add(this.lblto);
            this.Controls.Add(this.lblfrom);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.lblReports);
            this.Name = "FrmReports";
            this.Text = "FrmReports";
            this.Load += new System.EventHandler(this.FrmReports_Load);
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lblfrom;
        private System.Windows.Forms.Label lblto;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.DateTimePicker dtpTop;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBookings;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRevenue;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button btnexportpdf;
    }
}