namespace SocietiesManagementSystem
{
    partial class TaskManagementForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView tasksToMeDataGridView;
        private System.Windows.Forms.DataGridView tasksByMeDataGridView;
        private System.Windows.Forms.Button btnAssignTask;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnViewComments;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblTasksToMe;
        private System.Windows.Forms.Label lblTasksByMe;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.tasksToMeDataGridView = new System.Windows.Forms.DataGridView();
            this.tasksByMeDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAssignTask = new System.Windows.Forms.Button();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnViewComments = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblTasksToMe = new System.Windows.Forms.Label();
            this.lblTasksByMe = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tasksToMeDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksByMeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTasksToMe
            // 
            this.lblTasksToMe.AutoSize = true;
            this.lblTasksToMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTasksToMe.Location = new System.Drawing.Point(12, 9);
            this.lblTasksToMe.Name = "lblTasksToMe";
            this.lblTasksToMe.Size = new System.Drawing.Size(144, 17);
            this.lblTasksToMe.TabIndex = 0;
            this.lblTasksToMe.Text = "Tasks Assigned To Me";
            // 
            // tasksToMeDataGridView
            // 
            this.tasksToMeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksToMeDataGridView.Location = new System.Drawing.Point(12, 30);
            this.tasksToMeDataGridView.Name = "tasksToMeDataGridView";
            this.tasksToMeDataGridView.Size = new System.Drawing.Size(450, 250);
            this.tasksToMeDataGridView.TabIndex = 1;
            this.tasksToMeDataGridView.ReadOnly = true;
            this.tasksToMeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // lblTasksByMe
            // 
            this.lblTasksByMe.AutoSize = true;
            this.lblTasksByMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.lblTasksByMe.Location = new System.Drawing.Point(480, 9);
            this.lblTasksByMe.Name = "lblTasksByMe";
            this.lblTasksByMe.Size = new System.Drawing.Size(120, 17);
            this.lblTasksByMe.TabIndex = 2;
            this.lblTasksByMe.Text = "Tasks I Assigned";
            // 
            // tasksByMeDataGridView
            // 
            this.tasksByMeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksByMeDataGridView.Location = new System.Drawing.Point(480, 30);
            this.tasksByMeDataGridView.Name = "tasksByMeDataGridView";
            this.tasksByMeDataGridView.Size = new System.Drawing.Size(450, 250);
            this.tasksByMeDataGridView.TabIndex = 3;
            this.tasksByMeDataGridView.ReadOnly = true;
            this.tasksByMeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(12, 290);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(140, 30);
            this.btnUpdateStatus.TabIndex = 4;
            this.btnUpdateStatus.Text = "Update Status";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnViewComments
            // 
            this.btnViewComments.Location = new System.Drawing.Point(160, 290);
            this.btnViewComments.Name = "btnViewComments";
            this.btnViewComments.Size = new System.Drawing.Size(140, 30);
            this.btnViewComments.TabIndex = 5;
            this.btnViewComments.Text = "View Comments";
            this.btnViewComments.UseVisualStyleBackColor = true;
            this.btnViewComments.Click += new System.EventHandler(this.btnViewComments_Click);
            // 
            // btnAssignTask
            // 
            this.btnAssignTask.Location = new System.Drawing.Point(480, 290);
            this.btnAssignTask.Name = "btnAssignTask";
            this.btnAssignTask.Size = new System.Drawing.Size(140, 30);
            this.btnAssignTask.TabIndex = 6;
            this.btnAssignTask.Text = "Assign New Task";
            this.btnAssignTask.UseVisualStyleBackColor = true;
            this.btnAssignTask.Click += new System.EventHandler(this.btnAssignTask_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(820, 290);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 30);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // TaskManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 340);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAssignTask);
            this.Controls.Add(this.btnViewComments);
            this.Controls.Add(this.btnUpdateStatus);
            this.Controls.Add(this.tasksByMeDataGridView);
            this.Controls.Add(this.lblTasksByMe);
            this.Controls.Add(this.tasksToMeDataGridView);
            this.Controls.Add(this.lblTasksToMe);
            this.Name = "TaskManagementForm";
            this.Text = "Task Management";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.tasksToMeDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksByMeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}