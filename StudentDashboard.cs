using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            this.Load += StudentDashboard_Load;
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {SessionManagement.CurrentFullName}!";

            LoadAvailableSocieties();
            LoadMyMemberships();
            LoadUpcomingEvents();
            LoadMyRegistrations();
        }

        private void LoadAvailableSocieties()
        {
            // Use the actual name of your DataGridView from Designer
            // If it's "dataGridView1", "dgvAvailableSocieties", etc., change accordingly
            // For now, we'll comment to avoid errors
        }

        private void btnApplyMembership_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Membership request sent (Demo)", "Success");
        }

        private void LoadMyMemberships()
        {
            // Implement later if needed
        }

        private void LoadUpcomingEvents()
        {
            // Implement later
        }

        private void btnViewEvents_Click(object sender, EventArgs e)
        {
            using (var form = new EventsForm())
            {
                form.ShowDialog();
            }
        }

        private void btnBrowseSocieties_Click(object sender, EventArgs e)
        {
            using (var form = new SocietiesBrowserForm())
            {
                form.ShowDialog();
            }
        }

        private void btnMyTasks_Click(object sender, EventArgs e)
        {
            using (var form = new TaskManagementForm())
            {
                form.ShowDialog();
            }
        }

        private void LoadMyRegistrations()
        {
            // Implement later
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Logout", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AuthService.Logout();
                this.Close();
            }
        }
    }
}