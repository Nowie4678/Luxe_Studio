namespace Luxe_Studio
{
    partial class FrmAppointment
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
            this.lblBookAppointment = new System.Windows.Forms.Label();
            this.lblclientname = new System.Windows.Forms.Label();
            this.txtsearchoraddclient = new System.Windows.Forms.TextBox();
            this.txtphone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.pnl = new System.Windows.Forms.Panel();
            this.lblservice = new System.Windows.Forms.Label();
            this.lblstylist = new System.Windows.Forms.Label();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.cmbStylist = new System.Windows.Forms.ComboBox();
            this.lbldate = new System.Windows.Forms.Label();
            this.lbltime = new System.Windows.Forms.Label();
            this.lblnotes = new System.Windows.Forms.Label();
            this.txtallergiesorpreferences = new System.Windows.Forms.TextBox();
            this.btnsavebooking = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.dtpTime = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblBookAppointment
            // 
            this.lblBookAppointment.AutoSize = true;
            this.lblBookAppointment.BackColor = System.Drawing.Color.White;
            this.lblBookAppointment.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBookAppointment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblBookAppointment.Location = new System.Drawing.Point(81, 20);
            this.lblBookAppointment.Name = "lblBookAppointment";
            this.lblBookAppointment.Size = new System.Drawing.Size(296, 45);
            this.lblBookAppointment.TabIndex = 1;
            this.lblBookAppointment.Text = "Book Appointment";
            // 
            // lblclientname
            // 
            this.lblclientname.AutoSize = true;
            this.lblclientname.BackColor = System.Drawing.Color.White;
            this.lblclientname.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclientname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblclientname.Location = new System.Drawing.Point(84, 88);
            this.lblclientname.Name = "lblclientname";
            this.lblclientname.Size = new System.Drawing.Size(108, 25);
            this.lblclientname.TabIndex = 2;
            this.lblclientname.Text = "Client Name";
            // 
            // txtsearchoraddclient
            // 
            this.txtsearchoraddclient.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsearchoraddclient.ForeColor = System.Drawing.Color.Black;
            this.txtsearchoraddclient.Location = new System.Drawing.Point(89, 130);
            this.txtsearchoraddclient.Name = "txtsearchoraddclient";
            this.txtsearchoraddclient.Size = new System.Drawing.Size(257, 34);
            this.txtsearchoraddclient.TabIndex = 3;
            this.txtsearchoraddclient.Text = "Search  or add client";
            this.txtsearchoraddclient.TextChanged += new System.EventHandler(this.txtsearchoraddclient_TextChanged);
            // 
            // txtphone
            // 
            this.txtphone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtphone.ForeColor = System.Drawing.Color.Black;
            this.txtphone.Location = new System.Drawing.Point(481, 130);
            this.txtphone.Name = "txtphone";
            this.txtphone.Size = new System.Drawing.Size(257, 34);
            this.txtphone.TabIndex = 4;
            this.txtphone.Text = "Phone";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.BackColor = System.Drawing.Color.White;
            this.lblPhone.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhone.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblPhone.Location = new System.Drawing.Point(476, 88);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(62, 25);
            this.lblPhone.TabIndex = 5;
            this.lblPhone.Text = "Phone";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.DarkViolet;
            this.pnl.Location = new System.Drawing.Point(90, 68);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(659, 10);
            this.pnl.TabIndex = 6;
            // 
            // lblservice
            // 
            this.lblservice.AutoSize = true;
            this.lblservice.BackColor = System.Drawing.Color.White;
            this.lblservice.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblservice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblservice.Location = new System.Drawing.Point(95, 184);
            this.lblservice.Name = "lblservice";
            this.lblservice.Size = new System.Drawing.Size(67, 25);
            this.lblservice.TabIndex = 7;
            this.lblservice.Text = "Service";
            this.lblservice.Click += new System.EventHandler(this.lblservice_Click);
            // 
            // lblstylist
            // 
            this.lblstylist.AutoSize = true;
            this.lblstylist.BackColor = System.Drawing.Color.White;
            this.lblstylist.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblstylist.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblstylist.Location = new System.Drawing.Point(476, 193);
            this.lblstylist.Name = "lblstylist";
            this.lblstylist.Size = new System.Drawing.Size(58, 25);
            this.lblstylist.TabIndex = 8;
            this.lblstylist.Text = "Stylist";
            this.lblstylist.Click += new System.EventHandler(this.lblstylist_Click);
            // 
            // cmbService
            // 
            this.cmbService.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbService.FormattingEnabled = true;
            this.cmbService.Items.AddRange(new object[] {
            "Hairbraiding"});
            this.cmbService.Location = new System.Drawing.Point(98, 236);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(248, 36);
            this.cmbService.TabIndex = 9;
            this.cmbService.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbStylist
            // 
            this.cmbStylist.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStylist.FormattingEnabled = true;
            this.cmbStylist.Items.AddRange(new object[] {
            "Grace",
            "Phiona",
            "Mark",
            "Steve",
            "Amaya"});
            this.cmbStylist.Location = new System.Drawing.Point(481, 236);
            this.cmbStylist.Name = "cmbStylist";
            this.cmbStylist.Size = new System.Drawing.Size(257, 36);
            this.cmbStylist.TabIndex = 10;
            this.cmbStylist.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // lbldate
            // 
            this.lbldate.AutoSize = true;
            this.lbldate.BackColor = System.Drawing.Color.White;
            this.lbldate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lbldate.Location = new System.Drawing.Point(105, 301);
            this.lbldate.Name = "lbldate";
            this.lbldate.Size = new System.Drawing.Size(49, 25);
            this.lbldate.TabIndex = 11;
            this.lbldate.Text = "Date";
            // 
            // lbltime
            // 
            this.lbltime.AutoSize = true;
            this.lbltime.BackColor = System.Drawing.Color.White;
            this.lbltime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lbltime.Location = new System.Drawing.Point(489, 301);
            this.lbltime.Name = "lbltime";
            this.lbltime.Size = new System.Drawing.Size(50, 25);
            this.lbltime.TabIndex = 13;
            this.lbltime.Text = "Time";
            // 
            // lblnotes
            // 
            this.lblnotes.AutoSize = true;
            this.lblnotes.BackColor = System.Drawing.Color.White;
            this.lblnotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnotes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblnotes.Location = new System.Drawing.Point(112, 402);
            this.lblnotes.Name = "lblnotes";
            this.lblnotes.Size = new System.Drawing.Size(59, 25);
            this.lblnotes.TabIndex = 15;
            this.lblnotes.Text = "Notes";
            this.lblnotes.Click += new System.EventHandler(this.lblnotes_Click);
            // 
            // txtallergiesorpreferences
            // 
            this.txtallergiesorpreferences.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtallergiesorpreferences.ForeColor = System.Drawing.Color.Silver;
            this.txtallergiesorpreferences.Location = new System.Drawing.Point(98, 467);
            this.txtallergiesorpreferences.Name = "txtallergiesorpreferences";
            this.txtallergiesorpreferences.Size = new System.Drawing.Size(640, 34);
            this.txtallergiesorpreferences.TabIndex = 16;
            this.txtallergiesorpreferences.Text = "Allergies or preferences";
            // 
            // btnsavebooking
            // 
            this.btnsavebooking.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(47)))), ((int)(((byte)(168)))));
            this.btnsavebooking.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsavebooking.ForeColor = System.Drawing.Color.White;
            this.btnsavebooking.Location = new System.Drawing.Point(100, 528);
            this.btnsavebooking.Name = "btnsavebooking";
            this.btnsavebooking.Size = new System.Drawing.Size(163, 41);
            this.btnsavebooking.TabIndex = 17;
            this.btnsavebooking.Text = "Save booking";
            this.btnsavebooking.UseVisualStyleBackColor = false;
            this.btnsavebooking.Click += new System.EventHandler(this.btnsavebooking_Click);
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(299, 528);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(166, 41);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btncancel
            // 
            this.btncancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btncancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancel.ForeColor = System.Drawing.Color.White;
            this.btncancel.Location = new System.Drawing.Point(524, 528);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(166, 41);
            this.btncancel.TabIndex = 19;
            this.btncancel.Text = "Cancel";
            this.btncancel.UseVisualStyleBackColor = false;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(90, 347);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(264, 26);
            this.dtpDate.TabIndex = 20;
            // 
            // dtpTime
            // 
            this.dtpTime.Location = new System.Drawing.Point(481, 348);
            this.dtpTime.Name = "dtpTime";
            this.dtpTime.Size = new System.Drawing.Size(257, 26);
            this.dtpTime.TabIndex = 21;
            // 
            // FrmAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 605);
            this.Controls.Add(this.dtpTime);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnsavebooking);
            this.Controls.Add(this.txtallergiesorpreferences);
            this.Controls.Add(this.lblnotes);
            this.Controls.Add(this.lbltime);
            this.Controls.Add(this.lbldate);
            this.Controls.Add(this.cmbStylist);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.lblstylist);
            this.Controls.Add(this.lblservice);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtphone);
            this.Controls.Add(this.txtsearchoraddclient);
            this.Controls.Add(this.lblclientname);
            this.Controls.Add(this.lblBookAppointment);
            this.Name = "FrmAppointment";
            this.Text = "FrmAppointment";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBookAppointment;
        private System.Windows.Forms.Label lblclientname;
        private System.Windows.Forms.TextBox txtsearchoraddclient;
        private System.Windows.Forms.TextBox txtphone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Panel pnl;
        private System.Windows.Forms.Label lblservice;
        private System.Windows.Forms.Label lblstylist;
        private System.Windows.Forms.ComboBox cmbService;
        private System.Windows.Forms.ComboBox cmbStylist;
        private System.Windows.Forms.Label lbldate;
        private System.Windows.Forms.Label lbltime;
        private System.Windows.Forms.Label lblnotes;
        private System.Windows.Forms.TextBox txtallergiesorpreferences;
        private System.Windows.Forms.Button btnsavebooking;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btncancel;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.DateTimePicker dtpTime;
    }
}