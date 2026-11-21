using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Luxe_Studio
{
    public partial class Frmclient : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        public Frmclient()
        {
            InitializeComponent();
        }

        private void Frmclient_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadClients("");
        }

        private void SetupGrid()
        {
            dgvclients.AutoGenerateColumns = false;
            dgvclients.ReadOnly = true;
            dgvclients.AllowUserToAddRows = false;
            dgvclients.AllowUserToDeleteRows = false;
            dgvclients.RowHeadersVisible = false;
            dgvclients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvclients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Map your designer columns by position:
            // 0 = Name, 1 = Phone, 2 = Last Visit, 3 = Visits, 4 = Actions
            dgvclients.Columns[0].DataPropertyName = "Name";
            dgvclients.Columns[1].DataPropertyName = "Phone";
            dgvclients.Columns[2].DataPropertyName = "LastVisit";
            dgvclients.Columns[3].DataPropertyName = "Visits";

            dgvclients.Columns[2].DefaultCellStyle.Format = "dd MMM yyyy";
            dgvclients.Columns[2].DefaultCellStyle.NullValue = "-";

            // Actions column: show "Delete" on the button
            if (dgvclients.Columns[4] is DataGridViewButtonColumn btnCol)
            {
                btnCol.Text = "Delete";
                btnCol.UseColumnTextForButtonValue = true;
            }

            // Hidden column that holds the client Id
            if (!dgvclients.Columns.Contains("colClientId"))
            {
                DataGridViewTextBoxColumn idCol = new DataGridViewTextBoxColumn();
                idCol.Name = "colClientId";
                idCol.DataPropertyName = "Id";
                idCol.Visible = false;
                dgvclients.Columns.Add(idCol);
            }
        }

        // Load all clients, or only those matching the search text.
        // Last Visit and Visits only count appointments up to today
        // that are not cancelled.
        private void LoadClients(string search)
        {
            string sql = @"
                SELECT
                    c.Id,
                    c.Name,
                    c.Phone,
                    (SELECT MAX(a.AppointmentDate) FROM Appointments a
                      WHERE a.ClientName = c.Name
                        AND a.Status <> 'Cancelled'
                        AND a.AppointmentDate <= CAST(GETDATE() AS DATE)) AS LastVisit,
                    (SELECT COUNT(*) FROM Appointments a
                      WHERE a.ClientName = c.Name
                        AND a.Status <> 'Cancelled'
                        AND a.AppointmentDate <= CAST(GETDATE() AS DATE)) AS Visits
                FROM Clients c
                WHERE c.Name LIKE @s OR c.Phone LIKE @s
                ORDER BY c.Name";

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@s", "%" + search.Trim() + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvclients.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load clients:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            LoadClients(txtsearchbynameorphone.Text);
        }

        // Live search as the user types
        private void txtsearchbynameorphone_TextChanged(object sender, EventArgs e)
        {
            LoadClients(txtsearchbynameorphone.Text);
        }

        private void btnaddclient_Click(object sender, EventArgs e)
        {
            string name, phone, email;
            if (!PromptNewClient(out name, out phone, out email))
                return;

            if (name == "" || phone == "")
            {
                MessageBox.Show("Name and phone number are required.", "Missing details",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    // Don't allow the same phone number twice
                    using (SqlCommand check = new SqlCommand(
                        "SELECT COUNT(*) FROM Clients WHERE Phone = @phone", con))
                    {
                        check.Parameters.AddWithValue("@phone", phone);
                        if ((int)check.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("A client with this phone number already exists.",
                                "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO Clients (Name, Phone, Email, CreatedAt)
                          VALUES (@name, @phone, @email, SYSDATETIME())", con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone", phone);
                        cmd.Parameters.AddWithValue("@email",
                            string.IsNullOrEmpty(email) ? (object)DBNull.Value : email);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Client added successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadClients(txtsearchbynameorphone.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not add client:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Small "Add Client" pop-up built in code (no designer work needed)
        private bool PromptNewClient(out string name, out string phone, out string email)
        {
            name = phone = email = "";

            using (Form f = new Form())
            {
                f.Text = "Add Client";
                f.FormBorderStyle = FormBorderStyle.FixedDialog;
                f.StartPosition = FormStartPosition.CenterParent;
                f.MaximizeBox = false;
                f.MinimizeBox = false;
                f.ClientSize = new Size(320, 200);

                Label l1 = new Label { Text = "Full name", Left = 15, Top = 15, AutoSize = true };
                TextBox t1 = new TextBox { Left = 15, Top = 35, Width = 290 };
                Label l2 = new Label { Text = "Phone", Left = 15, Top = 65, AutoSize = true };
                TextBox t2 = new TextBox { Left = 15, Top = 85, Width = 290 };
                Label l3 = new Label { Text = "Email (optional)", Left = 15, Top = 115, AutoSize = true };
                TextBox t3 = new TextBox { Left = 15, Top = 135, Width = 290 };

                Button ok = new Button { Text = "Save", Left = 140, Top = 165, Width = 80, DialogResult = DialogResult.OK };
                Button cancel = new Button { Text = "Cancel", Left = 225, Top = 165, Width = 80, DialogResult = DialogResult.Cancel };

                f.Controls.AddRange(new Control[] { l1, t1, l2, t2, l3, t3, ok, cancel });
                f.AcceptButton = ok;
                f.CancelButton = cancel;

                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    name = t1.Text.Trim();
                    phone = t2.Text.Trim();
                    email = t3.Text.Trim();
                    return true;
                }
            }
            return false;
        }

        // Actions column: delete the client in that row
        private void dgvclients_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (!(dgvclients.Columns[e.ColumnIndex] is DataGridViewButtonColumn)) return;

            DataGridViewRow row = dgvclients.Rows[e.RowIndex];
            string clientName = row.Cells[0].Value?.ToString();
            int id = Convert.ToInt32(row.Cells["colClientId"].Value);

            DialogResult confirm = MessageBox.Show(
                "Delete client \"" + clientName + "\"?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Clients WHERE Id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadClients(txtsearchbynameorphone.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not delete client:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}