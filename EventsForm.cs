using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class EventsForm : Form
    {
        public EventsForm()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents(string filter = "")
        {
            string query = @"SELECT e.event_id, e.title AS [Event Name], s.name AS [Society], 
                             e.event_date AS [Date], e.venue, e.capacity, 
                             e.approval_status AS [Status]
                             FROM Events e 
                             JOIN Societies s ON e.society_id = s.society_id";

            if (!string.IsNullOrEmpty(filter))
            {
                query += " WHERE e.title LIKE @filter OR s.name LIKE @filter";
            }

            query += " ORDER BY e.event_date DESC";

            Microsoft.Data.SqlClient.SqlParameter[] parameters = string.IsNullOrEmpty(filter) 
                ? null 
                : new Microsoft.Data.SqlClient.SqlParameter[] { new SqlParameter("@filter", "%" + filter + "%") };

            eventsDataGridView.DataSource = DatabaseHelper.ExecuteQuery(query, parameters);

            // Hide ID column
            if (eventsDataGridView.Columns.Contains("event_id"))
                eventsDataGridView.Columns["event_id"].Visible = false;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            // Safe check in case searchTextBox doesn't exist in designer yet
            string filterText = "";
            // If you add searchTextBox later in designer, you can uncomment below:
            // if (searchTextBox != null) filterText = searchTextBox.Text.Trim();

            LoadEvents(filterText);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (eventsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event to register.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(eventsDataGridView.SelectedRows[0].Cells["event_id"].Value);
            int studentId = SessionManagement.CurrentUser.UserId;

            string checkQuery = "SELECT COUNT(*) FROM EventRegistrations WHERE student_id=@sid AND event_id=@eid";
            Microsoft.Data.SqlClient.SqlParameter[] checkParams = 
            { 
                new Microsoft.Data.SqlClient.SqlParameter("@sid", studentId),
                new Microsoft.Data.SqlClient.SqlParameter("@eid", eventId)
            };

            int alreadyRegistered = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkQuery, checkParams));

            if (alreadyRegistered > 0)
            {
                MessageBox.Show("You are already registered for this event.");
                return;
            }

            string ticketNumber = $"TKT-{eventId}-{studentId}-{Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper()}";

            string insertQuery = @"INSERT INTO EventRegistrations 
                (student_id, event_id, registration_date, ticket_number, created_at, updated_at)
                VALUES (@sid, @eid, SYSDATETIME(), @ticket, SYSDATETIME(), SYSDATETIME())";

            Microsoft.Data.SqlClient.SqlParameter[] insertParams = 
            { 
                new Microsoft.Data.SqlClient.SqlParameter("@sid", studentId),
                new Microsoft.Data.SqlClient.SqlParameter("@eid", eventId),
                new Microsoft.Data.SqlClient.SqlParameter("@ticket", ticketNumber)
            };

            DatabaseHelper.ExecuteNonQuery(insertQuery, insertParams);

            MessageBox.Show($"Registration Successful!\nYour Ticket: {ticketNumber}", "Success", 
                           MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadEvents();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadEvents();
        }
    }
}