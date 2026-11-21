using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Luxe_Studio
{
    public partial class FrmAppointment : Form
    {
        // Same connection string as the dashboard
        private readonly string connString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\nowie\OneDrive\Documents\LUXE_STUDIO.MDF;Integrated Security=True;Connect Timeout=30";

        public FrmAppointment()
        {
            InitializeComponent();
            this.Load += FrmAppointment_Load;
        }

        private void FrmAppointment_Load(object sender, EventArgs e)
        {
            // Stylists
            cmbStylist.Items.Clear();
            cmbStylist.Items.AddRange(new string[] { "Amina", "Brian", "Cynthia", "David" });
            cmbStylist.DropDownStyle = ComboBoxStyle.DropDownList;

            // Services
            cmbService.Items.Clear();
            cmbService.Items.AddRange(new string[]
            {
                "Haircut", "Braiding", "Hair Coloring", "Manicure",
                "Pedicure", "Facial", "Massage"
            });
            cmbStylist.DropDownStyle = ComboBoxStyle.DropDownList;

            // Date/time pickers
            dtpDate.MinDate = DateTime.Today;
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.ShowUpDown = true;

            ClearForm();
        }

        private void txtsearchoraddclient_TextChanged(object sender, EventArgs e)
        {
            // Optional: leave empty, or add client auto-suggest from the Clients table
        }

        private void btnsavebooking_Click(object sender, EventArgs e)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(txtsearchoraddclient.Text))
            {
                MessageBox.Show("Please enter the client's name.", "Missing client",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtsearchoraddclient.Focus();
                return;
            }
            if (cmbStylist.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a stylist.", "Missing stylist",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbStylist.Focus();
                return;
            }
            if (cmbService.SelectedIndex < 0)
            {
                MessageBox.Show("Please select a service.", "Missing service",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbService.Focus();
                return;
            }

            DateTime appointment = dtpDate.Value.Date + dtpTime.Value.TimeOfDay;
            if (appointment < DateTime.Now)
            {
                MessageBox.Show("Appointment time cannot be in the past.", "Invalid time",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string client = txtsearchoraddclient.Text.Trim();
            string stylist = cmbStylist.SelectedItem.ToString();
            string service = cmbService.SelectedItem.ToString();
            string notes = txtallergiesorpreferences.Text.Trim();

            try
            {
                using (SqlConnection con = new SqlConnection(connString))
                {
                    con.Open();

                    // Prevent double-booking the same stylist at the same time
                    string checkSql = @"SELECT COUNT(*) FROM Appointments
                                        WHERE Stylist = @stylist
                                          AND AppointmentDate = @date
                                          AND AppointmentTime = @time
                                          AND Status <> 'Cancelled'";

                    using (SqlCommand check = new SqlCommand(checkSql, con))
                    {
                        check.Parameters.AddWithValue("@stylist", stylist);
                        check.Parameters.Add("@date", SqlDbType.Date).Value = appointment.Date;
                        check.Parameters.Add("@time", SqlDbType.Time).Value = appointment.TimeOfDay;

                        if ((int)check.ExecuteScalar() > 0)
                        {
                            MessageBox.Show(stylist + " is already booked at that time.",
                                "Conflict", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Save the booking
                    string insertSql = @"INSERT INTO Appointments
                        (ClientName, Service, Stylist, AppointmentDate, AppointmentTime, Status, Notes)
                        VALUES
                        (@client, @service, @stylist, @date, @time, @status, @notes)";

                    using (SqlCommand cmd = new SqlCommand(insertSql, con))
                    {
                        cmd.Parameters.AddWithValue("@client", client);
                        cmd.Parameters.AddWithValue("@service", service);
                        cmd.Parameters.AddWithValue("@stylist", stylist);
                        cmd.Parameters.Add("@date", SqlDbType.Date).Value = appointment.Date;
                        cmd.Parameters.Add("@time", SqlDbType.Time).Value = appointment.TimeOfDay;
                        cmd.Parameters.AddWithValue("@status", "Booked");
                        cmd.Parameters.AddWithValue("@notes", notes);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Booking saved successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not save booking:\n" + ex.Message, "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtsearchoraddclient.Clear();
            txtallergiesorpreferences.Clear();
            cmbStylist.SelectedIndex = -1;
            cmbService.SelectedIndex = -1;
            dtpDate.Value = DateTime.Today;
            dtpTime.Value = DateTime.Now;
            txtsearchoraddclient.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void lblstylist_Click(object sender, EventArgs e) { }
        private void lblservice_Click(object sender, EventArgs e) { }
        private void lblnotes_Click(object sender, EventArgs e) { }
    }
}