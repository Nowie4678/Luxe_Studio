using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Luxe_Studio
{
    public partial class FrmServices : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        // Id of the service being edited (null = adding a new one)
        private int? selectedId = null;

        public FrmServices()
        {
            InitializeComponent();
        }

        private void FrmServices_Load(object sender, EventArgs e)
        {
            SetupGrid();

            // Click a row to load it into the boxes
            dgvServices.CellClick += (s, ev) =>
            {
                if (ev.RowIndex >= 0) FillFromRow(dgvServices.Rows[ev.RowIndex]);
            };

            // Optional "Clear" button, connected only if it exists on the form
            Control clearBtn = this.Controls.Find("btnclear", true).Length > 0
                ? this.Controls.Find("btnclear", true)[0] : null;
            if (clearBtn != null) clearBtn.Click += (s, ev) => ClearForm();

            LoadServices();
            ClearForm();
        }

        private void SetupGrid()
        {
            try
            {
                var g = dgvServices;
                g.AutoGenerateColumns = false;
                g.Columns.Clear();

                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colId", DataPropertyName = "Id", Visible = false });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colName", HeaderText = "Service", DataPropertyName = "Name" });

                var price = new DataGridViewTextBoxColumn
                { Name = "colPrice", HeaderText = "Price (KES)", DataPropertyName = "Price" };
                price.DefaultCellStyle.Format = "N2";
                g.Columns.Add(price);

                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colDuration", HeaderText = "Duration (min)", DataPropertyName = "DurationMinutes" });

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

        private void LoadServices()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, Name, Price, DurationMinutes FROM Services WHERE Active = 1 ORDER BY Name", con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvServices.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load services:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFromRow(DataGridViewRow row)
        {
            selectedId = Convert.ToInt32(row.Cells["colId"].Value);
            txtservicename.Text = row.Cells["colName"].Value?.ToString();
            txtprice.Text = Convert.ToDecimal(row.Cells["colPrice"].Value).ToString("0.##");
            txtduration.Text = row.Cells["colDuration"].Value?.ToString();
        }

        private void ClearForm()
        {
            selectedId = null;
            txtservicename.Clear();
            txtprice.Clear();
            txtduration.Clear();
            dgvServices.ClearSelection();
            txtservicename.Focus();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtservicename.Text.Trim();
            decimal price;
            int duration;

            if (name == "")
            {
                MessageBox.Show("Please enter the service name.", "Missing name",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtservicename.Focus();
                return;
            }
            if (!decimal.TryParse(txtprice.Text.Trim(), out price) || price <= 0)
            {
                MessageBox.Show("Enter a valid price greater than 0.", "Invalid price",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtprice.Focus();
                return;
            }
            if (!int.TryParse(txtduration.Text.Trim(), out duration) || duration <= 0)
            {
                MessageBox.Show("Enter the duration in minutes (a whole number greater than 0).",
                    "Invalid duration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtduration.Focus();
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    if (selectedId == null)
                    {
                        // Is there already a service with this name (active or not)?
                        int? existingId = null;
                        bool existingActive = false;

                        using (SqlCommand find = new SqlCommand(
                            "SELECT TOP 1 Id, Active FROM Services WHERE Name = @name", con))
                        {
                            find.Parameters.AddWithValue("@name", name);
                            using (SqlDataReader r = find.ExecuteReader())
                            {
                                if (r.Read())
                                {
                                    existingId = r.GetInt32(0);
                                    existingActive = r.GetBoolean(1);
                                }
                            }
                        }

                        if (existingId != null && existingActive)
                        {
                            MessageBox.Show("A service with this name already exists.", "Duplicate",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (existingId != null)
                        {
                            // Bring back a previously deleted service with the new details
                            using (SqlCommand re = new SqlCommand(
                                @"UPDATE Services SET Price = @price, DurationMinutes = @dur, Active = 1
                                  WHERE Id = @id", con))
                            {
                                AddPriceParam(re, price);
                                re.Parameters.AddWithValue("@dur", duration);
                                re.Parameters.AddWithValue("@id", existingId.Value);
                                re.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            using (SqlCommand ins = new SqlCommand(
                                @"INSERT INTO Services (Name, Price, DurationMinutes, Active)
                                  VALUES (@name, @price, @dur, 1)", con))
                            {
                                ins.Parameters.AddWithValue("@name", name);
                                AddPriceParam(ins, price);
                                ins.Parameters.AddWithValue("@dur", duration);
                                ins.ExecuteNonQuery();
                            }
                        }
                    }
                    else
                    {
                        // Make sure the new name doesn't clash with another service
                        using (SqlCommand check = new SqlCommand(
                            "SELECT COUNT(*) FROM Services WHERE Name = @name AND Id <> @id", con))
                        {
                            check.Parameters.AddWithValue("@name", name);
                            check.Parameters.AddWithValue("@id", selectedId.Value);
                            if ((int)check.ExecuteScalar() > 0)
                            {
                                MessageBox.Show("Another service already uses this name.", "Duplicate",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                        }

                        using (SqlCommand upd = new SqlCommand(
                            @"UPDATE Services SET Name = @name, Price = @price, DurationMinutes = @dur
                              WHERE Id = @id", con))
                        {
                            upd.Parameters.AddWithValue("@name", name);
                            AddPriceParam(upd, price);
                            upd.Parameters.AddWithValue("@dur", duration);
                            upd.Parameters.AddWithValue("@id", selectedId.Value);
                            upd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Service saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save service:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show("Click a service in the list first.", "Nothing selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Remove \"" + txtservicename.Text + "\" from the services list?\n" +
                "Past bookings and receipts are not affected.",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlCommand cmd = new SqlCommand(
                    "UPDATE Services SET Active = 0 WHERE Id = @id", con))
                {
                    cmd.Parameters.AddWithValue("@id", selectedId.Value);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                LoadServices();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not remove service:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sends the price with 2 decimal places so cents are not lost
        private void AddPriceParam(SqlCommand cmd, decimal price)
        {
            SqlParameter p = cmd.Parameters.Add("@price", SqlDbType.Decimal);
            p.Precision = 18;
            p.Scale = 2;
            p.Value = price;
        }

        // Captions and panel need no logic
        private void pnl_Paint(object sender, PaintEventArgs e) { }
        private void lblservicename_Click(object sender, EventArgs e) { }
        private void lblprice_Click(object sender, EventArgs e) { }
        private void lblduration_Click(object sender, EventArgs e) { }
        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}