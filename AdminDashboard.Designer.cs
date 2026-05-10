namespace SocietiesManagementSystem
{
    partial class AdminDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabUsers = new System.Windows.Forms.TabPage();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.btnActivateUser = new System.Windows.Forms.Button();
            this.btnSuspendUser = new System.Windows.Forms.Button();
            this.txtUserSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usersDataGridView = new System.Windows.Forms.DataGridView();
            this.tabSocieties = new System.Windows.Forms.TabPage();
            this.btnApproveSociety = new System.Windows.Forms.Button();
            this.societiesDataGridView = new System.Windows.Forms.DataGridView();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.btnApproveEvent = new System.Windows.Forms.Button();
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabActivity = new System.Windows.Forms.TabPage();
            this.activityLogDataGridView = new System.Windows.Forms.DataGridView();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.btnRefreshReports = new System.Windows.Forms.Button();
            this.labelReports = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblUserInfo = new System.Windows.Forms.Label();

            // Logout Button (Top Right)
            this.btnLogout.Location = new System.Drawing.Point(1050, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 38);
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Optional: Show current user
            this.lblUserInfo.AutoSize = true;
            this.lblUserInfo.Location = new System.Drawing.Point(850, 22);
            this.lblUserInfo.Name = "lblUserInfo";
            this.lblUserInfo.Text = "Logged in as Admin";
            this.lblUserInfo.ForeColor = System.Drawing.Color.DimGray;

            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblUserInfo);

            this.tabControlMain.SuspendLayout();
            this.tabUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).BeginInit();
            this.tabSocieties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.societiesDataGridView)).BeginInit();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.tabActivity.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.activityLogDataGridView)).BeginInit();
            this.tabReports.SuspendLayout();
            this.SuspendLayout();

            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabUsers);
            this.tabControlMain.Controls.Add(this.tabSocieties);
            this.tabControlMain.Controls.Add(this.tabEvents);
            this.tabControlMain.Controls.Add(this.tabActivity);
            this.tabControlMain.Controls.Add(this.tabReports);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1200, 700);
            this.tabControlMain.TabIndex = 0;

            // 
            // tabUsers
            // 
            this.tabUsers.Controls.Add(this.btnResetPassword);
            this.tabUsers.Controls.Add(this.btnActivateUser);
            this.tabUsers.Controls.Add(this.btnSuspendUser);
            this.tabUsers.Controls.Add(this.txtUserSearch);
            this.tabUsers.Controls.Add(this.label1);
            this.tabUsers.Controls.Add(this.usersDataGridView);
            this.tabUsers.Location = new System.Drawing.Point(4, 25);
            this.tabUsers.Name = "tabUsers";
            this.tabUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsers.Size = new System.Drawing.Size(1192, 671);
            this.tabUsers.TabIndex = 0;
            this.tabUsers.Text = "User Management";

            // 
            // usersDataGridView
            // 
            this.usersDataGridView.AllowUserToAddRows = false;
            this.usersDataGridView.AllowUserToDeleteRows = false;
            this.usersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.usersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.usersDataGridView.Location = new System.Drawing.Point(12, 80);
            this.usersDataGridView.Name = "usersDataGridView";
            this.usersDataGridView.ReadOnly = true;
            this.usersDataGridView.RowHeadersWidth = 51;
            this.usersDataGridView.RowTemplate.Height = 24;
            this.usersDataGridView.Size = new System.Drawing.Size(1168, 580);
            this.usersDataGridView.TabIndex = 0;

            // 
            // txtUserSearch
            // 
            this.txtUserSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserSearch.Location = new System.Drawing.Point(950, 45);
            this.txtUserSearch.Name = "txtUserSearch";
            this.txtUserSearch.Size = new System.Drawing.Size(230, 23);
            this.txtUserSearch.TabIndex = 1;
            this.txtUserSearch.TextChanged += new System.EventHandler(this.txtUserSearch_TextChanged);

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search User:";

            // Buttons User Tab
            this.btnSuspendUser.Location = new System.Drawing.Point(12, 12);
            this.btnSuspendUser.Name = "btnSuspendUser";
            this.btnSuspendUser.Size = new System.Drawing.Size(140, 35);
            this.btnSuspendUser.TabIndex = 3;
            this.btnSuspendUser.Text = "Suspend User";
            this.btnSuspendUser.UseVisualStyleBackColor = true;
            this.btnSuspendUser.Click += new System.EventHandler(this.btnSuspendUser_Click);

            this.btnActivateUser.Location = new System.Drawing.Point(160, 12);
            this.btnActivateUser.Name = "btnActivateUser";
            this.btnActivateUser.Size = new System.Drawing.Size(140, 35);
            this.btnActivateUser.TabIndex = 4;
            this.btnActivateUser.Text = "Activate User";
            this.btnActivateUser.UseVisualStyleBackColor = true;
            this.btnActivateUser.Click += new System.EventHandler(this.btnActivateUser_Click);

            this.btnResetPassword.Location = new System.Drawing.Point(310, 12);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(160, 35);
            this.btnResetPassword.TabIndex = 5;
            this.btnResetPassword.Text = "Reset Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);

            // tabSocieties
            this.tabSocieties.Controls.Add(this.btnApproveSociety);
            this.tabSocieties.Controls.Add(this.societiesDataGridView);
            this.tabSocieties.Location = new System.Drawing.Point(4, 25);
            this.tabSocieties.Name = "tabSocieties";
            this.tabSocieties.Size = new System.Drawing.Size(1192, 671);
            this.tabSocieties.TabIndex = 1;
            this.tabSocieties.Text = "Society Management";

            this.societiesDataGridView.AllowUserToAddRows = false;
            this.societiesDataGridView.AllowUserToDeleteRows = false;
            this.societiesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.societiesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.societiesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.societiesDataGridView.Location = new System.Drawing.Point(12, 60);
            this.societiesDataGridView.Name = "societiesDataGridView";
            this.societiesDataGridView.ReadOnly = true;
            this.societiesDataGridView.RowHeadersWidth = 51;
            this.societiesDataGridView.RowTemplate.Height = 24;
            this.societiesDataGridView.Size = new System.Drawing.Size(1168, 600);
            this.societiesDataGridView.TabIndex = 0;

            this.btnApproveSociety.Location = new System.Drawing.Point(12, 20);
            this.btnApproveSociety.Name = "btnApproveSociety";
            this.btnApproveSociety.Size = new System.Drawing.Size(160, 35);
            this.btnApproveSociety.TabIndex = 1;
            this.btnApproveSociety.Text = "Approve Society";
            this.btnApproveSociety.Click += new System.EventHandler(this.btnApproveSociety_Click);

            // tabEvents
            this.tabEvents.Controls.Add(this.btnApproveEvent);
            this.tabEvents.Controls.Add(this.eventsDataGridView);
            this.tabEvents.Location = new System.Drawing.Point(4, 25);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(1192, 671);
            this.tabEvents.TabIndex = 2;
            this.tabEvents.Text = "Event Approval";

            this.eventsDataGridView.AllowUserToAddRows = false;
            this.eventsDataGridView.AllowUserToDeleteRows = false;
            this.eventsDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.eventsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.eventsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eventsDataGridView.Location = new System.Drawing.Point(12, 60);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.ReadOnly = true;
            this.eventsDataGridView.RowHeadersWidth = 51;
            this.eventsDataGridView.RowTemplate.Height = 24;
            this.eventsDataGridView.Size = new System.Drawing.Size(1168, 600);
            this.eventsDataGridView.TabIndex = 0;

            this.btnApproveEvent.Location = new System.Drawing.Point(12, 20);
            this.btnApproveEvent.Name = "btnApproveEvent";
            this.btnApproveEvent.Size = new System.Drawing.Size(160, 35);
            this.btnApproveEvent.TabIndex = 1;
            this.btnApproveEvent.Text = "Approve Event";
            this.btnApproveEvent.Click += new System.EventHandler(this.btnApproveEvent_Click);

            // tabActivity
            this.tabActivity.Controls.Add(this.activityLogDataGridView);
            this.tabActivity.Location = new System.Drawing.Point(4, 25);
            this.tabActivity.Name = "tabActivity";
            this.tabActivity.Size = new System.Drawing.Size(1192, 671);
            this.tabActivity.TabIndex = 3;
            this.tabActivity.Text = "Activity Logs";

            this.activityLogDataGridView.AllowUserToAddRows = false;
            this.activityLogDataGridView.AllowUserToDeleteRows = false;
            this.activityLogDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.activityLogDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.activityLogDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.activityLogDataGridView.Location = new System.Drawing.Point(12, 12);
            this.activityLogDataGridView.Name = "activityLogDataGridView";
            this.activityLogDataGridView.ReadOnly = true;
            this.activityLogDataGridView.RowHeadersWidth = 51;
            this.activityLogDataGridView.RowTemplate.Height = 24;
            this.activityLogDataGridView.Size = new System.Drawing.Size(1168, 640);
            this.activityLogDataGridView.TabIndex = 0;

            // tabReports
            this.tabReports.Controls.Add(this.btnRefreshReports);
            this.tabReports.Controls.Add(this.labelReports);
            this.tabReports.Location = new System.Drawing.Point(4, 25);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(1192, 671);
            this.tabReports.TabIndex = 4;
            this.tabReports.Text = "University Reports";

            this.labelReports.AutoSize = true;
            this.labelReports.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.labelReports.Location = new System.Drawing.Point(20, 20);
            this.labelReports.Name = "labelReports";
            this.labelReports.Size = new System.Drawing.Size(300, 25);
            this.labelReports.TabIndex = 0;
            this.labelReports.Text = "Reports & Analytics will appear here";

            this.btnRefreshReports.Location = new System.Drawing.Point(12, 60);
            this.btnRefreshReports.Name = "btnRefreshReports";
            this.btnRefreshReports.Size = new System.Drawing.Size(140, 35);
            this.btnRefreshReports.TabIndex = 1;
            this.btnRefreshReports.Text = "Refresh Reports";

            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "AdminDashboard";
            this.Text = "Admin Dashboard - Societies Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tabControlMain.ResumeLayout(false);
            this.tabUsers.ResumeLayout(false);
            this.tabUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersDataGridView)).EndInit();
            this.tabSocieties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.societiesDataGridView)).EndInit();
            this.tabEvents.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.tabActivity.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.activityLogDataGridView)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabSocieties;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.TabPage tabReports;

        public System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.Label lblUserInfo;

        public System.Windows.Forms.DataGridView usersDataGridView;
        public System.Windows.Forms.DataGridView societiesDataGridView;
        public System.Windows.Forms.DataGridView eventsDataGridView;
        public System.Windows.Forms.DataGridView activityLogDataGridView;

        public System.Windows.Forms.Button btnSuspendUser;
        public System.Windows.Forms.Button btnActivateUser;
        public System.Windows.Forms.Button btnResetPassword;
        public System.Windows.Forms.TextBox txtUserSearch;
        public System.Windows.Forms.Label label1;

        public System.Windows.Forms.Button btnApproveSociety;
        public System.Windows.Forms.Button btnApproveEvent;

        public System.Windows.Forms.Button btnRefreshReports;
        public System.Windows.Forms.Label labelReports;

        // You can add more controls later (e.g., charts in Reports tab)
    }
}