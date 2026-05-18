using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public partial class EventsForm : Form
    {
        public EventsForm()
        {
            InitializeComponent();
            this.Load += EventsForm_Load;
        }

        private void EventsForm_Load(object sender, EventArgs e)
        {
            LoadEvents();
        }

        private void LoadEvents(string filter = "")
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EventId", typeof(int));
            dt.Columns.Add("Event Name", typeof(string));
            dt.Columns.Add("Society", typeof(string));
            dt.Columns.Add("Date", typeof(string));
            dt.Columns.Add("Venue", typeof(string));      // Changed from Location
            dt.Columns.Add("Capacity", typeof(int));      // Changed from MaxParticipants
            dt.Columns.Add("Status", typeof(string));

            var query = DatabaseHelper.Events.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(ev =>
                    ev.Title.Contains(filter, StringComparison.OrdinalIgnoreCase));
            }

            foreach (var ev in query.OrderByDescending(ev => ev.EventDate))
            {
                var society = DatabaseHelper.Societies.FirstOrDefault(s => s.SocietyId == ev.SocietyId);
                dt.Rows.Add(
                    ev.EventId,
                    ev.Title,
                    society?.Name ?? "Unknown",
                    ev.EventDate.ToString("dd MMM yyyy HH:mm"),
                    ev.Venue,           // Changed from Location
                    ev.Capacity,        // Changed from MaxParticipants
                    ev.Status
                );
            }

            eventsDataGridView.DataSource = dt;

            // Hide ID column
            if (eventsDataGridView.Columns.Contains("EventId"))
                eventsDataGridView.Columns["EventId"].Visible = false;
        }

        private void filterButton_Click(object sender, EventArgs e)
        {
            string filterText = "";
            
            // If you have a search TextBox in the designer, use it:
            // filterText = searchTextBox.Text.Trim();

            LoadEvents(filterText);
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            if (eventsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event to register.", "Warning", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(eventsDataGridView.SelectedRows[0].Cells["EventId"].Value);
            int studentId = SessionManagement.CurrentUserId;

            // Check if already registered
            if (DatabaseHelper.EventRegistrations.Any(r => r.EventId == eventId && r.StudentId == studentId))
            {
                MessageBox.Show("You are already registered for this event.", "Info", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedEvent = DatabaseHelper.Events.FirstOrDefault(ev => ev.EventId == eventId);
            if (selectedEvent == null) return;

            // Check capacity
            int currentRegistrations = DatabaseHelper.EventRegistrations.Count(r => r.EventId == eventId);
            if (currentRegistrations >= selectedEvent.Capacity)
            {
                MessageBox.Show("Sorry, this event is already full!", "Capacity Reached", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate ticket number
            string ticketNumber = $"TKT-{DateTime.Now:yyyyMMdd}-{studentId}-{eventId}";

            // Create new registration
            var registration = new EventRegistration
            {
                RegistrationId = DatabaseHelper.EventRegistrations.Count + 1,
                EventId = eventId,
                StudentId = studentId,
                RegistrationDate = DateTime.Now,
                TicketNumber = ticketNumber      // Using TicketNumber property
            };
            
            DatabaseHelper.EventRegistrations.Add(registration);

            DatabaseHelper.LogActivity(studentId, "EVENT_REGISTER", $"Registered for: {selectedEvent.Title}");

            MessageBox.Show($"✅ Registration Successful!\n\nYour Ticket Number:\n{ticketNumber}\n\nPlease save this number.", 
                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadEvents(); // Refresh
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadEvents();
        }

        // Optional: Open this form as dialog from Student Dashboard
        public static void ShowAsDialog()
        {
            using (var form = new EventsForm())
            {
                form.ShowDialog();
            }
        }
    }
}