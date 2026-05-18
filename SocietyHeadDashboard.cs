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

        private void LoadMembershipRequests()
        {
            if (membershipRequestsDataGridView != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Applied On", typeof(string));
                dt.Rows.Add("Ali Hassan", "2026-05-08");
                dt.Rows.Add("Sara Ahmed", "2026-05-09");
                membershipRequestsDataGridView.DataSource = dt;
            }
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

        private void LoadMembers()
        {
            if (membersDataGridView != null)
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("Student Name", typeof(string));
                dt.Columns.Add("Status", typeof(string));
                dt.Rows.Add("Ali Hassan", "Active");
                dt.Rows.Add("Sara Ahmed", "Active");
                membersDataGridView.DataSource = dt;
            }
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

        private void btnApprove_Click(object sender, EventArgs e)
            => MessageBox.Show("Membership Approved!", "Success");

        private void btnReject_Click(object sender, EventArgs e)
            => MessageBox.Show("Membership Rejected.", "Info");

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