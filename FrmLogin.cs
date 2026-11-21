using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Luxe_Studio
{
    public partial class FrmLogin : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        // Last user is remembered in this small file (per Windows user)
        private readonly string rememberFile = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "LuxeStudio", "lastuser.txt");

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Do NOT call InitializeComponent() again here.
            txtPassword.UseSystemPasswordChar = true;   // hide the password
            this.AcceptButton = btnlogin;            // pressing Enter logs in

            string saved = LoadRememberedUser();
            if (saved != "")
            {
                txtUserEmail.Text = saved;
                txtPassword.Focus();       // jump straight to the password box
            }
            else
            {
                txtUserEmail.Focus();
            }
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            string user = txtUserEmail.Text.Trim();

            if (user == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Please enter your email and password.", "Login",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    string sql = "SELECT COUNT(*) FROM Users WHERE Email = @u AND Password = @p";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@u", user);
                        cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                        int count = (int)cmd.ExecuteScalar();

                        if (count > 0)
                        {
                            SaveRememberedUser(user);   // remember for next time

                            FrmDashboard dash = new FrmDashboard();
                            dash.FormClosed += (s, args) => Application.Exit();
                            dash.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Invalid email or password.", "Login failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtPassword.Clear();
                            txtPassword.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkForgotpassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Please contact the administrator to reset your password.",
                "Forgot password", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ---------- Remember the email ----------
        private string LoadRememberedUser()
        {
            try
            {
                return File.Exists(rememberFile) ? File.ReadAllText(rememberFile).Trim() : "";
            }
            catch
            {
                return "";
            }
        }

        private void SaveRememberedUser(string user)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(rememberFile));
                File.WriteAllText(rememberFile, user);
            }
            catch
            {
                // Not important - ignore if it can't be saved
            }
        }

        // Designer-created handlers (safe to leave empty)
        private void txtUserEmail_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
    }
}