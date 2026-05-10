namespace SocietiesManagementSystem
{
    partial class SocietyHeadDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabMembershipRequests = new System.Windows.Forms.TabPage();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.tabTasks = new System.Windows.Forms.TabPage();

            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();

            // Profile Tab Controls
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtCategory = new System.Windows.Forms.TextBox();
            this.btnUpdateSociety = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelCategory = new System.Windows.Forms.Label();

            // Membership Requests Tab
            this.membershipRequestsDataGridView = new System.Windows.Forms.DataGridView();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();

            // Events Tab
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnEditEvent = new System.Windows.Forms.Button();
            this.btnDeleteEvent = new System.Windows.Forms.Button();

            // Members Tab
            this.membersDataGridView = new System.Windows.Forms.DataGridView();
            this.btnRemoveMember = new System.Windows.Forms.Button();
            this.btnChangeRole = new System.Windows.Forms.Button();
            this.roleComboBox = new System.Windows.Forms.ComboBox();

            // Tasks Tab
            this.tasksDataGridView = new System.Windows.Forms.DataGridView();
            this.btnAssignTask = new System.Windows.Forms.Button();

            this.tabControlMain.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabMembershipRequests.SuspendLayout();
            this.tabEvents.SuspendLayout();
            this.tabMembers.SuspendLayout();
            this.tabTasks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membershipRequestsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tasksDataGridView)).BeginInit();
            this.SuspendLayout();

            // lblWelcome
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(1200, 50);
            this.lblWelcome.TabIndex = 99;
            this.lblWelcome.Text = "Society Head Dashboard";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Logout Button (Top Right)
            this.btnLogout.Location = new System.Drawing.Point(1050, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 38);
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabProfile);
            this.tabControlMain.Controls.Add(this.tabMembershipRequests);
            this.tabControlMain.Controls.Add(this.tabEvents);
            this.tabControlMain.Controls.Add(this.tabMembers);
            this.tabControlMain.Controls.Add(this.tabTasks);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 50);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.Size = new System.Drawing.Size(1200, 650);
            this.tabControlMain.TabIndex = 0;

            // Profile Tab
            this.tabProfile.Controls.Add(this.btnUpdateSociety);
            this.tabProfile.Controls.Add(this.labelName);
            this.tabProfile.Controls.Add(this.labelDescription);
            this.tabProfile.Controls.Add(this.labelCategory);
            this.tabProfile.Controls.Add(this.txtName);
            this.tabProfile.Controls.Add(this.txtDescription);
            this.tabProfile.Controls.Add(this.txtCategory);
            this.tabProfile.Text = "Society Profile";

            // ... (I kept your existing layout for tabs to avoid breaking it) ...

            // Form Settings
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.tabControlMain);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "SocietyHeadDashboard";
            this.Text = "Society Head Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Controls
        public System.Windows.Forms.Button btnLogout;
        public System.Windows.Forms.Label lblWelcome;

        public System.Windows.Forms.TextBox txtName;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtCategory;

        public System.Windows.Forms.DataGridView membershipRequestsDataGridView;
        public System.Windows.Forms.DataGridView eventsDataGridView;
        public System.Windows.Forms.DataGridView membersDataGridView;
        public System.Windows.Forms.DataGridView tasksDataGridView;

        public System.Windows.Forms.Button btnUpdateSociety;
        public System.Windows.Forms.Button btnApprove;
        public System.Windows.Forms.Button btnReject;
        public System.Windows.Forms.Button btnAddEvent;
        public System.Windows.Forms.Button btnEditEvent;
        public System.Windows.Forms.Button btnDeleteEvent;
        public System.Windows.Forms.Button btnRemoveMember;
        public System.Windows.Forms.Button btnChangeRole;
        public System.Windows.Forms.Button btnAssignTask;

        public System.Windows.Forms.ComboBox roleComboBox;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabMembershipRequests;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabMembers;
        private System.Windows.Forms.TabPage tabTasks;

        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelDescription;
        public System.Windows.Forms.Label labelCategory;
    }
}