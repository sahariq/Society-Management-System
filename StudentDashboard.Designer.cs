namespace SocietiesManagementSystem
{
    partial class StudentDashboard
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
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabBrowseSocieties = new System.Windows.Forms.TabPage();
            this.btnJoinSociety = new System.Windows.Forms.Button();
            this.txtSocietySearch = new System.Windows.Forms.TextBox();
            this.labelSocietySearch = new System.Windows.Forms.Label();
            this.societiesDataGridView = new System.Windows.Forms.DataGridView();
            this.tabEvents = new System.Windows.Forms.TabPage();
            this.btnRegisterEvent = new System.Windows.Forms.Button();
            this.txtEventSearch = new System.Windows.Forms.TextBox();
            this.labelEventSearch = new System.Windows.Forms.Label();
            this.eventsDataGridView = new System.Windows.Forms.DataGridView();
            this.tabMyRegistrations = new System.Windows.Forms.TabPage();
            this.btnLeaveSociety = new System.Windows.Forms.Button();
            this.btnCancelRegistration = new System.Windows.Forms.Button();
            this.myRegistrationsDataGridView = new System.Windows.Forms.DataGridView();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();

            // Logout Button
            this.btnLogout.Location = new System.Drawing.Point(1050, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(110, 38);
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.lblWelcome.Text = "Welcome, Student";

            this.Controls.Add(this.btnLogout);

            this.tabControlMain.SuspendLayout();
            this.tabBrowseSocieties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.societiesDataGridView)).BeginInit();
            this.tabEvents.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).BeginInit();
            this.tabMyRegistrations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.myRegistrationsDataGridView)).BeginInit();
            this.SuspendLayout();

            // tabControlMain
            this.tabControlMain.Controls.Add(this.tabBrowseSocieties);
            this.tabControlMain.Controls.Add(this.tabEvents);
            this.tabControlMain.Controls.Add(this.tabMyRegistrations);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1200, 700);
            this.tabControlMain.TabIndex = 0;

            // lblWelcome
            this.lblWelcome.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(0, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(1200, 50);
            this.lblWelcome.TabIndex = 99;
            this.lblWelcome.Text = "Welcome, Student";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Tab 1: Browse Societies
            this.tabBrowseSocieties.Controls.Add(this.btnJoinSociety);
            this.tabBrowseSocieties.Controls.Add(this.txtSocietySearch);
            this.tabBrowseSocieties.Controls.Add(this.labelSocietySearch);
            this.tabBrowseSocieties.Controls.Add(this.societiesDataGridView);
            this.tabBrowseSocieties.Location = new System.Drawing.Point(4, 25);
            this.tabBrowseSocieties.Name = "tabBrowseSocieties";
            this.tabBrowseSocieties.Padding = new System.Windows.Forms.Padding(3);
            this.tabBrowseSocieties.Size = new System.Drawing.Size(1192, 621);
            this.tabBrowseSocieties.TabIndex = 0;
            this.tabBrowseSocieties.Text = "Browse Societies";

            this.societiesDataGridView.Location = new System.Drawing.Point(12, 80);
            this.societiesDataGridView.Name = "societiesDataGridView";
            this.societiesDataGridView.Size = new System.Drawing.Size(1168, 530);
            this.societiesDataGridView.TabIndex = 0;

            this.txtSocietySearch.Location = new System.Drawing.Point(920, 48);
            this.txtSocietySearch.Name = "txtSocietySearch";
            this.txtSocietySearch.Size = new System.Drawing.Size(260, 23);
            this.txtSocietySearch.TabIndex = 1;

            this.labelSocietySearch.AutoSize = true;
            this.labelSocietySearch.Location = new System.Drawing.Point(12, 51);
            this.labelSocietySearch.Name = "labelSocietySearch";
            this.labelSocietySearch.Size = new System.Drawing.Size(85, 15);
            this.labelSocietySearch.TabIndex = 2;
            this.labelSocietySearch.Text = "Search Societies:";

            this.btnJoinSociety.Location = new System.Drawing.Point(12, 45);
            this.btnJoinSociety.Name = "btnJoinSociety";
            this.btnJoinSociety.Size = new System.Drawing.Size(140, 35);
            this.btnJoinSociety.TabIndex = 3;
            this.btnJoinSociety.Text = "Join Society";
            this.btnJoinSociety.UseVisualStyleBackColor = true;

            // Tab 2: Events
            this.tabEvents.Controls.Add(this.btnRegisterEvent);
            this.tabEvents.Controls.Add(this.txtEventSearch);
            this.tabEvents.Controls.Add(this.labelEventSearch);
            this.tabEvents.Controls.Add(this.eventsDataGridView);
            this.tabEvents.Location = new System.Drawing.Point(4, 25);
            this.tabEvents.Name = "tabEvents";
            this.tabEvents.Size = new System.Drawing.Size(1192, 621);
            this.tabEvents.TabIndex = 1;
            this.tabEvents.Text = "Upcoming Events";

            this.eventsDataGridView.Location = new System.Drawing.Point(12, 80);
            this.eventsDataGridView.Name = "eventsDataGridView";
            this.eventsDataGridView.Size = new System.Drawing.Size(1168, 530);
            this.eventsDataGridView.TabIndex = 0;

            this.txtEventSearch.Location = new System.Drawing.Point(920, 48);
            this.txtEventSearch.Name = "txtEventSearch";
            this.txtEventSearch.Size = new System.Drawing.Size(260, 23);
            this.txtEventSearch.TabIndex = 1;

            this.labelEventSearch.AutoSize = true;
            this.labelEventSearch.Location = new System.Drawing.Point(12, 51);
            this.labelEventSearch.Name = "labelEventSearch";
            this.labelEventSearch.Size = new System.Drawing.Size(75, 15);
            this.labelEventSearch.TabIndex = 2;
            this.labelEventSearch.Text = "Search Events:";

            this.btnRegisterEvent.Location = new System.Drawing.Point(12, 45);
            this.btnRegisterEvent.Name = "btnRegisterEvent";
            this.btnRegisterEvent.Size = new System.Drawing.Size(160, 35);
            this.btnRegisterEvent.TabIndex = 3;
            this.btnRegisterEvent.Text = "Register for Event";
            this.btnRegisterEvent.UseVisualStyleBackColor = true;

            // Tab 3: My Registrations / My Societies
            this.tabMyRegistrations.Controls.Add(this.btnLeaveSociety);
            this.tabMyRegistrations.Controls.Add(this.btnCancelRegistration);
            this.tabMyRegistrations.Controls.Add(this.myRegistrationsDataGridView);
            this.tabMyRegistrations.Location = new System.Drawing.Point(4, 25);
            this.tabMyRegistrations.Name = "tabMyRegistrations";
            this.tabMyRegistrations.Size = new System.Drawing.Size(1192, 621);
            this.tabMyRegistrations.TabIndex = 2;
            this.tabMyRegistrations.Text = "My Societies & Registrations";

            this.myRegistrationsDataGridView.Location = new System.Drawing.Point(12, 70);
            this.myRegistrationsDataGridView.Name = "myRegistrationsDataGridView";
            this.myRegistrationsDataGridView.Size = new System.Drawing.Size(1168, 540);
            this.myRegistrationsDataGridView.TabIndex = 0;

            this.btnLeaveSociety.Location = new System.Drawing.Point(12, 30);
            this.btnLeaveSociety.Name = "btnLeaveSociety";
            this.btnLeaveSociety.Size = new System.Drawing.Size(160, 35);
            this.btnLeaveSociety.TabIndex = 1;
            this.btnLeaveSociety.Text = "Leave Society";
            this.btnLeaveSociety.UseVisualStyleBackColor = true;

            this.btnCancelRegistration.Location = new System.Drawing.Point(190, 30);
            this.btnCancelRegistration.Name = "btnCancelRegistration";
            this.btnCancelRegistration.Size = new System.Drawing.Size(180, 35);
            this.btnCancelRegistration.TabIndex = 2;
            this.btnCancelRegistration.Text = "Cancel Event Registration";
            this.btnCancelRegistration.UseVisualStyleBackColor = true;

            // StudentDashboard
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.Controls.Add(this.tabControlMain);
            this.Controls.Add(this.lblWelcome);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "StudentDashboard";
            this.Text = "Student Dashboard - Societies Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            this.tabControlMain.ResumeLayout(false);
            this.tabBrowseSocieties.ResumeLayout(false);
            this.tabBrowseSocieties.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.societiesDataGridView)).EndInit();
            this.tabEvents.ResumeLayout(false);
            this.tabEvents.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventsDataGridView)).EndInit();
            this.tabMyRegistrations.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.myRegistrationsDataGridView)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabBrowseSocieties;
        private System.Windows.Forms.TabPage tabEvents;
        private System.Windows.Forms.TabPage tabMyRegistrations;

        public System.Windows.Forms.DataGridView societiesDataGridView;
        public System.Windows.Forms.DataGridView eventsDataGridView;
        public System.Windows.Forms.DataGridView myRegistrationsDataGridView;

        private System.Windows.Forms.Button btnJoinSociety;
        private System.Windows.Forms.Button btnRegisterEvent;
        private System.Windows.Forms.Button btnLeaveSociety;
        private System.Windows.Forms.Button btnCancelRegistration;

        private System.Windows.Forms.TextBox txtSocietySearch;
        private System.Windows.Forms.TextBox txtEventSearch;
        private System.Windows.Forms.Label labelSocietySearch;
        private System.Windows.Forms.Label labelEventSearch;

        private System.Windows.Forms.Label lblWelcome;

        public System.Windows.Forms.Button btnLogout;
    }
}