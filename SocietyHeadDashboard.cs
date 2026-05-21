using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class SocietyHeadDashboard : Form
    {
        public SocietyHeadDashboard()
        {
            InitializeComponent();
        }

        private void SocietyHeadDashboard_Load(object sender, EventArgs e)
        {
            if (lblWelcome != null)
                lblWelcome.Text = $"Welcome, {SessionManagement.CurrentFullName} (Society Head)";

            LoadSocietyProfile();
            LoadMembershipRequests();
            LoadEvents();
            LoadMembers();
            LoadTasks();
        }

        private void LoadSocietyProfile()
        {
            if (txtName != null) txtName.Text = "FAST Programming Club";
            if (txtDescription != null) txtDescription.Text = "Official coding and development society of FAST";
            if (txtCategory != null) txtCategory.Text = "Technical";
        }


        private void LoadEvents()
        {
            if (eventsDataGridView != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Event Title", typeof(string));
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Rows.Add("Annual Hackathon 2026", "25 May 2026", "Pending");
                dt.Rows.Add("AI Guest Session", "05 June 2026", "Approved");
                eventsDataGridView.DataSource = dt;
            }
        }


        // Update these methods in SocietyHeadDashboard.cs

        private void LoadMembershipRequests()
        {
            // Get current society ID for the logged-in head
            var society = DatabaseHelper.Societies.FirstOrDefault(s => s.HeadUserId == SessionManagement.CurrentUserId);
            if (society == null) return;
            
            DataTable dt = DatabaseHelper.GetPendingMembershipsForSociety(society.SocietyId);
            
            if (membershipRequestsDataGridView != null)
            {
                membershipRequestsDataGridView.DataSource = dt;
                
                if (membershipRequestsDataGridView.Columns.Contains("MembershipId"))
                    membershipRequestsDataGridView.Columns["MembershipId"].Visible = false;
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (membershipRequestsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a membership request to approve.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int membershipId = Convert.ToInt32(membershipRequestsDataGridView.SelectedRows[0].Cells["MembershipId"].Value);
            string studentName = membershipRequestsDataGridView.SelectedRows[0].Cells["StudentName"].Value.ToString();
            
            var result = MessageBox.Show($"Approve membership for {studentName}?", "Confirm Approval", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                DatabaseHelper.ApproveMembership(membershipId, SessionManagement.CurrentUserId);
                MessageBox.Show($"Membership for {studentName} approved!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembershipRequests();
                LoadMembers(); // Refresh members list
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (membershipRequestsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a membership request to reject.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            int membershipId = Convert.ToInt32(membershipRequestsDataGridView.SelectedRows[0].Cells["MembershipId"].Value);
            string studentName = membershipRequestsDataGridView.SelectedRows[0].Cells["StudentName"].Value.ToString();
            
            string reason = Prompt.ShowDialog("Enter rejection reason:", "Rejection Reason", "Not meeting requirements");
            
            var result = MessageBox.Show($"Reject membership for {studentName}?", "Confirm Rejection", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {
                DatabaseHelper.RejectMembership(membershipId, SessionManagement.CurrentUserId, reason);
                MessageBox.Show($"Membership for {studentName} rejected.", "Info", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadMembershipRequests();
            }
        }

        private void LoadMembers()
        {
            var society = DatabaseHelper.Societies.FirstOrDefault(s => s.HeadUserId == SessionManagement.CurrentUserId);
            if (society == null) return;
            
            string query = @"SELECT u.FullName, u.Email, m.JoinDate, m.Status 
                            FROM Memberships m
                            JOIN Users u ON m.StudentId = u.UserId
                            WHERE m.SocietyId = @sid AND m.Status = 'approved'";
            
            var parameters = new[] { new SqliteParameter("@sid", society.SocietyId) };
            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            
            if (membersDataGridView != null)
                membersDataGridView.DataSource = dt;
        }

        private void LoadTasks()
        {
            if (tasksDataGridView != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Task Title", typeof(string));
                dt.Columns.Add("Assigned To", typeof(string));
                dt.Columns.Add("Due Date", typeof(string));
                dt.Rows.Add("Prepare Presentation", "Ali Hassan", "20 May 2026");
                dt.Rows.Add("Design Poster", "Sara Ahmed", "18 May 2026");
                tasksDataGridView.DataSource = dt;
            }
        }

        private void btnUpdateSociety_Click(object sender, EventArgs e)
            => MessageBox.Show("Society profile updated successfully!", "Success");



        private void btnAddEvent_Click(object sender, EventArgs e)
        {
            string title = Prompt.ShowDialog("Enter Event Title:", "New Event");
            if (!string.IsNullOrEmpty(title))
                MessageBox.Show($"Event '{title}' created!", "Success");
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            using (var form = new TaskManagementForm())
                form.ShowDialog();
        }
    }
}