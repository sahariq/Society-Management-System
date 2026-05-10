using System;
using System.Data;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class SocietiesBrowserForm : Form
    {
        public SocietiesBrowserForm()
        {
            InitializeComponent();
            LoadSocieties();
        }

        private void LoadSocieties(string filter = "")
        {
            // For now, return dummy data (in-memory mode)
            DataTable dt = new DataTable();
            dt.Columns.Add("society_id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("MemberCount", typeof(int));

            dt.Rows.Add(1, "FAST Programming Club", "Technical", "A club for coding enthusiasts", 45);
            dt.Rows.Add(2, "Drama Society", "Cultural", "Theater and acting club", 30);
            dt.Rows.Add(3, "Robotics Club", "Technical", "Building and competing robots", 25);
            dt.Rows.Add(4, "Debate Club", "Literary", "Improve public speaking skills", 35);

            if (!string.IsNullOrEmpty(filter))
            {
                // Simple client-side filter
                var filteredRows = dt.AsEnumerable()
                    .Where(row => row.Field<string>("name").ToLower().Contains(filter.ToLower()) ||
                                  row.Field<string>("category").ToLower().Contains(filter.ToLower()));

                if (filteredRows.Any())
                {
                    dt = filteredRows.CopyToDataTable();
                }
                else
                {
                    dt.Clear();
                }
            }

            societiesDataGridView.DataSource = dt;

            if (societiesDataGridView.Columns.Contains("society_id"))
                societiesDataGridView.Columns["society_id"].Visible = false;
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            LoadSocieties(searchTextBox.Text.Trim());
        }

        private void btnJoin_Click(object sender, EventArgs e)
        {
            if (societiesDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a society to join.");
                return;
            }

            string societyName = societiesDataGridView.SelectedRows[0].Cells["name"].Value.ToString();
            MessageBox.Show($"Application to join '{societyName}' has been submitted!\n(Waiting for approval)", 
                           "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}