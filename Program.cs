using System;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            // Initialize database and create sample data
            InitializeSampleData();
            
            Application.Run(new Form1());
        }
        
        static void InitializeSampleData()
        {
            try
            {
                // DatabaseHelper already initializes via static constructor
                // Add additional sample data if needed
                
                // Check if we have any societies, if not, add sample ones
                if (DatabaseHelper.Societies.Count == 0)
                {
                    // Add sample society
                    var society = new Society
                    {
                        SocietyId = 1,
                        Name = "FAST Programming Club",
                        Description = "Official coding and development society",
                        Category = "Technical",
                        HeadUserId = 2 // Society head user ID
                    };
                    DatabaseHelper.Societies.Add(society);
                }
                
                // Check if we have any events, if not, add sample events
                if (DatabaseHelper.Events.Count == 0)
                {
                    var sampleEvent = new Event
                    {
                        EventId = 1,
                        SocietyId = 1,
                        Title = "Annual Hackathon 2026",
                        Description = "24-hour coding competition",
                        EventDate = DateTime.Now.AddDays(30),
                        Venue = "FAST Auditorium",
                        Capacity = 100,
                        Status = "approved"
                    };
                    DatabaseHelper.Events.Add(sampleEvent);
                }
                
                // Check if we have any tasks, if not, add sample tasks
                if (DatabaseHelper.Tasks.Count == 0)
                {
                    var sampleTask = new TaskItem
                    {
                        TaskId = 1,
                        SocietyId = 1,
                        Title = "Prepare Hackathon Poster",
                        Description = "Design promotional materials",
                        AssignedTo = 3, // Student ID
                        AssignedBy = 2, // Society Head ID
                        DueDate = DateTime.Now.AddDays(7),
                        Status = "pending",
                        Priority = "High"
                    };
                    DatabaseHelper.Tasks.Add(sampleTask);
                }
                
                Console.WriteLine("Sample data initialized successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing sample data: {ex.Message}");
            }
        }
    }
}