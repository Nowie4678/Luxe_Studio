
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Luxe_Studio
{
    public partial class FrmDashboard : Form
    {
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        private Button activeButton;

        // Dashboard card labels
        private const string LblAppointmentsToday = "lblAppointmentsToday";
        private const string LblTotalClients = "lblTotalClients";
        private const string LblTotalServices = "lblTotalServices";
        private const string LblRevenueToday = "lblRevenueToday";

        public FrmDashboard()
        {
            InitializeComponent();
        }

        // FORM LOAD
        private void FrmDashboard_Load(object sender, EventArgs e)
        {
            HighlightButton(btndashboard);
            LoadDashboardStats();
        }

        // DASHBOARD BUTTON
        private void btndashboard_Click(object sender, EventArgs e)
        {
            HighlightButton(btndashboard);
            LoadDashboardStats();
        }

        // APPOINTMENTS BUTTON
        private void btnAppointments_Click(object sender, EventArgs e)
        {
            HighlightButton(btnAppointments);
            OpenForm(new FrmAppointment());
        }

        // CLIENTS BUTTON
        private void btnclients_Click(object sender, EventArgs e)
        {
            HighlightButton(btnclients);
            OpenForm(new Frmclient());
        }

        // SERVICES BUTTON
        private void btnservices_Click(object sender, EventArgs e)
        {
            HighlightButton(btnservices);
            OpenForm(new FrmServices());
        }

        // BILLING BUTTON
        private void btnbilling_Click(object sender, EventArgs e)
        {
            HighlightButton(btnbilling);
            OpenForm(new Frmbilling());
        }

        // REPORTS BUTTON
        private void btnReports_Click(object sender, EventArgs e)
        {
            HighlightButton(btnReports);
            OpenForm(new FrmReports());
        }

        // LOGOUT BUTTON
        private void btnlogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to log out?",
                "Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // NEW BOOKING BUTTON
        private void btnnewbooking_Click(object sender, EventArgs e)
        {
            OpenForm(new FrmAppointment());
        }

        // OPEN OTHER FORMS
        private void OpenForm(Form form)
        {
            this.Hide();

            using (form)
            {
                form.ShowDialog();
            }

            this.Show();
            LoadDashboardStats();
            HighlightButton(btndashboard);
        }

        // HIGHLIGHT SIDEBAR BUTTON
        private void HighlightButton(Button btn)
        {
            if (activeButton != null)
            {
                activeButton.BackColor = Color.FromArgb(40, 40, 40);
            }

            activeButton = btn;
            activeButton.BackColor = Color.FromArgb(180, 140, 80);
        }

        // LOAD DASHBOARD STATISTICS
        private void LoadDashboardStats()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    // TODAY'S APPOINTMENTS COUNT
                    SetLabel(
                        LblAppointmentsToday,
                        Scalar(con,
                        @"SELECT COUNT(*)
                          FROM Appointments
                          WHERE AppointmentDate = CAST(GETDATE() AS DATE)")
                    );

                    // TOTAL CLIENTS
                    SetLabel(
                        LblTotalClients,
                        Scalar(con,
                        "SELECT COUNT(*) FROM Clients")
                    );

                    // TOTAL SERVICES
                    SetLabel(
                        LblTotalServices,
                        Scalar(con,
                        "SELECT COUNT(*) FROM Services")
                    );

                    // TODAY'S REVENUE
                    SetLabel(
                        LblRevenueToday,
                        "KES " + Scalar(con,
                        @"SELECT ISNULL(SUM(Amount), 0)
                          FROM Billing
                          WHERE BillDate = CAST(GETDATE() AS DATE)")
                    );

                    // LOAD APPOINTMENTS GRID
                    LoadTodaysAppointments(con);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not load dashboard data:\n" + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // LOAD TODAY'S APPOINTMENTS INTO DATAGRIDVIEW
        private void LoadTodaysAppointments(SqlConnection con)
        {
            string sql = @"
                SELECT
                    AppointmentId,
                    ClientName,
                    Service,
                    AppointmentDate,
                    AppointmentTime,
                    Status
                FROM Appointments
                WHERE AppointmentDate = CAST(GETDATE() AS DATE)
                ORDER BY AppointmentTime";

            using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
            {
                DataTable dt = new DataTable();

                da.Fill(dt);

                dgvtodaysappointment.DataSource = dt;

                dgvtodaysappointment.ReadOnly = true;
                dgvtodaysappointment.AllowUserToAddRows = false;
                dgvtodaysappointment.AllowUserToDeleteRows = false;
                dgvtodaysappointment.RowHeadersVisible = false;

                dgvtodaysappointment.SelectionMode =
                    DataGridViewSelectionMode.FullRowSelect;

                dgvtodaysappointment.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        // EXECUTE COUNT AND SUM QUERIES
        private string Scalar(SqlConnection con, string sql)
        {
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                object value = cmd.ExecuteScalar();

                return value == null || value == DBNull.Value
                    ? "0"
                    : value.ToString();
            }
        }

        // UPDATE DASHBOARD LABELS
        private void SetLabel(string name, string text)
        {
            Control c = this.Controls.Find(name, true).FirstOrDefault();

            if (c != null)
            {
                c.Text = text;
            }
        }

        // DESIGNER EVENT HANDLERS
        private void lbltodaysappointment_Click(object sender, EventArgs e)
        {
        }

        private void dgvtodaysappointment_CellContentClick(
            object sender, DataGridViewCellEventArgs e)
        {
        }

        private void pnlTotalRevenue_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
        }

        private void lbl126_Click(object sender, EventArgs e)
        {
        }

        private void lblactiveclients_Click(object sender, EventArgs e)
        {
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            HighlightButton(btnStaff);
            OpenForm(new FrmStaff());
        }
    }
}
