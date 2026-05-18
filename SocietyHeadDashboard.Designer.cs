namespace SocietiesManagementSystem
{
    partial class SocietyHeadDashboard
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtCategory;
        private System.Windows.Forms.DataGridView membershipRequestsDataGridView;
        private System.Windows.Forms.DataGridView eventsDataGridView;
        private System.Windows.Forms.DataGridView membersDataGridView;
        private System.Windows.Forms.DataGridView tasksDataGridView;
        private System.Windows.Forms.Button btnUpdateSociety;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnAssignTask;

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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.membershipRequestsDataGridView = new System.Windows.Forms.DataGridView();
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.membersDataGridView = new System.Windows.Forms.DataGridView();
            this.tasksDataGridView = new System.Windows.Forms.DataGridView();
            this.btnUpdateSociety = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnAssignTask = new System.Windows.Forms.Button();
            
            this.SuspendLayout();
            
            // lblWelcome
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(12, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(100, 24);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome";
            
            // txtName
            this.txtName.Location = new System.Drawing.Point(12, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 20);
            this.txtName.TabIndex = 1;
            
            // txtDescription
            this.txtDescription.Location = new System.Drawing.Point(12, 80);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 20);
            this.txtDescription.TabIndex = 2;
            
            // txtCategory
            this.txtCategory.Location = new System.Drawing.Point(12, 110);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(200, 20);
            this.txtCategory.TabIndex = 3;
            
            // btnUpdateSociety
            this.btnUpdateSociety.Location = new System.Drawing.Point(12, 140);
            this.btnUpdateSociety.Name = "btnUpdateSociety";
            this.btnUpdateSociety.Size = new System.Drawing.Size(200, 30);
            this.btnUpdateSociety.TabIndex = 4;
            this.btnUpdateSociety.Text = "Update Society Profile";
            this.btnUpdateSociety.UseVisualStyleBackColor = true;
            this.btnUpdateSociety.Click += new System.EventHandler(this.btnUpdateSociety_Click);
            
            // membershipRequestsDataGridView
            this.membershipRequestsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membershipRequestsDataGridView.Location = new System.Drawing.Point(230, 50);
            this.membershipRequestsDataGridView.Name = "membershipRequestsDataGridView";
            this.membershipRequestsDataGridView.Size = new System.Drawing.Size(300, 150);
            this.membershipRequestsDataGridView.TabIndex = 5;
            
            // btnApprove
            this.btnApprove.Location = new System.Drawing.Point(230, 210);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(140, 30);
            this.btnApprove.TabIndex = 6;
            this.btnApprove.Text = "Approve Request";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            
            // btnReject
            this.btnReject.Location = new System.Drawing.Point(390, 210);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(140, 30);
            this.btnReject.TabIndex = 7;
            this.btnReject.Text = "Reject Request";
            this.btnReject.UseVisualStyleBackColor = true;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            
            // eventsDataGridView
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsDataGridView.Location = new System.Drawing.Point(550, 50);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.Size = new System.Drawing.Size(300, 150);
            this.eventsDataGridView.TabIndex = 8;
            
            // btnAddEvent
            this.btnAddEvent.Location = new System.Drawing.Point(550, 210);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(300, 30);
            this.btnAddEvent.TabIndex = 9;
            this.btnAddEvent.Text = "Add New Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            
            // membersDataGridView
            this.membersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.membersDataGridView.Location = new System.Drawing.Point(12, 260);
            this.membersDataGridView.Name = "membersDataGridView";
            this.membersDataGridView.Size = new System.Drawing.Size(400, 150);
            this.membersDataGridView.TabIndex = 10;
            
            // tasksDataGridView
            this.tasksDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tasksDataGridView.Location = new System.Drawing.Point(450, 260);
            this.tasksDataGridView.Name = "tasksDataGridView";
            this.tasksDataGridView.Size = new System.Drawing.Size(400, 150);
            this.tasksDataGridView.TabIndex = 11;
            
            // btnAssignTask
            this.btnAssignTask.Location = new System.Drawing.Point(450, 420);
            this.btnAssignTask.Name = "btnAssignTask";
            this.btnAssignTask.Size = new System.Drawing.Size(400, 30);
            this.btnAssignTask.TabIndex = 12;
            this.btnAssignTask.Text = "Assign New Task";
            this.btnAssignTask.UseVisualStyleBackColor = true;
            this.btnAssignTask.Click += new System.EventHandler(this.btnAssignTask_Click);
            
            // SocietyHeadDashboard
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 500);
            this.Controls.Add(this.btnAssignTask);
            this.Controls.Add(this.tasksDataGridView);
            this.Controls.Add(this.membersDataGridView);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.eventsDataGridView);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.membershipRequestsDataGridView);
            this.Controls.Add(this.btnUpdateSociety);
            this.Controls.Add(this.txtCategory);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblWelcome);
            this.Name = "SocietyHeadDashboard";
            this.Text = "Society Head Dashboard";
            this.Load += new System.EventHandler(this.SocietyHeadDashboard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}