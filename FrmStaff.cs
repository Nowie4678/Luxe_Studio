using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Luxe_Studio
{
    public partial class FrmStaff : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        // Id of the staff member being edited (null = adding a new one)
        private int? selectedId = null;

        public FrmStaff()
        {
            InitializeComponent();
        }

        private void FrmStaff_Load(object sender, EventArgs e)
        {
            SetupGrid();

            cboRole.Items.Clear();
            cboRole.Items.AddRange(new string[] { "Stylist", "Receptionist", "Cashier", "Manager" });
            cboRole.DropDownStyle = ComboBoxStyle.DropDownList;

            // Click a row to load it into the details box
            dgvstaff.CellClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0) FillFromRow(dgvstaff.Rows[ev.RowIndex]);
            };

            LoadStaff("");
            ClearForm();
            grpstaffdetails.Enabled = false;
        }

        private void SetupGrid()
        {
            try
            {
                var g = dgvstaff;
                g.AutoGenerateColumns = false;
                g.Columns.Clear();

                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colId", DataPropertyName = "Id", Visible = false });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colName", HeaderText = "Name", DataPropertyName = "Name" });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colPhone", HeaderText = "Phone", DataPropertyName = "Phone" });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colRole", HeaderText = "Role", DataPropertyName = "Role" });

                g.ReadOnly = true;
                g.AllowUserToAddRows = false;
                g.AllowUserToDeleteRows = false;
                g.RowHeadersVisible = false;
                g.MultiSelect = false;
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not set up the grid:\n" + ex.Message);
            }
        }

        // Load all staff, or only those matching the search text
        private void LoadStaff(string search)
        {
            string sql = @"SELECT Id, Name, Phone, [Role]
                           FROM Staff
                           WHERE Name LIKE @s OR Phone LIKE @s OR [Role] LIKE @s
                           ORDER BY Name";

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@s", "%" + search.Trim() + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvstaff.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load staff:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFromRow(DataGridViewRow row)
        {
            selectedId = Convert.ToInt32(row.Cells["colId"].Value);
            txtname.Text = row.Cells["colName"].Value?.ToString();
            txtphone.Text = row.Cells["colPhone"].Value?.ToString();

            string role = row.Cells["colRole"].Value?.ToString();
            if (!string.IsNullOrEmpty(role))
            {
                if (!cboRole.Items.Contains(role)) cboRole.Items.Add(role);
                cboRole.SelectedItem = role;
            }
            else
            {
                cboRole.SelectedIndex = -1;
            }

            grpstaffdetails.Enabled = true;
        }

        private void ClearForm()
        {
            selectedId = null;
            txtname.Clear();
            txtphone.Clear();
            cboRole.SelectedIndex = -1;
        }

        // SEARCH
        private void btnsearch_Click(object sender, EventArgs e)
        {
            LoadStaff(txtsearchstaff.Text);
        }

        // Live search as the user types
        private void txtsearchstaff_TextChanged(object sender, EventArgs e)
        {
            LoadStaff(txtsearchstaff.Text);
        }

        // ADD NEW: opens the details box with empty fields
        private void btnaddnew_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvstaff.ClearSelection();
            grpstaffdetails.Enabled = true;
            txtname.Focus();
        }

        // SAVE: adds a new staff member, or updates the selected one
        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string phone = txtphone.Text.Trim();

            if (name == "")
            {
                MessageBox.Show("Please enter the staff member's name.", "Missing name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtname.Focus();
                return;
            }
            if (cboRole.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a role.", "Missing role",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRole.Focus();
                return;
            }

            string role = cboRole.SelectedItem.ToString();

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    // Don't allow the same phone number twice
                    if (phone != "")
                    {
                        using (SqlCommand check = new SqlCommand(
                            "SELECT COUNT(*) FROM Staff WHERE Phone = @phone AND Id <> @id", con))
                        {
                            check.Parameters.AddWithValue("@phone", phone);
                            check.Parameters.AddWithValue("@id", selectedId ?? 0);
                            if ((int)check.ExecuteScalar() > 0)
                            {
                                MessageBox.Show("Another staff member already has this phone number.",
                                    "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }
                    }

                    string sql = selectedId == null
                        ? "INSERT INTO Staff (Name, Phone, [Role]) VALUES (@name, @phone, @role)"
                        : "UPDATE Staff SET Name = @name, Phone = @phone, [Role] = @role WHERE Id = @id";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@phone",
                            phone == "" ? (object)DBNull.Value : phone);
                        cmd.Parameters.AddWithValue("@role", role);
                        if (selectedId != null)
                            cmd.Parameters.AddWithValue("@id", selectedId.Value);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Staff member saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadStaff(txtsearchstaff.Text);
                ClearForm();
                grpstaffdetails.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save staff member:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // CLEAR: empties the boxes (the next Save adds a new person)
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvstaff.ClearSelection();
            txtname.Focus();
        }

        // CANCEL: closes the details box without saving
        private void btncancel_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvstaff.ClearSelection();
            grpstaffdetails.Enabled = false;
        }

        // Nothing needed here
        private void dgvstaff_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void grpstaffdetails_Enter(object sender, EventArgs e) { }
        private void txtname_TextChanged(object sender, EventArgs e) { }
        private void txtphone_TextChanged(object sender, EventArgs e) { }
        private void cboRole_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}