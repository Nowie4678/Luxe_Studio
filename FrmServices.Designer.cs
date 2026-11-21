namespace Luxe_Studio
{
    partial class FrmServices
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
            this.lblServices = new System.Windows.Forms.Label();
            this.dgvServices = new System.Windows.Forms.DataGridView();
            this.ColService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDuration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnl = new System.Windows.Forms.Panel();
            this.lblservicename = new System.Windows.Forms.Label();
            this.txtservicename = new System.Windows.Forms.TextBox();
            this.lblprice = new System.Windows.Forms.Label();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.lblduration = new System.Windows.Forms.Label();
            this.txtduration = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
            this.SuspendLayout();
            // 
            // lblServices
            // 
            this.lblServices.AutoSize = true;
            this.lblServices.BackColor = System.Drawing.Color.White;
            this.lblServices.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblServices.Location = new System.Drawing.Point(74, 26);
            this.lblServices.Name = "lblServices";
            this.lblServices.Size = new System.Drawing.Size(137, 45);
            this.lblServices.TabIndex = 2;
            this.lblServices.Text = "Services";
            // 
            // dgvServices
            // 
            this.dgvServices.AllowUserToAddRows = false;
            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColService,
            this.ColDuration,
            this.ColPrice});
            this.dgvServices.Location = new System.Drawing.Point(71, 119);
            this.dgvServices.Name = "dgvServices";
            this.dgvServices.ReadOnly = true;
            this.dgvServices.RowHeadersWidth = 62;
            this.dgvServices.RowTemplate.Height = 28;
            this.dgvServices.Size = new System.Drawing.Size(495, 77);
            this.dgvServices.TabIndex = 3;
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
            // ColDuration
            // 
            this.ColDuration.HeaderText = "Duration";
            this.ColDuration.MinimumWidth = 8;
            this.ColDuration.Name = "ColDuration";
            this.ColDuration.ReadOnly = true;
            this.ColDuration.Width = 150;
            // 
            // ColPrice
            // 
            this.ColPrice.HeaderText = "Price";
            this.ColPrice.MinimumWidth = 8;
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 150;
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.DarkViolet;
            this.pnl.Location = new System.Drawing.Point(71, 74);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(685, 10);
            this.pnl.TabIndex = 7;
            this.pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.pnl_Paint);
            // 
            // lblservicename
            // 
            this.lblservicename.AutoSize = true;
            this.lblservicename.BackColor = System.Drawing.Color.White;
            this.lblservicename.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblservicename.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblservicename.Location = new System.Drawing.Point(620, 119);
            this.lblservicename.Name = "lblservicename";
            this.lblservicename.Size = new System.Drawing.Size(124, 25);
            this.lblservicename.TabIndex = 8;
            this.lblservicename.Text = "Service  Name";
            this.lblservicename.Click += new System.EventHandler(this.lblservicename_Click);
            // 
            // txtservicename
            // 
            this.txtservicename.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtservicename.ForeColor = System.Drawing.Color.Black;
            this.txtservicename.Location = new System.Drawing.Point(625, 162);
            this.txtservicename.Name = "txtservicename";
            this.txtservicename.Size = new System.Drawing.Size(275, 34);
            this.txtservicename.TabIndex = 13;
            // 
            // lblprice
            // 
            this.lblprice.AutoSize = true;
            this.lblprice.BackColor = System.Drawing.Color.White;
            this.lblprice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblprice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblprice.Location = new System.Drawing.Point(632, 218);
            this.lblprice.Name = "lblprice";
            this.lblprice.Size = new System.Drawing.Size(93, 25);
            this.lblprice.TabIndex = 14;
            this.lblprice.Text = "Price (KES)";
            this.lblprice.Click += new System.EventHandler(this.lblprice_Click);
            // 
            // txtprice
            // 
            this.txtprice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtprice.ForeColor = System.Drawing.Color.Black;
            this.txtprice.Location = new System.Drawing.Point(625, 259);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(275, 34);
            this.txtprice.TabIndex = 15;
            // 
            // lblduration
            // 
            this.lblduration.AutoSize = true;
            this.lblduration.BackColor = System.Drawing.Color.White;
            this.lblduration.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblduration.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblduration.Location = new System.Drawing.Point(632, 316);
            this.lblduration.Name = "lblduration";
            this.lblduration.Size = new System.Drawing.Size(81, 25);
            this.lblduration.TabIndex = 16;
            this.lblduration.Text = "Duration";
            this.lblduration.Click += new System.EventHandler(this.lblduration_Click);
            // 
            // txtduration
            // 
            this.txtduration.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtduration.ForeColor = System.Drawing.Color.Black;
            this.txtduration.Location = new System.Drawing.Point(625, 358);
            this.txtduration.Name = "txtduration";
            this.txtduration.Size = new System.Drawing.Size(275, 34);
            this.txtduration.TabIndex = 17;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(47)))), ((int)(((byte)(168)))));
            this.btnsave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(625, 421);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(100, 41);
            this.btnsave.TabIndex = 18;
            this.btnsave.Text = "Save ";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(754, 421);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(146, 41);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // FrmServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(949, 508);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtduration);
            this.Controls.Add(this.lblduration);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.lblprice);
            this.Controls.Add(this.txtservicename);
            this.Controls.Add(this.lblservicename);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.dgvServices);
            this.Controls.Add(this.lblServices);
            this.Name = "FrmServices";
            this.Text = "FrmServices";
            this.Load += new System.EventHandler(this.FrmServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblServices;
        private System.Windows.Forms.DataGridView dgvServices;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDuration;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
        private System.Windows.Forms.Label lblservicename;
        private System.Windows.Forms.TextBox txtservicename;
        private System.Windows.Forms.Label lblprice;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label lblduration;
        private System.Windows.Forms.TextBox txtduration;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnDelete;
    }
}