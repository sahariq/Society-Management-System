using Microsoft.Data.Sqlite;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;

namespace SocietiesManagementSystem
{
    public partial class ReportForm : Form
    {
        private string userRole;
        
        public ReportForm()
        {
            InitializeComponent();
            userRole = SessionManagement.CurrentRole;
            LoadReportOptions();
        }
        
        private void InitializeComponent()
        {
            this.cmbReportType = new ComboBox();
            this.dgvReport = new DataGridView();
            this.btnGenerate = new Button();
            this.btnExport = new Button();
            this.btnExportPDF = new Button();
            this.dtpStartDate = new DateTimePicker();
            this.dtpEndDate = new DateTimePicker();
            this.lblStartDate = new Label();
            this.lblEndDate = new Label();
            this.chkShowChart = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)this.dgvReport).BeginInit();
            this.SuspendLayout();
            
            // cmbReportType
            this.cmbReportType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbReportType.Location = new Point(12, 12);
            this.cmbReportType.Size = new Size(200, 23);
            
            // lblStartDate
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new Point(230, 15);
            this.lblStartDate.Text = "From:";
            
            // dtpStartDate
            this.dtpStartDate.Location = new Point(275, 12);
            this.dtpStartDate.Size = new Size(150, 23);
            this.dtpStartDate.Format = DateTimePickerFormat.Short;
            
            // lblEndDate
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new Point(440, 15);
            this.lblEndDate.Text = "To:";
            
            // dtpEndDate
            this.dtpEndDate.Location = new Point(475, 12);
            this.dtpEndDate.Size = new Size(150, 23);
            this.dtpEndDate.Format = DateTimePickerFormat.Short;
            
            // btnGenerate
            this.btnGenerate.Location = new Point(640, 12);
            this.btnGenerate.Size = new Size(100, 23);
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.Click += btnGenerate_Click;
            
            // btnExport
            this.btnExport.Location = new Point(750, 12);
            this.btnExport.Size = new Size(100, 23);
            this.btnExport.Text = "Export Excel";
            this.btnExport.Click += btnExport_Click;
            
            // btnExportPDF
            this.btnExportPDF.Location = new Point(860, 12);
            this.btnExportPDF.Size = new Size(100, 23);
            this.btnExportPDF.Text = "Export PDF";
            this.btnExportPDF.Click += btnExportPDF_Click;
            
            // chkShowChart
            this.chkShowChart.AutoSize = true;
            this.chkShowChart.Location = new Point(970, 15);
            this.chkShowChart.Text = "Show Chart";
            this.chkShowChart.CheckedChanged += chkShowChart_CheckedChanged;
            
            // dgvReport
            this.dgvReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dgvReport.Location = new Point(12, 50);
            this.dgvReport.Size = new Size(1060, 400);
            this.dgvReport.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            // ReportForm
            this.Text = "Reports Dashboard";
            this.Size = new Size(1100, 500);
            this.Controls.AddRange(new Control[] { cmbReportType, lblStartDate, dtpStartDate, 
                lblEndDate, dtpEndDate, btnGenerate, btnExport, btnExportPDF, chkShowChart, dgvReport });
            ((System.ComponentModel.ISupportInitialize)this.dgvReport).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
        
        private ComboBox cmbReportType;
        private DataGridView dgvReport;
        private Button btnGenerate;
        private Button btnExport;
        private Button btnExportPDF;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private Label lblStartDate;
        private Label lblEndDate;
        private CheckBox chkShowChart;
        
        private void LoadReportOptions()
        {
            cmbReportType.Items.Clear();
            
            if (userRole == "admin")
            {
                cmbReportType.Items.AddRange(new[] {
                    "University-wide Membership Trends",
                    "University-wide Event Participation",
                    "Society Performance Report",
                    "Activity Summary",
                    "Most Active Societies"
                });
            }
            else if (userRole == "society_head")
            {
                cmbReportType.Items.AddRange(new[] {
                    "My Society Membership Trends",
                    "My Society Event Participation",
                    "My Society Task Completion Report",
                    "My Society Activity Summary"
                });
            }
            
            cmbReportType.SelectedIndex = 0;
            
            // Set default date range (last 30 days)
            dtpEndDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now.AddDays(-30);
        }
        
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string reportType = cmbReportType.SelectedItem?.ToString() ?? "";
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            
            DataTable dt = GenerateReport(reportType, startDate, endDate);
            dgvReport.DataSource = dt;
            
            DatabaseHelper.LogActivity(SessionManagement.CurrentUserId, "REPORT_GENERATED", 
                $"Generated {reportType} report from {startDate:yyyy-MM-dd} to {endDate:yyyy-MM-dd}");
            
            if (chkShowChart.Checked)
            {
                ShowChart(dt, reportType);
            }
        }
        
        private DataTable GenerateReport(string reportType, DateTime startDate, DateTime endDate)
        {
            DataTable dt = new DataTable();
            
            if (reportType.Contains("Membership Trends"))
            {
                dt.Columns.Add("Month", typeof(string));
                dt.Columns.Add("New Members", typeof(int));
                dt.Columns.Add("Total Members", typeof(int));
                
                for (int i = 0; i < 6; i++)
                {
                    DateTime month = startDate.AddMonths(i);
                    string monthName = month.ToString("MMM yyyy");
                    
                    int newMembers = DatabaseHelper.Memberships.Count(m => 
                        m.JoinDate.Year == month.Year && m.JoinDate.Month == month.Month &&
                        m.Status == "approved");
                    
                    int totalMembers = DatabaseHelper.Memberships.Count(m => 
                        m.JoinDate <= month && m.Status == "approved");
                    
                    dt.Rows.Add(monthName, newMembers, totalMembers);
                }
            }
            else if (reportType.Contains("Event Participation"))
            {
                dt.Columns.Add("Event Name", typeof(string));
                dt.Columns.Add("Event Date", typeof(string));
                dt.Columns.Add("Registrations", typeof(int));
                dt.Columns.Add("Capacity", typeof(int));
                dt.Columns.Add("Fill Rate %", typeof(double));
                
                var events = DatabaseHelper.Events.Where(e => e.EventDate >= startDate && e.EventDate <= endDate);
                
                foreach (var ev in events)
                {
                    int registrations = DatabaseHelper.EventRegistrations.Count(r => r.EventId == ev.EventId);
                    double fillRate = ev.Capacity > 0 ? (registrations * 100.0 / ev.Capacity) : 0;
                    
                    dt.Rows.Add(ev.Title, ev.EventDate.ToString("dd MMM yyyy"), 
                        registrations, ev.Capacity, Math.Round(fillRate, 2));
                }
            }
            else if (reportType.Contains("Activity Summary"))
            {
                dt.Columns.Add("Date", typeof(string));
                dt.Columns.Add("Action", typeof(string));
                dt.Columns.Add("User", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                
                // Get logs from database (simplified)
                string query = @"SELECT Date(Timestamp) as Date, Action, 
                                (SELECT Username FROM Users WHERE UserId = ActivityLogs.UserId) as User,
                                Description 
                                FROM ActivityLogs 
                                WHERE Date(Timestamp) BETWEEN @start AND @end
                                ORDER BY Timestamp DESC";
                
                var parameters = new[]
                {
                    new SqliteParameter("@start", startDate.ToString("yyyy-MM-dd")),
                    new SqliteParameter("@end", endDate.ToString("yyyy-MM-dd"))
                };
                
                dt = DatabaseHelper.ExecuteQuery(query, parameters);
            }
            
            return dt;
        }
        
        private void ShowChart(DataTable dt, string reportType)
        {
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No data available for chart visualization.", "Info", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
            Form chartForm = new Form();
            chartForm.Text = $"Chart - {reportType}";
            chartForm.Size = new Size(800, 600);
            chartForm.StartPosition = FormStartPosition.CenterParent;
            
            // Simple chart using DataGridView
            DataGridView chartGrid = new DataGridView();
            chartGrid.Dock = DockStyle.Fill;
            chartGrid.DataSource = dt;
            chartGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            chartForm.Controls.Add(chartGrid);
            chartForm.ShowDialog();
        }
        
        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dgvReport.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Files|*.xlsx|CSV Files|*.csv";
            sfd.Title = "Export Report";
            
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(sfd.FileName);
                MessageBox.Show($"Report exported to {sfd.FileName}", "Export Complete", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                DatabaseHelper.LogActivity(SessionManagement.CurrentUserId, "REPORT_EXPORTED", 
                    $"Exported {cmbReportType.SelectedItem} to {sfd.FileName}");
            }
        }
        
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF export feature coming soon!\n\nSaving as CSV instead.", "Info", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnExport_Click(sender, e);
        }
        
        private void ExportToCSV(string filePath)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath))
            {
                // Write headers
                for (int i = 0; i < dgvReport.Columns.Count; i++)
                {
                    sw.Write(dgvReport.Columns[i].HeaderText);
                    if (i < dgvReport.Columns.Count - 1) sw.Write(",");
                }
                sw.WriteLine();
                
                // Write data
                foreach (DataGridViewRow row in dgvReport.Rows)
                {
                    for (int i = 0; i < dgvReport.Columns.Count; i++)
                    {
                        sw.Write(row.Cells[i].Value?.ToString() ?? "");
                        if (i < dgvReport.Columns.Count - 1) sw.Write(",");
                    }
                    sw.WriteLine();
                }
            }
        }
        
        private void chkShowChart_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowChart.Checked && dgvReport.Rows.Count > 0)
            {
                ShowChart((DataTable)dgvReport.DataSource, cmbReportType.SelectedItem?.ToString() ?? "");
            }
        }
    }
}