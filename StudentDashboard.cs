using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class StudentDashboard : Form
    {
        public StudentDashboard()
        {
            InitializeComponent();
            LoadAvailableSocieties();
            LoadUpcomingEvents();
            LoadMyRegistrations();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", 
                                "Logout Confirmation", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                Form1 loginForm = new Form1();
                loginForm.Show();
            }
        }

        // ====================== Existing Methods ======================
        private void LoadAvailableSocieties() { /* your existing code */ }
        private void LoadMyMemberships() { /* your code */ }
        private void btnApplyMembership_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadUpcomingEvents() { /* your code */ }
        private void btnRegisterForEvent_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadMyRegistrations() { /* your code */ }
        private void btnMyRegistrations_Click(object sender, EventArgs e)
        {
            LoadMyRegistrations();
        }

        private void btnViewTicket_Click(object sender, EventArgs e) { /* your code */ }
    }
}