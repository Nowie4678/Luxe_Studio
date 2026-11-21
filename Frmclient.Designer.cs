namespace Luxe_Studio
{
    partial class Frmclient
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
            this.lblClients = new System.Windows.Forms.Label();
            this.txtsearchbynameorphone = new System.Windows.Forms.TextBox();
            this.dgvclients = new System.Windows.Forms.DataGridView();
            this.btnsearch = new System.Windows.Forms.Button();
            this.btnaddclient = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvclients)).BeginInit();
            this.SuspendLayout();
            // 
            // lblClients
            // 
            this.lblClients.AutoSize = true;
            this.lblClients.BackColor = System.Drawing.Color.White;
            this.lblClients.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClients.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblClients.Location = new System.Drawing.Point(88, 35);
            this.lblClients.Name = "lblClients";
            this.lblClients.Size = new System.Drawing.Size(118, 45);
            this.lblClients.TabIndex = 0;
            this.lblClients.Text = "Clients";
            // 
            // txtsearchbynameorphone
            // 
            this.txtsearchbynameorphone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchbynameorphone.ForeColor = System.Drawing.Color.Black;
            this.txtsearchbynameorphone.Location = new System.Drawing.Point(99, 88);
            this.txtsearchbynameorphone.Name = "txtsearchbynameorphone";
            this.txtsearchbynameorphone.Size = new System.Drawing.Size(481, 31);
            this.txtsearchbynameorphone.TabIndex = 1;
            this.txtsearchbynameorphone.Text = "Search by name or phone";
            this.txtsearchbynameorphone.TextChanged += new System.EventHandler(this.txtsearchbynameorphone_TextChanged);
            // 
            // dgvclients
            // 
            this.dgvclients.AllowUserToAddRows = false;
            this.dgvclients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvclients.EnableHeadersVisualStyles = false;
            this.dgvclients.Location = new System.Drawing.Point(96, 152);
            this.dgvclients.Name = "dgvclients";
            this.dgvclients.ReadOnly = true;
            this.dgvclients.RowHeadersWidth = 62;
            this.dgvclients.RowTemplate.Height = 28;
            this.dgvclients.Size = new System.Drawing.Size(772, 86);
            this.dgvclients.TabIndex = 2;
            this.dgvclients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvclients_CellContentClick);
            // 
            // btnsearch
            // 
            this.btnsearch.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsearch.Location = new System.Drawing.Point(602, 78);
            this.btnsearch.Name = "btnsearch";
            this.btnsearch.Size = new System.Drawing.Size(106, 41);
            this.btnsearch.TabIndex = 3;
            this.btnsearch.Text = "Search";
            this.btnsearch.UseVisualStyleBackColor = true;
            this.btnsearch.Click += new System.EventHandler(this.btnsearch_Click);
            // 
            // btnaddclient
            // 
            this.btnaddclient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnaddclient.Location = new System.Drawing.Point(737, 78);
            this.btnaddclient.Name = "btnaddclient";
            this.btnaddclient.Size = new System.Drawing.Size(149, 41);
            this.btnaddclient.TabIndex = 4;
            this.btnaddclient.Text = "+ Add Client";
            this.btnaddclient.UseVisualStyleBackColor = true;
            this.btnaddclient.Click += new System.EventHandler(this.btnaddclient_Click);
            // 
            // Frmclient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(910, 285);
            this.Controls.Add(this.btnaddclient);
            this.Controls.Add(this.btnsearch);
            this.Controls.Add(this.dgvclients);
            this.Controls.Add(this.txtsearchbynameorphone);
            this.Controls.Add(this.lblClients);
            this.Name = "Frmclient";
            this.Text = "Frmclient";
            ((System.ComponentModel.ISupportInitialize)(this.dgvclients)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClients;
        private System.Windows.Forms.TextBox txtsearchbynameorphone;
        private System.Windows.Forms.DataGridView dgvclients;
        private System.Windows.Forms.Button btnsearch;
        private System.Windows.Forms.Button btnaddclient;
    }
}