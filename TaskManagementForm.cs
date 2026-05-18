using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SocietiesManagementSystem
{
    public partial class TaskManagementForm : Form
    {
        public TaskManagementForm()
        {
            InitializeComponent();
            this.Load += TaskManagementForm_Load;
        }

        private void TaskManagementForm_Load(object sender, EventArgs e)
        {
            LoadTasks();
        }

        private void LoadTasks()
        {
            int currentUserId = SessionManagement.CurrentUserId;

            DataTable dtToMe = new DataTable();
            dtToMe.Columns.Add("TaskId", typeof(int));
            dtToMe.Columns.Add("Title", typeof(string));
            dtToMe.Columns.Add("Assigned By", typeof(string));
            dtToMe.Columns.Add("Due Date", typeof(string));
            dtToMe.Columns.Add("Priority", typeof(string));
            dtToMe.Columns.Add("Status", typeof(string));

            var tasksToMe = DatabaseHelper.Tasks.Where(t => t.AssignedTo == currentUserId).ToList();

            foreach (var task in tasksToMe)
            {
                var assignedBy = DatabaseHelper.GetUserById(task.AssignedBy);
                dtToMe.Rows.Add(task.TaskId, task.Title, assignedBy?.FullName ?? "Society Head",
                    task.DueDate.ToString("dd MMM yyyy"), task.Priority, task.Status);
            }

            tasksToMeDataGridView.DataSource = dtToMe;
            if (tasksToMeDataGridView.Columns["TaskId"] != null)
                tasksToMeDataGridView.Columns["TaskId"].Visible = false;

            DataTable dtByMe = new DataTable();
            dtByMe.Columns.Add("TaskId", typeof(int));
            dtByMe.Columns.Add("Title", typeof(string));
            dtByMe.Columns.Add("Assigned To", typeof(string));
            dtByMe.Columns.Add("Due Date", typeof(string));
            dtByMe.Columns.Add("Priority", typeof(string));
            dtByMe.Columns.Add("Status", typeof(string));

            var currentUserSocieties = DatabaseHelper.Societies.Where(s => s.HeadUserId == currentUserId).Select(s => s.SocietyId).ToList();
            var tasksByMe = DatabaseHelper.Tasks.Where(t => currentUserSocieties.Contains(t.SocietyId)).ToList();

            foreach (var task in tasksByMe)
            {
                var assignedTo = DatabaseHelper.GetUserById(task.AssignedTo);
                dtByMe.Rows.Add(task.TaskId, task.Title, assignedTo?.FullName ?? "Unknown",
                    task.DueDate.ToString("dd MMM yyyy"), task.Priority, task.Status);
            }

            tasksByMeDataGridView.DataSource = dtByMe;
            if (tasksByMeDataGridView.Columns["TaskId"] != null)
                tasksByMeDataGridView.Columns["TaskId"].Visible = false;

            ColorCodeRows();
        }

        private void ColorCodeRows()
        {
            foreach (DataGridViewRow row in tasksToMeDataGridView.Rows)
            {
                if (row.Cells["Priority"].Value == null) continue;
                string priority = row.Cells["Priority"].Value.ToString();

                if (priority == "High")
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (priority == "Medium")
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                else if (priority == "Low")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
            }

            foreach (DataGridViewRow row in tasksByMeDataGridView.Rows)
            {
                if (row.Cells["Priority"].Value == null) continue;
                string priority = row.Cells["Priority"].Value.ToString();

                if (priority == "High")
                    row.DefaultCellStyle.BackColor = Color.LightCoral;
                else if (priority == "Medium")
                    row.DefaultCellStyle.BackColor = Color.LightYellow;
                else if (priority == "Low")
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (tasksToMeDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Please select a task from 'Tasks Assigned To Me' list first.", "Warning");
                return;
            }

            int taskId = Convert.ToInt32(tasksToMeDataGridView.CurrentRow.Cells["TaskId"].Value);
            var task = DatabaseHelper.Tasks.FirstOrDefault(t => t.TaskId == taskId);

            if (task != null)
            {
                string newStatus = Prompt.ShowDialog("Enter new Status (pending/in-progress/completed):", "Update Status", task.Status);
                    
                if (!string.IsNullOrEmpty(newStatus))
                {
                    string statusLower = newStatus.ToLower();
                    if (statusLower == "pending" || statusLower == "in-progress" || statusLower == "completed" || statusLower == "inprogress")
                    {
                        if (statusLower == "inprogress") statusLower = "in-progress";
                        task.Status = statusLower;
                        DatabaseHelper.UpdateTaskStatus(taskId, statusLower);
                        DatabaseHelper.LogActivity(SessionManagement.CurrentUserId, "TASK_UPDATED", $"Updated task {task.Title} to {statusLower}");
                        MessageBox.Show("Task status updated successfully!", "Success");
                        LoadTasks();
                    }
                    else
                    {
                        MessageBox.Show("Invalid status! Use: pending, in-progress, or completed", "Error");
                    }
                }
            }
        }

        private void btnViewComments_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Task Comments & Discussion feature is coming soon.\n\nThis feature will allow team members to collaborate on tasks.", 
                "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAssignTask_Click(object sender, EventArgs e)
        {
            if (SessionManagement.CurrentRole != "society_head")
            {
                MessageBox.Show("Only Society Heads can assign tasks.", "Access Denied", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string title = Prompt.ShowDialog("Enter Task Title:", "Assign New Task");
            if (string.IsNullOrEmpty(title)) return;

            string description = Prompt.ShowDialog("Enter Task Description:", "Task Description", "No description provided");
            
            string studentName = Prompt.ShowDialog("Enter Student Name to assign task:", "Assign To");
            if (string.IsNullOrEmpty(studentName)) return;
            
            var student = DatabaseHelper.Users.FirstOrDefault(u => u.Role == "student" && 
                u.FullName.ToLower().Contains(studentName.ToLower()));
            
            if (student == null)
            {
                MessageBox.Show($"Student '{studentName}' not found!", "Error");
                return;
            }

            var society = DatabaseHelper.Societies.FirstOrDefault(s => s.HeadUserId == SessionManagement.CurrentUserId);
            if (society == null)
            {
                MessageBox.Show("No society found for you!", "Error");
                return;
            }

            string priority = "Medium";
            var priorityDialog = new Form
            {
                Text = "Select Priority",
                Width = 300,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent
            };
            
            ComboBox cmbPriority = new ComboBox
            {
                Left = 20,
                Top = 30,
                Width = 240,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPriority.Items.AddRange(new[] { "Low", "Medium", "High" });
            cmbPriority.SelectedIndex = 1;
            
            Button btnOk = new Button { Text = "OK", Left = 100, Top = 80, Width = 80, DialogResult = DialogResult.OK };
            Button btnCancel = new Button { Text = "Cancel", Left = 190, Top = 80, Width = 70, DialogResult = DialogResult.Cancel };
            
            priorityDialog.Controls.AddRange(new Control[] { new Label { Text = "Select Priority Level:", Left = 20, Top = 10, Width = 240 }, cmbPriority, btnOk, btnCancel });
            priorityDialog.AcceptButton = btnOk;
            
            if (priorityDialog.ShowDialog() == DialogResult.OK)
            {
                priority = cmbPriority.SelectedItem.ToString();
            }
            else
            {
                return;
            }

            DateTime dueDate = DateTime.Now.AddDays(7);
            var dateDialog = new Form
            {
                Text = "Select Due Date",
                Width = 300,
                Height = 200,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent
            };
            
            DateTimePicker dtpDueDate = new DateTimePicker
            {
                Left = 20,
                Top = 30,
                Width = 240,
                MinDate = DateTime.Now,
                Value = DateTime.Now.AddDays(7)
            };
            
            Button btnDateOk = new Button { Text = "OK", Left = 100, Top = 80, Width = 80, DialogResult = DialogResult.OK };
            Button btnDateCancel = new Button { Text = "Cancel", Left = 190, Top = 80, Width = 70, DialogResult = DialogResult.Cancel };
            
            dateDialog.Controls.AddRange(new Control[] { new Label { Text = "Select Due Date:", Left = 20, Top = 10, Width = 240 }, dtpDueDate, btnDateOk, btnDateCancel });
            dateDialog.AcceptButton = btnDateOk;
            
            if (dateDialog.ShowDialog() == DialogResult.OK)
            {
                dueDate = dtpDueDate.Value;
            }
            else
            {
                return;
            }

            var newTask = new TaskItem
            {
                TaskId = DatabaseHelper.Tasks.Count + 1,
                SocietyId = society.SocietyId,
                AssignedTo = student.UserId,
                AssignedBy = SessionManagement.CurrentUserId,
                Title = title,
                Description = description,
                DueDate = dueDate,
                Status = "pending",
                Priority = priority
            };

            DatabaseHelper.AddTask(newTask);
            DatabaseHelper.LogActivity(SessionManagement.CurrentUserId, "TASK_ASSIGNED", $"Assigned task '{title}' to {student.FullName}");
            MessageBox.Show($"Task '{title}' assigned successfully to {student.FullName}!", "Success");
            LoadTasks();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTasks();
        }
    }
}