namespace SocietiesManagementSystem
{
    partial class TaskManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private void InitializeComponent()
        {
            this.tasksToMeDataGridView = new System.Windows.Forms.DataGridView();
            this.tasksByMeDataGridView = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // tasksToMeDataGridView
            this.tasksToMeDataGridView.Location = new System.Drawing.Point(20, 20);
            this.tasksToMeDataGridView.Name = "tasksToMeDataGridView";
            this.tasksToMeDataGridView.Size = new System.Drawing.Size(400, 300);
            this.tasksToMeDataGridView.TabIndex = 0;
            // tasksByMeDataGridView
            this.tasksByMeDataGridView.Location = new System.Drawing.Point(450, 20);
            this.tasksByMeDataGridView.Name = "tasksByMeDataGridView";
            this.tasksByMeDataGridView.Size = new System.Drawing.Size(400, 300);
            this.tasksByMeDataGridView.TabIndex = 1;
            // TaskManagementForm
            this.ClientSize = new System.Drawing.Size(900, 350);
            this.Controls.Add(this.tasksToMeDataGridView);
            this.Controls.Add(this.tasksByMeDataGridView);
            this.Name = "TaskManagementForm";
            this.Text = "Task Management";
            this.ResumeLayout(false);
        }
        public System.Windows.Forms.DataGridView tasksToMeDataGridView;
        public System.Windows.Forms.DataGridView tasksByMeDataGridView;
    }
}
