namespace Luxe_Studio
{
    partial class FrmLogin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblsaloonmanagementsystem = new System.Windows.Forms.Label();
            this.lblluxestudio = new System.Windows.Forms.Label();
            this.lblusername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUserEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lnkForgotpassword = new System.Windows.Forms.LinkLabel();
            this.btnlogin = new System.Windows.Forms.Button();
            this.chkRememberme = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(31)))), ((int)(((byte)(122)))));
            this.panel1.Controls.Add(this.lblsaloonmanagementsystem);
            this.panel1.Controls.Add(this.lblluxestudio);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(294, 449);
            this.panel1.TabIndex = 0;
            // 
            // lblsaloonmanagementsystem
            // 
            this.lblsaloonmanagementsystem.AutoSize = true;
            this.lblsaloonmanagementsystem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsaloonmanagementsystem.ForeColor = System.Drawing.Color.White;
            this.lblsaloonmanagementsystem.Location = new System.Drawing.Point(11, 167);
            this.lblsaloonmanagementsystem.Name = "lblsaloonmanagementsystem";
            this.lblsaloonmanagementsystem.Size = new System.Drawing.Size(261, 28);
            this.lblsaloonmanagementsystem.TabIndex = 1;
            this.lblsaloonmanagementsystem.Text = "Saloon Management System";
            // 
            // lblluxestudio
            // 
            this.lblluxestudio.AutoSize = true;
            this.lblluxestudio.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblluxestudio.ForeColor = System.Drawing.Color.Gold;
            this.lblluxestudio.Location = new System.Drawing.Point(3, 107);
            this.lblluxestudio.Name = "lblluxestudio";
            this.lblluxestudio.Size = new System.Drawing.Size(287, 60);
            this.lblluxestudio.TabIndex = 0;
            this.lblluxestudio.Text = "LUXE STUDIO";
            // 
            // lblusername
            // 
            this.lblusername.AutoSize = true;
            this.lblusername.BackColor = System.Drawing.Color.White;
            this.lblusername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblusername.Location = new System.Drawing.Point(349, 66);
            this.lblusername.Name = "lblusername";
            this.lblusername.Size = new System.Drawing.Size(91, 25);
            this.lblusername.TabIndex = 10;
            this.lblusername.Text = "Username";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.White;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(33)))), ((int)(((byte)(51)))));
            this.lblPassword.Location = new System.Drawing.Point(349, 151);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(87, 25);
            this.lblPassword.TabIndex = 11;
            this.lblPassword.Text = "Password";
            // 
            // txtUserEmail
            // 
            this.txtUserEmail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserEmail.Location = new System.Drawing.Point(354, 106);
            this.txtUserEmail.Name = "txtUserEmail";
            this.txtUserEmail.Size = new System.Drawing.Size(306, 31);
            this.txtUserEmail.TabIndex = 12;
            this.txtUserEmail.Text = "UserEmail";
            this.txtUserEmail.TextChanged += new System.EventHandler(this.txtUserEmail_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(354, 196);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(306, 31);
            this.txtPassword.TabIndex = 13;
            this.txtPassword.Text = "Password";
            this.txtPassword.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lnkForgotpassword
            // 
            this.lnkForgotpassword.AutoSize = true;
            this.lnkForgotpassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkForgotpassword.LinkColor = System.Drawing.Color.Gold;
            this.lnkForgotpassword.Location = new System.Drawing.Point(531, 352);
            this.lnkForgotpassword.Name = "lnkForgotpassword";
            this.lnkForgotpassword.Size = new System.Drawing.Size(146, 25);
            this.lnkForgotpassword.TabIndex = 15;
            this.lnkForgotpassword.TabStop = true;
            this.lnkForgotpassword.Text = "Forgot Password";
            this.lnkForgotpassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotpassword_LinkClicked);
            // 
            // btnlogin
            // 
            this.btnlogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(47)))), ((int)(((byte)(168)))));
            this.btnlogin.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogin.ForeColor = System.Drawing.Color.White;
            this.btnlogin.Location = new System.Drawing.Point(338, 336);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(163, 41);
            this.btnlogin.TabIndex = 18;
            this.btnlogin.Text = "Log in";
            this.btnlogin.UseVisualStyleBackColor = false;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // chkRememberme
            // 
            this.chkRememberme.AutoSize = true;
            this.chkRememberme.BackColor = System.Drawing.Color.Transparent;
            this.chkRememberme.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkRememberme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRememberme.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRememberme.Location = new System.Drawing.Point(352, 255);
            this.chkRememberme.Name = "chkRememberme";
            this.chkRememberme.Size = new System.Drawing.Size(149, 29);
            this.chkRememberme.TabIndex = 19;
            this.chkRememberme.Text = "Remember Me";
            this.chkRememberme.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chkRememberme);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.lnkForgotpassword);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserEmail);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblusername);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "FrmLogin";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblusername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUserEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblluxestudio;
        private System.Windows.Forms.LinkLabel lnkForgotpassword;
        private System.Windows.Forms.Label lblsaloonmanagementsystem;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.CheckBox chkRememberme;
    }
}

