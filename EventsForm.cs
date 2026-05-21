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

        // Add these methods to EventsForm.cs

        private void btnViewMyTickets_Click(object sender, EventArgs e)
        {
            int studentId = SessionManagement.CurrentUserId;
            
            DataTable dt = new DataTable();
            dt.Columns.Add("Event Name", typeof(string));
            dt.Columns.Add("Event Date", typeof(string));
            dt.Columns.Add("Venue", typeof(string));
            dt.Columns.Add("Ticket Number", typeof(string));
            dt.Columns.Add("Registration Date", typeof(string));
            
            var myRegistrations = DatabaseHelper.EventRegistrations
                .Where(r => r.StudentId == studentId)
                .ToList();
            
            foreach (var reg in myRegistrations)
            {
                var event_item = DatabaseHelper.Events.FirstOrDefault(e => e.EventId == reg.EventId);
                if (event_item != null)
                {
                    dt.Rows.Add(
                        event_item.Title,
                        event_item.EventDate.ToString("dd MMM yyyy HH:mm"),
                        event_item.Venue,
                        reg.TicketNumber,
                        reg.RegistrationDate.ToString("dd MMM yyyy")
                    );
                }
            }
            
            Form ticketForm = new Form();
            ticketForm.Text = "My Event Tickets";
            ticketForm.Size = new System.Drawing.Size(800, 500);
            ticketForm.StartPosition = FormStartPosition.CenterParent;
            
            DataGridView dgvTickets = new DataGridView();
            dgvTickets.Dock = DockStyle.Fill;
            dgvTickets.DataSource = dt;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            Button btnPrint = new Button();
            btnPrint.Text = "Print Ticket";
            btnPrint.Dock = DockStyle.Bottom;
            btnPrint.Height = 40;
            btnPrint.Click += (s, args) => PrintTicket(dgvTickets);
            
            Button btnDownload = new Button();
            btnDownload.Text = "Download Ticket";
            btnDownload.Dock = DockStyle.Bottom;
            btnDownload.Height = 40;
            btnDownload.Click += (s, args) => DownloadTicket(dgvTickets);
            
            FlowLayoutPanel panel = new FlowLayoutPanel();
            panel.Dock = DockStyle.Bottom;
            panel.Height = 45;
            panel.Controls.Add(btnPrint);
            panel.Controls.Add(btnDownload);
            
            ticketForm.Controls.Add(dgvTickets);
            ticketForm.Controls.Add(panel);
            ticketForm.ShowDialog();
        }

        private void PrintTicket(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a ticket to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string eventName = dgv.SelectedRows[0].Cells["Event Name"].Value.ToString();
            string ticketNumber = dgv.SelectedRows[0].Cells["Ticket Number"].Value.ToString();
            string eventDate = dgv.SelectedRows[0].Cells["Event Date"].Value.ToString();
            string venue = dgv.SelectedRows[0].Cells["Venue"].Value.ToString();
            
            string ticketContent = $@"
                ========================================
                    FAST SOCIETIES MANAGEMENT
                        EVENT TICKET
                ========================================
                
                Event: {eventName}
                Date: {eventDate}
                Venue: {venue}
                Ticket #: {ticketNumber}
                Attendee: {SessionManagement.CurrentFullName}
                
                ========================================
                Please present this ticket at the venue
                ========================================
            ";
            
            MessageBox.Show(ticketContent, "Print Ticket", MessageBoxButtons.OK, MessageBoxIcon.Information);
            // In production, use PrintDocument class for actual printing
        }

        private void DownloadTicket(DataGridView dgv)
        {
            if (dgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a ticket to download.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            string eventName = dgv.SelectedRows[0].Cells["Event Name"].Value.ToString();
            string ticketNumber = dgv.SelectedRows[0].Cells["Ticket Number"].Value.ToString();
            
            string fileName = $"Ticket_{eventName}_{ticketNumber}.txt";
            string ticketContent = $"Event: {eventName}\nTicket: {ticketNumber}\nAttendee: {SessionManagement.CurrentFullName}";
            
            System.IO.File.WriteAllText(fileName, ticketContent);
            MessageBox.Show($"Ticket saved as: {fileName}", "Download Complete", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnValidateTicket_Click(object sender, EventArgs e)
        {
            string ticketNumber = Prompt.ShowDialog("Enter Ticket Number to validate:", "Validate Ticket");
            
            if (string.IsNullOrEmpty(ticketNumber)) return;
            
            var registration = DatabaseHelper.EventRegistrations
                .FirstOrDefault(r => r.TicketNumber == ticketNumber);
            
            if (registration == null)
            {
                MessageBox.Show("❌ Invalid ticket number!", "Validation Failed", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            var event_item = DatabaseHelper.Events.FirstOrDefault(e => e.EventId == registration.EventId);
            var student = DatabaseHelper.Users.FirstOrDefault(u => u.UserId == registration.StudentId);
            
            if (event_item == null || student == null) return;
            
            MessageBox.Show(
                $"✅ VALID TICKET!\n\n" +
                $"Event: {event_item.Title}\n" +
                $"Attendee: {student.FullName}\n" +
                $"Date: {event_item.EventDate:dd MMM yyyy}\n" +
                $"Venue: {event_item.Venue}",
                "Ticket Validation Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
            
            DatabaseHelper.LogActivity(SessionManagement.CurrentUserId, "TICKET_VALIDATED", 
                $"Validated ticket {ticketNumber} for {event_item.Title}");
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