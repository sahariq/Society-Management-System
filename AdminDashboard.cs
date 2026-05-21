using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            this.Load += AdminDashboard_Load;
        }

        private void AdminDashboard_Load(object? sender, EventArgs e)
        {
            // Dynamic control finding (safest approach)
            FindAndSetWelcomeLabel();
            LoadUsers();
            LoadSocieties();
            LoadPendingEvents();
            LoadActivityLogs();
            LoadReports();
        }

        private void FindAndSetWelcomeLabel()
        {
            var label = this.Controls.Find("lblWelcome", true).FirstOrDefault() as Label 
                     ?? this.Controls.OfType<Label>().FirstOrDefault(l => l.Text.Contains("Welcome") || l.Name.Contains("Welcome"));

            if (label != null)
                label.Text = $"Welcome, {SessionManagement.CurrentFullName} (Administrator)";
        }

        private void LoadUsers()
        {
            var grid = usersDataGridView;
            if (grid != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("Username", typeof(string));
                dt.Columns.Add("Full Name", typeof(string));
                dt.Columns.Add("Role", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                foreach (var u in DatabaseHelper.Users)
                {
                    dt.Rows.Add(u.UserId, u.Username, u.FullName, u.Role, u.Status);
                }
                grid.DataSource = dt;
            }
        }

        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnSuspendUser_Click(object sender, EventArgs e) => MessageBox.Show("User Suspended (Demo)", "Success");
        private void btnActivateUser_Click(object sender, EventArgs e) => MessageBox.Show("User Activated (Demo)", "Success");
        private void btnResetPassword_Click(object sender, EventArgs e) => MessageBox.Show("Password Reset (Demo)", "Success");

        private void LoadSocieties()
        {
            var grid = societiesDataGridView;
            if (grid != null)
                grid.DataSource = DatabaseHelper.GetAllSocieties();
        }

        private void btnApproveSociety_Click(object sender, EventArgs e) => MessageBox.Show("Society Approved (Demo)", "Success");

        private void LoadPendingEvents()
        {
            var grid = eventsDataGridView;
            if (grid != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("EventId", typeof(int));
                dt.Columns.Add("SocietyId", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("EventDate", typeof(string));
                dt.Columns.Add("Venue", typeof(string));
                dt.Columns.Add("Capacity", typeof(int));
                dt.Columns.Add("Status", typeof(string));
                foreach (var e in DatabaseHelper.Events)
                {
                    dt.Rows.Add(e.EventId, e.SocietyId, e.Title, e.Description, e.EventDate.ToString("yyyy-MM-dd"), e.Venue, e.Capacity, e.Status);
                }
                grid.DataSource = dt;
            }
        }
        private void btnApproveEvent_Click(object sender, EventArgs e) => MessageBox.Show("Event Approved (Demo)", "Success");
        private void LoadActivityLogs()
        {
            var grid = activityLogDataGridView;
            if (grid != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("LogId", typeof(int));
                dt.Columns.Add("UserId", typeof(int));
                dt.Columns.Add("Action", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Timestamp", typeof(string));
                // Demo: fetch from DB if needed, here just show 10 logs
                using (var conn = new Microsoft.Data.Sqlite.SqliteConnection(DatabaseHelper.ConnectionString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = "SELECT LogId, UserId, Action, Description, Timestamp FROM ActivityLogs ORDER BY LogId DESC LIMIT 20";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(reader.GetInt32(0), reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetString(4));
                        }
                    }
                }
                grid.DataSource = dt;
            }
        }

        private void LoadReports()
        {
            SetLabelText("lblTotalStudents", DatabaseHelper.Users.Count(u => u.Role == "student").ToString());
            SetLabelText("lblTotalSocieties", DatabaseHelper.Societies.Count.ToString());
            SetLabelText("lblTotalEvents", DatabaseHelper.Events.Count.ToString());
            SetLabelText("lblActiveMemberships", DatabaseHelper.Memberships.Count(m => m.Status == "approved").ToString());
        }

        private void SetLabelText(string controlName, string text)
        {
            var label = this.Controls.Find(controlName, true).FirstOrDefault() as Label;
            if (label != null)
                label.Text = text;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout Confirmation", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthService.Logout();
                this.Close();
            }
        }

        // Add these methods to AdminDashboard.cs

    }
}