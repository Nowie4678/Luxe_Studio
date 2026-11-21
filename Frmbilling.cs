using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Luxe_Studio
{
    public partial class Frmbilling : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        // Details of the last payment, used for the receipt
        private bool hasReceipt = false;
        private string rClient, rService, rMethod;
        private decimal rPrice, rDiscountPct, rTotal;
        private DateTime rDate;

        public Frmbilling()
        {
            InitializeComponent();
        }

        private void Frmbilling_Load(object sender, EventArgs e)
        {
            SetupGrid();

            cmbPaymentmethod.Items.Clear();
            cmbPaymentmethod.Items.AddRange(new string[] { "Cash", "M-Pesa", "Card" });
            cmbPaymentmethod.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPaymentmethod.SelectedIndex = 0;

            txtDiscount.Text = "0";

            dgvbillingandpayment.SelectionChanged += (s, ev) => RecalculateTotal();
            txtDiscount.TextChanged += (s, ev) => RecalculateTotal();

            LoadUnpaid();
        }

        private void SetupGrid()
        {
            try
            {
                var g = dgvbillingandpayment;
                g.AutoGenerateColumns = false;
                g.Columns.Clear();

                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colId", DataPropertyName = "AppointmentId", Visible = false });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colClient", HeaderText = "Client", DataPropertyName = "ClientName" });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colService", HeaderText = "Service", DataPropertyName = "Service" });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colStylist", HeaderText = "Stylist", DataPropertyName = "Stylist" });

                var date = new DataGridViewTextBoxColumn
                { Name = "colDate", HeaderText = "Date", DataPropertyName = "AppointmentDate" };
                date.DefaultCellStyle.Format = "dd MMM yyyy";
                g.Columns.Add(date);

                var price = new DataGridViewTextBoxColumn
                { Name = "colPrice", HeaderText = "Price (KES)", DataPropertyName = "Price" };
                price.DefaultCellStyle.Format = "N2";
                g.Columns.Add(price);

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

        // Appointments that are not cancelled and not yet billed
        private void LoadUnpaid()
        {
            string sql = @"
                SELECT a.AppointmentId, a.ClientName, a.Service, a.Stylist,
                       a.AppointmentDate, ISNULL(s.Price, 0) AS Price
                FROM Appointments a
                LEFT JOIN Services s ON s.Name = a.Service
                WHERE a.Status <> 'Cancelled'
                  AND NOT EXISTS (SELECT 1 FROM Billing b WHERE b.AppointmentId = a.AppointmentId)
                ORDER BY a.AppointmentDate DESC, a.AppointmentTime DESC";

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvbillingandpayment.DataSource = dt;
                }
                RecalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not load bills:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal GetSelectedPrice()
        {
            if (dgvbillingandpayment.CurrentRow == null) return 0;
            object v = dgvbillingandpayment.CurrentRow.Cells["colPrice"].Value;
            return (v == null || v == DBNull.Value) ? 0 : Convert.ToDecimal(v);
        }

        private bool TryGetDiscount(out decimal pct)
        {
            if (!decimal.TryParse(txtDiscount.Text.Trim(), out pct)) pct = 0;
            return pct >= 0 && pct <= 100;
        }

        private void RecalculateTotal()
        {
            decimal price = GetSelectedPrice();
            decimal pct;
            if (!TryGetDiscount(out pct)) pct = 0;

            decimal total = price - (price * pct / 100m);
            lblTotal.Text = "KES " + total.ToString("N2");
        }

        private void btnpaynow_Click(object sender, EventArgs e)
        {
            if (dgvbillingandpayment.CurrentRow == null)
            {
                MessageBox.Show("Select an appointment to bill first.", "Nothing selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal pct;
            if (!TryGetDiscount(out pct))
            {
                MessageBox.Show("Discount must be a number between 0 and 100.", "Invalid discount",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return;
            }

            if (cmbPaymentmethod.SelectedIndex < 0)
            {
                MessageBox.Show("Select a payment method.", "Missing payment method",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvbillingandpayment.CurrentRow;
            int appointmentId = Convert.ToInt32(row.Cells["colId"].Value);
            string client = row.Cells["colClient"].Value?.ToString();
            string service = row.Cells["colService"].Value?.ToString();
            decimal price = GetSelectedPrice();

            if (price <= 0)
            {
                MessageBox.Show("No price was found for \"" + service + "\".\n" +
                    "Check that this service exists in the Services table with a price.",
                    "Missing price", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal total = price - (price * pct / 100m);
            string method = cmbPaymentmethod.SelectedItem.ToString();

            DialogResult confirm = MessageBox.Show(
                "Charge " + client + " KES " + total.ToString("N2") + " by " + method + "?",
                "Confirm payment", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();
                    using (SqlTransaction tx = con.BeginTransaction())
                    {
                        using (SqlCommand ins = new SqlCommand(
                            @"INSERT INTO Billing
                                (AppointmentId, ClientName, Service, Amount, Discount, PaymentMethod, BillDate)
                              VALUES
                                (@aid, @client, @service, @amount, @discount, @method, @date)", con, tx))
                        {
                            ins.Parameters.AddWithValue("@aid", appointmentId);
                            ins.Parameters.AddWithValue("@client", client);
                            ins.Parameters.AddWithValue("@service", service);

                            SqlParameter pAmount = ins.Parameters.Add("@amount", SqlDbType.Decimal);
                            pAmount.Precision = 18;
                            pAmount.Scale = 2;
                            pAmount.Value = total;

                            SqlParameter pDiscount = ins.Parameters.Add("@discount", SqlDbType.Decimal);
                            pDiscount.Precision = 18;
                            pDiscount.Scale = 2;
                            pDiscount.Value = pct;

                            ins.Parameters.AddWithValue("@method", method);
                            ins.Parameters.Add("@date", SqlDbType.Date).Value = DateTime.Today;
                            ins.ExecuteNonQuery();
                        }

                        using (SqlCommand upd = new SqlCommand(
                            "UPDATE Appointments SET Status = 'Completed' WHERE AppointmentId = @aid", con, tx))
                        {
                            upd.Parameters.AddWithValue("@aid", appointmentId);
                            upd.ExecuteNonQuery();
                        }

                        tx.Commit();
                    }
                }

                // Remember this payment for the receipt
                hasReceipt = true;
                rClient = client;
                rService = service;
                rMethod = method;
                rPrice = price;
                rDiscountPct = pct;
                rTotal = total;
                rDate = DateTime.Now;

                txtDiscount.Text = "0";
                LoadUnpaid();

                DialogResult print = MessageBox.Show("Payment recorded. Print the receipt now?",
                    "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (print == DialogResult.Yes) ShowReceipt();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not record payment:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrintreceipt_Click(object sender, EventArgs e)
        {
            if (!hasReceipt)
            {
                MessageBox.Show("There is no payment to print yet. Record a payment first.",
                    "No receipt", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ShowReceipt();
        }

        private void ShowReceipt()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += Receipt_PrintPage;

            using (PrintPreviewDialog preview = new PrintPreviewDialog())
            {
                preview.Document = pd;
                preview.Width = 700;
                preview.Height = 800;
                preview.ShowDialog(this);
            }
        }

        private void Receipt_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Font title = new Font("Arial", 18, FontStyle.Bold);
            Font normal = new Font("Arial", 11);
            Font bold = new Font("Arial", 11, FontStyle.Bold);

            float x = 60, y = 60, line = 26;

            g.DrawString("LUXE STUDIO", title, Brushes.Black, x, y); y += 40;
            g.DrawString("Payment Receipt", bold, Brushes.Black, x, y); y += line;
            g.DrawString("Date: " + rDate.ToString("dd MMM yyyy HH:mm"), normal, Brushes.Black, x, y); y += line * 1.5f;

            g.DrawString("Client:   " + rClient, normal, Brushes.Black, x, y); y += line;
            g.DrawString("Service:  " + rService, normal, Brushes.Black, x, y); y += line;
            g.DrawString("Price:    KES " + rPrice.ToString("N2"), normal, Brushes.Black, x, y); y += line;
            g.DrawString("Discount: " + rDiscountPct.ToString("0.##") + "%", normal, Brushes.Black, x, y); y += line;
            g.DrawString("Method:   " + rMethod, normal, Brushes.Black, x, y); y += line * 1.5f;

            g.DrawString("TOTAL PAID: KES " + rTotal.ToString("N2"), bold, Brushes.Black, x, y); y += line * 2;
            g.DrawString("Thank you for visiting Luxe Studio!", normal, Brushes.Black, x, y);

            e.HasMorePages = false;
        }

        // Captions and grid clicks need no logic
        private void dgvbillingandpayment_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTotal_Click(object sender, EventArgs e) { }
        private void lblDiscount_Click(object sender, EventArgs e) { }
        private void lblpaymentmethod_Click(object sender, EventArgs e) { }
    }
}