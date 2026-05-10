namespace SocietiesManagementSystem
{
    partial class AnalyticsDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            this.lblTitle = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExportImage = new System.Windows.Forms.Button();

            this.chartPie = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartBar = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartLine = new System.Windows.Forms.DataVisualization.Charting.Chart();

            this.btnLogout = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).BeginInit();
            this.SuspendLayout();

            // Title
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1200, 60);
            this.lblTitle.Text = "Analytics Dashboard";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Buttons
            this.btnRefresh.Location = new System.Drawing.Point(30, 70);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(140, 40);
            this.btnRefresh.Text = "Refresh Charts";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            this.btnExportImage.Location = new System.Drawing.Point(190, 70);
            this.btnExportImage.Name = "btnExportImage";
            this.btnExportImage.Size = new System.Drawing.Size(160, 40);
            this.btnExportImage.Text = "Export Pie Chart";
            this.btnExportImage.Click += new System.EventHandler(this.btnExportImage_Click);

            // Logout Button (Top Right)
            this.btnLogout.Location = new System.Drawing.Point(1050, 15);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(120, 38);
            this.btnLogout.Text = "Logout";
            this.btnLogout.BackColor = System.Drawing.Color.IndianRed;
            this.btnLogout.ForeColor = System.Drawing.Color.White;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // Charts
            this.chartPie.Location = new System.Drawing.Point(30, 130);
            this.chartPie.Name = "chartPie";
            this.chartPie.Size = new System.Drawing.Size(500, 380);

            this.chartBar.Location = new System.Drawing.Point(650, 130);
            this.chartBar.Name = "chartBar";
            this.chartBar.Size = new System.Drawing.Size(500, 380);

            this.chartLine.Location = new System.Drawing.Point(30, 530);
            this.chartLine.Name = "chartLine";
            this.chartLine.Size = new System.Drawing.Size(1120, 280);

            // Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(1200, 820);
            this.Controls.Add(this.chartLine);
            this.Controls.Add(this.chartBar);
            this.Controls.Add(this.chartPie);
            this.Controls.Add(this.btnExportImage);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.lblTitle);
            this.MinimumSize = new System.Drawing.Size(1100, 700);
            this.Name = "AnalyticsDashboard";
            this.Text = "Analytics Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

            ((System.ComponentModel.ISupportInitialize)(this.chartPie)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartLine)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.DataVisualization.Charting.Chart chartPie;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartBar;
        public System.Windows.Forms.DataVisualization.Charting.Chart chartLine;

        private System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Button btnRefresh;
        public System.Windows.Forms.Button btnExportImage;
        public System.Windows.Forms.Button btnLogout;
    }
}