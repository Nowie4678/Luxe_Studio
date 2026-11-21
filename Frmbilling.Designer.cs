namespace Luxe_Studio
{
    partial class Frmbilling
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
            this.lblBillingandpayment = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.dgvbillingandpayment = new System.Windows.Forms.DataGridView();
            this.ColService = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblpaymentmethod = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.cmbPaymentmethod = new System.Windows.Forms.ComboBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnPrintreceipt = new System.Windows.Forms.Button();
            this.btnpaynow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillingandpayment)).BeginInit();
            this.SuspendLayout();
            // 
            // lblBillingandpayment
            // 
            this.lblBillingandpayment.AutoSize = true;
            this.lblBillingandpayment.BackColor = System.Drawing.Color.White;
            this.lblBillingandpayment.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillingandpayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblBillingandpayment.Location = new System.Drawing.Point(64, 24);
            this.lblBillingandpayment.Name = "lblBillingandpayment";
            this.lblBillingandpayment.Size = new System.Drawing.Size(300, 45);
            this.lblBillingandpayment.TabIndex = 3;
            this.lblBillingandpayment.Text = "Billing and Payment";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.DarkViolet;
            this.pnl.Location = new System.Drawing.Point(58, 82);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(685, 10);
            this.pnl.TabIndex = 8;
            // 
            // dgvbillingandpayment
            // 
            this.dgvbillingandpayment.AllowUserToAddRows = false;
            this.dgvbillingandpayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbillingandpayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColService,
            this.ColQty,
            this.ColPrice});
            this.dgvbillingandpayment.EnableHeadersVisualStyles = false;
            this.dgvbillingandpayment.Location = new System.Drawing.Point(89, 113);
            this.dgvbillingandpayment.Name = "dgvbillingandpayment";
            this.dgvbillingandpayment.ReadOnly = true;
            this.dgvbillingandpayment.RowHeadersWidth = 62;
            this.dgvbillingandpayment.RowTemplate.Height = 28;
            this.dgvbillingandpayment.Size = new System.Drawing.Size(516, 146);
            this.dgvbillingandpayment.TabIndex = 9;
            this.dgvbillingandpayment.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvbillingandpayment_CellContentClick);
            // 
            // ColService
            // 
            this.ColService.HeaderText = "Service";
            this.ColService.MinimumWidth = 8;
            this.ColService.Name = "ColService";
            this.ColService.ReadOnly = true;
            this.ColService.Width = 150;
            // 
            // ColQty
            // 
            this.ColQty.HeaderText = "Qty";
            this.ColQty.MinimumWidth = 8;
            this.ColQty.Name = "ColQty";
            this.ColQty.ReadOnly = true;
            this.ColQty.Width = 150;
            // 
            // ColPrice
            // 
            this.ColPrice.HeaderText = "Price";
            this.ColPrice.MinimumWidth = 8;
            this.ColPrice.Name = "ColPrice";
            this.ColPrice.ReadOnly = true;
            this.ColPrice.Width = 150;
            // 
            // lblpaymentmethod
            // 
            this.lblpaymentmethod.AutoSize = true;
            this.lblpaymentmethod.BackColor = System.Drawing.Color.White;
            this.lblpaymentmethod.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpaymentmethod.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblpaymentmethod.Location = new System.Drawing.Point(84, 262);
            this.lblpaymentmethod.Name = "lblpaymentmethod";
            this.lblpaymentmethod.Size = new System.Drawing.Size(148, 25);
            this.lblpaymentmethod.TabIndex = 10;
            this.lblpaymentmethod.Text = "Payment Method";
            this.lblpaymentmethod.Click += new System.EventHandler(this.lblpaymentmethod_Click);
            // 
            // lblDiscount
            // 
            this.lblDiscount.AutoSize = true;
            this.lblDiscount.BackColor = System.Drawing.Color.White;
            this.lblDiscount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiscount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblDiscount.Location = new System.Drawing.Point(410, 262);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(112, 25);
            this.lblDiscount.TabIndex = 11;
            this.lblDiscount.Text = "Discount (%)";
            this.lblDiscount.Click += new System.EventHandler(this.lblDiscount_Click);
            // 
            // cmbPaymentmethod
            // 
            this.cmbPaymentmethod.FormattingEnabled = true;
            this.cmbPaymentmethod.Items.AddRange(new object[] {
            "Cash",
            "M-Pesa",
            "Credit Card"});
            this.cmbPaymentmethod.Location = new System.Drawing.Point(89, 318);
            this.cmbPaymentmethod.Name = "cmbPaymentmethod";
            this.cmbPaymentmethod.Size = new System.Drawing.Size(205, 28);
            this.cmbPaymentmethod.TabIndex = 12;
            // 
            // txtDiscount
            // 
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.Color.Black;
            this.txtDiscount.Location = new System.Drawing.Point(415, 311);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(220, 34);
            this.txtDiscount.TabIndex = 14;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.BackColor = System.Drawing.Color.White;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblTotal.Location = new System.Drawing.Point(101, 390);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(54, 28);
            this.lblTotal.TabIndex = 15;
            this.lblTotal.Text = "Total";
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // btnPrintreceipt
            // 
            this.btnPrintreceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintreceipt.Location = new System.Drawing.Point(415, 384);
            this.btnPrintreceipt.Name = "btnPrintreceipt";
            this.btnPrintreceipt.Size = new System.Drawing.Size(173, 41);
            this.btnPrintreceipt.TabIndex = 19;
            this.btnPrintreceipt.Text = "Print Receipt";
            this.btnPrintreceipt.UseVisualStyleBackColor = true;
            this.btnPrintreceipt.Click += new System.EventHandler(this.btnPrintreceipt_Click);
            // 
            // btnpaynow
            // 
            this.btnpaynow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(47)))), ((int)(((byte)(168)))));
            this.btnpaynow.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpaynow.ForeColor = System.Drawing.Color.White;
            this.btnpaynow.Location = new System.Drawing.Point(629, 384);
            this.btnpaynow.Name = "btnpaynow";
            this.btnpaynow.Size = new System.Drawing.Size(150, 41);
            this.btnpaynow.TabIndex = 20;
            this.btnpaynow.Text = "Pay Now";
            this.btnpaynow.UseVisualStyleBackColor = false;
            this.btnpaynow.Click += new System.EventHandler(this.btnpaynow_Click);
            // 
            // Frmbilling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnpaynow);
            this.Controls.Add(this.btnPrintreceipt);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.cmbPaymentmethod);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblpaymentmethod);
            this.Controls.Add(this.dgvbillingandpayment);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.lblBillingandpayment);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Frmbilling";
            this.Text = "Frmbilling";
            this.Load += new System.EventHandler(this.Frmbilling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvbillingandpayment)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBillingandpayment;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.DataGridView dgvbillingandpayment;
        private System.Windows.Forms.Label lblpaymentmethod;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.ComboBox cmbPaymentmethod;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnPrintreceipt;
        private System.Windows.Forms.Button btnpaynow;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColService;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPrice;
    }
}