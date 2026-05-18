using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class SocietiesBrowserForm : Form
    {
        public SocietiesBrowserForm()
        {
            InitializeComponent();
            this.Load += SocietiesBrowserForm_Load;
        }

        private void SocietiesBrowserForm_Load(object sender, EventArgs e)
        {
            LoadSocieties();
        }

        private void LoadSocieties(string searchText = "")
        {
            DataTable dt = DatabaseHelper.GetAllSocieties();
            
            // Apply filter if search text is provided
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                DataView dv = dt.DefaultView;
                dv.RowFilter = $"Name LIKE '%{searchText}%'";
                societiesDataGridView.DataSource = dv;
            }
            else
            {
                societiesDataGridView.DataSource = dt;
            }

            // Hide ID column if exists
            if (societiesDataGridView.Columns.Contains("SocietyId"))
                societiesDataGridView.Columns["SocietyId"].Visible = false;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Assuming you have a searchTextBox control
            // string searchText = searchTextBox.Text.Trim();
            // LoadSocieties(searchText);
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (societiesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society to join.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int societyId = Convert.ToInt32(societiesDataGridView.SelectedRows[0].Cells["SocietyId"].Value);
            int studentId = SessionManagement.CurrentUserId;

            // Check if already a member
            var existingMembership = DatabaseHelper.Memberships
                .FirstOrDefault(m => m.StudentId == studentId && m.SocietyId == societyId);
            
            if (existingMembership != null)
            {
                MessageBox.Show("You have already applied to this society.", "Info", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Apply for membership
            DatabaseHelper.ApplyForMembership(studentId, societyId);
            DatabaseHelper.LogActivity(studentId, "MEMBERSHIP_APPLY", $"Applied to society ID: {societyId}");
            
            MessageBox.Show("Membership request submitted successfully!", "Success", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadSocieties();
        }
    }
}