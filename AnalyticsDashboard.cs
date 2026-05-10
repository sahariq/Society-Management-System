using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SocietiesManagementSystem
{
    public partial class AnalyticsDashboard : Form
    {
        private System.Windows.Forms.Timer timer1;   // Explicitly use Windows.Forms.Timer

        public AnalyticsDashboard()
        {
            InitializeComponent();

            // Auto-refresh timer
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 30000; // 30 seconds
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            LoadCharts();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void LoadCharts()
        {
            // Pie Chart: Membership distribution
            string q1 = @"SELECT s.name, COUNT(sm.membership_id) as Members 
                         FROM Societies s 
                         JOIN SocietyMemberships sm ON s.society_id = sm.society_id 
                         WHERE sm.status='active' 
                         GROUP BY s.name";
            
            DataTable dt1 = DatabaseHelper.ExecuteQuery(q1);
            chartPie.Series[0].Points.Clear();
            foreach (DataRow row in dt1.Rows)
                chartPie.Series[0].Points.AddXY(row["name"], row["Members"]);

            // Bar Chart & Line Chart can be added similarly later
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCharts();
        }

        private void btnExportImage_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "PNG Image|*.png";
                sfd.Title = "Save Chart Image";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    chartPie.SaveImage(sfd.FileName, ChartImageFormat.Png);
                    MessageBox.Show("Chart saved successfully!", "Success");
                }
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", 
                                "Logout", 
                                MessageBoxButtons.YesNo, 
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
                new Form1().Show();
            }
        }
    }
}