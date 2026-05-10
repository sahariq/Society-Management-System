using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class SocietyHeadDashboard : Form
    {
        private int societyId = -1;

        public SocietyHeadDashboard()
        {
            InitializeComponent();
            LoadSocietyProfile();
            LoadMembershipRequests();
            LoadEvents();
            LoadMembers();
            LoadTasks();
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
        private void LoadSocietyProfile() { /* your existing code */ }
        private void btnUpdateSociety_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadMembershipRequests() { /* your code */ }
        private void btnApprove_Click(object sender, EventArgs e) { /* your code */ }
        private void btnReject_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadEvents() { /* your code */ }
        private void btnAddEvent_Click(object sender, EventArgs e) { /* your code */ }
        private void btnEditEvent_Click(object sender, EventArgs e) { /* your code */ }
        private void btnDeleteEvent_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadMembers() { /* your code */ }
        private void btnRemoveMember_Click(object sender, EventArgs e) { /* your code */ }
        private void btnChangeRole_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadTasks() { /* your code */ }
        private void btnAssignTask_Click(object sender, EventArgs e) { /* your code */ }
    }
}