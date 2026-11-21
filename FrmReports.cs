using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace Luxe_Studio
{
    public partial class FrmReports : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        // The report currently on screen (used for printing and PDF export)
        private bool hasReport = false;
        private DateTime reportFrom, reportTo;
        private decimal reportRevenue, reportAppointments;
        private string reportTopService = "-";
        private DataTable reportTable;

        // Printing state
        private int printRow = 0;
        private bool firstPage = true;

        public FrmReports()
        {
            InitializeComponent();
        }

        private void FrmReports_Load(object sender, EventArgs e)
        {
            SetupGrid();

            // Default range: first day of this month to today
            DateTime today = DateTime.Today;
            SetDate("dtpFrom", new DateTime(today.Year, today.Month, 1));
            SetDate("dtpTo", today);

            GenerateReport();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void SetupGrid()
        {
            try
            {
                var g = dgvServices;
                g.AutoGenerateColumns = false;
                g.Columns.Clear();

                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colService", HeaderText = "Service", DataPropertyName = "Service" });
                g.Columns.Add(new DataGridViewTextBoxColumn
                { Name = "colBookings", HeaderText = "Bookings", DataPropertyName = "Bookings" });

                var revenue = new DataGridViewTextBoxColumn
                { Name = "colRevenue", HeaderText = "Revenue (KES)", DataPropertyName = "Revenue" };
                revenue.DefaultCellStyle.Format = "N2";
                g.Columns.Add(revenue);

                g.ReadOnly = true;
                g.AllowUserToAddRows = false;
                g.AllowUserToDeleteRows = false;
                g.RowHeadersVisible = false;
                g.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                g.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not set up the grid:\n" + ex.Message);
            }
        }

        private void GenerateReport()
        {
            hasReport = false;

            DateTime from = GetDate("dtpFrom", new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1));
            DateTime to = GetDate("dtpTo", DateTime.Today);

            if (from > to)
            {
                MessageBox.Show("The start date cannot be after the end date.", "Invalid dates",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    // TOTAL REVENUE
                    decimal revenue = ScalarDecimal(con,
                        "SELECT ISNULL(SUM(Amount), 0) FROM Billing WHERE BillDate BETWEEN @from AND @to",
                        from, to);
                    SetLabel("lblTotalRevenue", "KES " + revenue.ToString("N2"));

                    // APPOINTMENTS (not cancelled)
                    decimal appointments = ScalarDecimal(con,
                        @"SELECT COUNT(*) FROM Appointments
                          WHERE AppointmentDate BETWEEN @from AND @to AND Status <> 'Cancelled'",
                        from, to);
                    SetLabel("lblAppointments", appointments.ToString("0"));

                    // SERVICES BREAKDOWN (paid bills)
                    string sql = @"
                        SELECT Service, COUNT(*) AS Bookings, ISNULL(SUM(Amount), 0) AS Revenue
                        FROM Billing
                        WHERE BillDate BETWEEN @from AND @to
                        GROUP BY Service
                        ORDER BY COUNT(*) DESC, SUM(Amount) DESC";

                    string topService = "-";
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                    {
                        da.SelectCommand.Parameters.Add("@from", SqlDbType.Date).Value = from.Date;
                        da.SelectCommand.Parameters.Add("@to", SqlDbType.Date).Value = to.Date;
                        da.Fill(dt);
                    }

                    dgvServices.DataSource = dt;

                    // TOP SERVICE = first row (most bookings)
                    if (dt.Rows.Count > 0)
                    {
                        topService = dt.Rows[0]["Service"] + " (" + dt.Rows[0]["Bookings"] + ")";
                    }
                    SetLabel("lblTopService", topService);

                    // Remember this report for printing / PDF
                    reportFrom = from;
                    reportTo = to;
                    reportRevenue = revenue;
                    reportAppointments = appointments;
                    reportTopService = topService;
                    reportTable = dt;
                    hasReport = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not generate the report:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal ScalarDecimal(SqlConnection con, string sql, DateTime from, DateTime to)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.Add("@from", SqlDbType.Date).Value = from.Date;
                cmd.Parameters.Add("@to", SqlDbType.Date).Value = to.Date;

                object v = cmd.ExecuteScalar();
                return (v == null || v == DBNull.Value) ? 0 : Convert.ToDecimal(v);
            }
        }

        // PRINT: opens a print preview of the report
        private void Print_Click(object sender, EventArgs e)
        {
            GenerateReport();          // make sure the report matches the selected dates
            if (!hasReport) return;

            PrintDocument pd = CreateReportDocument();

            using (PrintPreviewDialog preview = new PrintPreviewDialog())
            {
                preview.Document = pd;
                preview.Width = 800;
                preview.Height = 900;
                preview.ShowDialog(this);
            }
        }

        // EXPORT PDF: saves the report using Windows' "Microsoft Print to PDF" printer
        private void btnexportpdf_Click(object sender, EventArgs e)
        {
            GenerateReport();
            if (!hasReport) return;

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "PDF file (*.pdf)|*.pdf";
                dlg.FileName = "LuxeStudio_Report_" + reportFrom.ToString("yyyyMMdd") +
                               "_" + reportTo.ToString("yyyyMMdd") + ".pdf";

                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    PrintDocument pd = CreateReportDocument();
                    pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";

                    if (!pd.PrinterSettings.IsValid)
                    {
                        MessageBox.Show(
                            "The \"Microsoft Print to PDF\" printer was not found on this computer.\n" +
                            "Use the Print button instead and choose a PDF printer.",
                            "PDF printer missing", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    pd.PrinterSettings.PrintToFile = true;
                    pd.PrinterSettings.PrintFileName = dlg.FileName;
                    pd.Print();

                    DialogResult open = MessageBox.Show("PDF saved. Open it now?", "Export complete",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (open == DialogResult.Yes)
                        Process.Start(new ProcessStartInfo(dlg.FileName) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Could not export the PDF:\n" + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private PrintDocument CreateReportDocument()
        {
            PrintDocument pd = new PrintDocument();
            pd.BeginPrint += (s, e) => { printRow = 0; firstPage = true; };
            pd.PrintPage += Report_PrintPage;
            return pd;
        }

        // Draws the report: header, summary figures, then the services table
        private void Report_PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            Rectangle m = e.MarginBounds;
            float left = m.Left, right = m.Right, y = m.Top;
            float rowH = 26;

            using (Font title = new Font("Arial", 20, FontStyle.Bold))
            using (Font bold = new Font("Arial", 11, FontStyle.Bold))
            using (Font normal = new Font("Arial", 11))
            using (Font small = new Font("Arial", 9))
            using (StringFormat far = new StringFormat { Alignment = StringAlignment.Far })
            using (Pen line = new Pen(Color.Gray))
            {
                if (firstPage)
                {
                    g.DrawString("LUXE STUDIO", title, Brushes.Black, left, y); y += 42;
                    g.DrawString("Business Report", bold, Brushes.Black, left, y); y += 26;
                    g.DrawString("Period: " + reportFrom.ToString("dd MMM yyyy") + " to " +
                                 reportTo.ToString("dd MMM yyyy"), normal, Brushes.Black, left, y);
                    y += 40;

                    g.DrawString("Total revenue:  KES " + reportRevenue.ToString("N2"), normal, Brushes.Black, left, y); y += 26;
                    g.DrawString("Appointments:   " + reportAppointments.ToString("0"), normal, Brushes.Black, left, y); y += 26;
                    g.DrawString("Top service:    " + reportTopService, normal, Brushes.Black, left, y); y += 44;

                    firstPage = false;
                }

                // Table header
                float col2 = left + (right - left) * 0.60f;
                g.DrawString("Service", bold, Brushes.Black, left, y);
                g.DrawString("Bookings", bold, Brushes.Black, col2, y);
                g.DrawString("Revenue (KES)", bold, Brushes.Black,
                    new RectangleF(left, y, right - left, rowH), far);
                y += rowH;
                g.DrawLine(line, left, y, right, y);
                y += 4;

                // Table rows (continues on the next page if needed)
                if (reportTable.Rows.Count == 0)
                {
                    g.DrawString("No paid bills in this period.", normal, Brushes.Black, left, y);
                    y += rowH;
                }

                while (printRow < reportTable.Rows.Count)
                {
                    if (y + rowH > m.Bottom - 30)
                    {
                        e.HasMorePages = true;
                        return;
                    }

                    DataRow r = reportTable.Rows[printRow];
                    g.DrawString(r["Service"].ToString(), normal, Brushes.Black, left, y);
                    g.DrawString(r["Bookings"].ToString(), normal, Brushes.Black, col2, y);
                    g.DrawString(Convert.ToDecimal(r["Revenue"]).ToString("N2"), normal, Brushes.Black,
                        new RectangleF(left, y, right - left, rowH), far);

                    y += rowH;
                    printRow++;
                }

                g.DrawString("Generated on " + DateTime.Now.ToString("dd MMM yyyy HH:mm"),
                    small, Brushes.Gray, left, m.Bottom - 15);
            }

            e.HasMorePages = false;
        }

        // Finds a label by name (anywhere on the form, including inside panels)
        private void SetLabel(string name, string text)
        {
            Control c = this.Controls.Find(name, true).FirstOrDefault();
            if (c != null) c.Text = text;
        }

        // Reads a DateTimePicker by name, or returns the default if it is missing
        private DateTime GetDate(string name, DateTime fallback)
        {
            DateTimePicker dtp = this.Controls.Find(name, true).FirstOrDefault() as DateTimePicker;
            return dtp != null ? dtp.Value.Date : fallback;
        }

        private void SetDate(string name, DateTime value)
        {
            DateTimePicker dtp = this.Controls.Find(name, true).FirstOrDefault() as DateTimePicker;
            if (dtp != null) dtp.Value = value;
        }

        // Panels, labels and grid need no logic
        private void pnlTotalRevenue_Paint(object sender, PaintEventArgs e) { }
        private void pnlappointments_Paint(object sender, PaintEventArgs e) { }
        private void pnltopservice_Paint(object sender, PaintEventArgs e) { }

        private void lbltotalrevenue_Click(object sender, EventArgs e)
        {

        }

        private void dgvServices_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblappointments_Click(object sender, EventArgs e) { }
    }
}