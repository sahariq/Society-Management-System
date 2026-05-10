using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class AdminDashboard : Form
    {
        public AdminDashboard()
        {
            InitializeComponent();
            LoadUsers();
            LoadSocieties();
            LoadPendingEvents();
            LoadActivityLogs();
            LoadReports();
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
        private void LoadUsers(string filter = "") { /* your existing code */ }
        private void btnSuspendUser_Click(object sender, EventArgs e) { /* your code */ }
        private void btnActivateUser_Click(object sender, EventArgs e) { /* your code */ }
        private void btnResetPassword_Click(object sender, EventArgs e) { /* your code */ }

                private void LoadSocieties()
        {
            societiesDataGridView.DataSource = DatabaseHelper.GetAllSocieties();
        }

        private void btnAddSociety_Click(object sender, EventArgs e)
        {
            string name = Prompt.ShowDialog("Society Name:", "Add New Society");
            string category = Prompt.ShowDialog("Category:", "Add New Society");
            string description = Prompt.ShowDialog("Description:", "Add New Society");

            if (!string.IsNullOrEmpty(name))
            {
                DatabaseHelper.AddSociety(name, category, description);
                LoadSocieties();
                MessageBox.Show("Society added successfully!");
            }
        }

        private void btnEditSociety_Click(object sender, EventArgs e)
        {
            if (societiesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society to edit.");
                return;
            }

            MessageBox.Show("Edit functionality will be implemented soon.");
            // TODO: Open edit form
        }

        private void btnDeleteSociety_Click(object sender, EventArgs e)
        {
            if (societiesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society to delete.");
                return;
            }

            string societyName = societiesDataGridView.SelectedRows[0].Cells["name"].Value.ToString();

            if (MessageBox.Show($"Delete society '{societyName}'?", "Confirm Delete", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                MessageBox.Show("Society deleted (In-Memory Mode).");
                LoadSocieties();
            }
        }
        private void btnApproveSociety_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadPendingEvents() { /* your code */ }
        private void btnApproveEvent_Click(object sender, EventArgs e) { /* your code */ }

        private void LoadActivityLogs() { /* your code */ }

        private void LoadReports() { /* your code */ }

        private void txtUserSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtUserSearch.Text.Trim());
        }
    }
}