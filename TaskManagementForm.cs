using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class TaskManagementForm : Form
    {
        public TaskManagementForm()
        {
            InitializeComponent();
            LoadTasks();
        }

        private void LoadTasks()
        {
            int userId = SessionManagement.CurrentUser.UserId;
            // Assigned to me
            string q1 = @"SELECT t.task_id, t.title, u.full_name AS [Assigned By], t.deadline, t.priority, t.status, t.completion_percent
                FROM Tasks t JOIN Users u ON t.assigned_by = u.user_id WHERE t.assigned_to = @uid";
            tasksToMeDataGridView.DataSource = DatabaseHelper.ExecuteQuery(q1, new Microsoft.Data.SqlClient.SqlParameter[] { new SqlParameter("@uid", userId) });

            // I assigned
            string q2 = @"SELECT t.task_id, t.title, u.full_name AS [Assigned To], t.deadline, t.priority, t.status, t.completion_percent
                FROM Tasks t JOIN Users u ON t.assigned_to = u.user_id WHERE t.assigned_by = @uid";
            tasksByMeDataGridView.DataSource = DatabaseHelper.ExecuteQuery(q2, new Microsoft.Data.SqlClient.SqlParameter[] { new SqlParameter("@uid", userId) });

            ColorCodeRows();
        }

        private void ColorCodeRows()
        {
            foreach (DataGridViewRow row in tasksToMeDataGridView.Rows)
            {
                if (row.Cells["priority"].Value == null) continue;
                string priority = row.Cells["priority"].Value.ToString();
                if (priority == "High") row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                else if (priority == "Medium") row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                else if (priority == "Low") row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            }
            foreach (DataGridViewRow row in tasksByMeDataGridView.Rows)
            {
                if (row.Cells["priority"].Value == null) continue;
                string priority = row.Cells["priority"].Value.ToString();
                if (priority == "High") row.DefaultCellStyle.BackColor = System.Drawing.Color.LightCoral;
                else if (priority == "Medium") row.DefaultCellStyle.BackColor = System.Drawing.Color.LightYellow;
                else if (priority == "Low") row.DefaultCellStyle.BackColor = System.Drawing.Color.LightGreen;
            }
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            // Open assign task dialog, collect info, insert into Tasks
            // Log activity
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            // Update status and completion percent for selected task
            // Log activity
        }

        private void btnViewComments_Click(object sender, EventArgs e)
        {
            // Show comments for selected task, allow adding new comment
            // Log activity
        }
    }
}
