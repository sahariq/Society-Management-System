using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.Sqlite;

namespace SocietiesManagementSystem
{
    // ====================== MODEL CLASSES ======================
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string PasswordHash { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public string Status { get; set; } = "";
    }

    public class Society
    {
        public int SocietyId { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Category { get; set; } = "";
        public int? HeadUserId { get; set; }
    }

    public class TaskItem
    {
        public int TaskId { get; set; }
        public int SocietyId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int AssignedTo { get; set; }
        public int AssignedBy { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; } = "pending";
        public string Priority { get; set; } = "Medium";
    }

    public class Event
    {
        public int EventId { get; set; }
        public int SocietyId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime EventDate { get; set; }
        public string Venue { get; set; } = "";
        public int Capacity { get; set; }
        public string Status { get; set; } = "pending";
    }

    public class EventRegistration
    {
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }
        public string TicketNumber { get; set; } = "";
        public DateTime RegistrationDate { get; set; } = DateTime.Now;
    }

    public class Membership
    {
        public int MembershipId { get; set; }
        public int StudentId { get; set; }
        public int SocietyId { get; set; }
        public DateTime JoinDate { get; set; }
        public string Status { get; set; } = "pending";
    }

    // ====================== DATABASE HELPER ======================
    public static class DatabaseHelper
    {
        private static string ConnectionString => "Data Source=SocietiesDB.db;";
        
        // In-memory collections
        public static List<User> Users { get; private set; } = new List<User>();
        public static List<Society> Societies { get; private set; } = new List<Society>();
        public static List<TaskItem> Tasks { get; private set; } = new List<TaskItem>();
        public static List<Event> Events { get; private set; } = new List<Event>();
        public static List<Membership> Memberships { get; private set; } = new List<Membership>();
        public static List<EventRegistration> EventRegistrations { get; private set; } = new List<EventRegistration>();

        static DatabaseHelper()
        {
            InitializeDatabase();
            LoadSampleData();
        }

        public static void InitializeDatabase()
        {
            using (var connection = new SqliteConnection(ConnectionString))
            {
                connection.Open();
                string createTables = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        UserId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Username TEXT UNIQUE,
                        PasswordHash TEXT,
                        FullName TEXT,
                        Email TEXT,
                        Role TEXT,
                        Status TEXT DEFAULT 'active'
                    );

                    CREATE TABLE IF NOT EXISTS Societies (
                        SocietyId INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT,
                        Description TEXT,
                        Category TEXT,
                        HeadUserId INTEGER
                    );

                    CREATE TABLE IF NOT EXISTS Memberships (
                        MembershipId INTEGER PRIMARY KEY AUTOINCREMENT,
                        StudentId INTEGER,
                        SocietyId INTEGER,
                        JoinDate TEXT,
                        Status TEXT DEFAULT 'pending'
                    );

                    CREATE TABLE IF NOT EXISTS Events (
                        EventId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SocietyId INTEGER,
                        Title TEXT,
                        Description TEXT,
                        EventDate TEXT,
                        Venue TEXT,
                        Capacity INTEGER,
                        Status TEXT DEFAULT 'pending'
                    );

                    CREATE TABLE IF NOT EXISTS Tasks (
                        TaskId INTEGER PRIMARY KEY AUTOINCREMENT,
                        SocietyId INTEGER,
                        Title TEXT,
                        Description TEXT,
                        AssignedTo INTEGER,
                        AssignedBy INTEGER,
                        DueDate TEXT,
                        Status TEXT DEFAULT 'pending'
                    );

                    CREATE TABLE IF NOT EXISTS ActivityLogs (
                        LogId INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId INTEGER,
                        Action TEXT,
                        Description TEXT,
                        Timestamp TEXT
                    );";

                using (var cmd = new SqliteCommand(createTables, connection))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            CreateDefaultAccounts();
        }

        public static void CreateDefaultAccounts()
        {
            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                InsertUserIfNotExists(conn, "admin", AuthService.HashPassword("admin123"), "System Administrator", "admin@fast.edu.pk", "admin");
                InsertUserIfNotExists(conn, "head", AuthService.HashPassword("head123"), "Ahmed Khan", "ahmed.khan@fast.edu.pk", "society_head");
                InsertUserIfNotExists(conn, "student", AuthService.HashPassword("student123"), "Ali Hassan", "ali.hassan@fast.edu.pk", "student");
                
                string checkSociety = "SELECT COUNT(*) FROM Societies";
                using (var cmd = new SqliteCommand(checkSociety, conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        string insertSociety = @"INSERT INTO Societies (Name, Description, Category, HeadUserId) 
                                                VALUES ('FAST Programming Club', 'Official coding and development society of FAST', 'Technical', 
                                                (SELECT UserId FROM Users WHERE Role = 'society_head' LIMIT 1))";
                        using (var cmd2 = new SqliteCommand(insertSociety, conn))
                        {
                            cmd2.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private static void InsertUserIfNotExists(SqliteConnection conn, string username, string hash, string name, string email, string role)
        {
            string check = "SELECT COUNT(*) FROM Users WHERE Username = @u";
            using (var cmd = new SqliteCommand(check, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0) return;
            }

            string insert = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, Role, Status) 
                             VALUES (@u, @h, @n, @e, @r, 'active')";
            using (var cmd = new SqliteCommand(insert, conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@h", hash);
                cmd.Parameters.AddWithValue("@n", name);
                cmd.Parameters.AddWithValue("@e", email);
                cmd.Parameters.AddWithValue("@r", role);
                cmd.ExecuteNonQuery();
            }
        }

        private static void LoadSampleData()
        {
            // Load Users
            string userQuery = "SELECT * FROM Users";
            var userDt = ExecuteQuery(userQuery);
            foreach (DataRow row in userDt.Rows)
            {
                Users.Add(new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString() ?? "",
                    PasswordHash = row["PasswordHash"].ToString() ?? "",
                    FullName = row["FullName"].ToString() ?? "",
                    Email = row["Email"].ToString() ?? "",
                    Role = row["Role"].ToString() ?? "",
                    Status = row["Status"].ToString() ?? "active"
                });
            }

            // Load Societies
            string societyQuery = "SELECT * FROM Societies";
            var societyDt = ExecuteQuery(societyQuery);
            foreach (DataRow row in societyDt.Rows)
            {
                Societies.Add(new Society
                {
                    SocietyId = Convert.ToInt32(row["SocietyId"]),
                    Name = row["Name"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    Category = row["Category"].ToString() ?? "",
                    HeadUserId = row["HeadUserId"] != DBNull.Value ? Convert.ToInt32(row["HeadUserId"]) : (int?)null
                });
            }

            // Load Tasks
            string taskQuery = "SELECT * FROM Tasks";
            var taskDt = ExecuteQuery(taskQuery);
            foreach (DataRow row in taskDt.Rows)
            {
                Tasks.Add(new TaskItem
                {
                    TaskId = Convert.ToInt32(row["TaskId"]),
                    SocietyId = Convert.ToInt32(row["SocietyId"]),
                    Title = row["Title"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    AssignedTo = Convert.ToInt32(row["AssignedTo"]),
                    AssignedBy = row["AssignedBy"] != DBNull.Value ? Convert.ToInt32(row["AssignedBy"]) : 0,
                    DueDate = DateTime.Parse(row["DueDate"].ToString() ?? DateTime.Now.ToString()),
                    Status = row["Status"].ToString() ?? "pending"
                });
            }

            // Load Events
            string eventsQuery = "SELECT * FROM Events";
            var eventsDt = ExecuteQuery(eventsQuery);
            foreach (DataRow row in eventsDt.Rows)
            {
                Events.Add(new Event
                {
                    EventId = Convert.ToInt32(row["EventId"]),
                    SocietyId = Convert.ToInt32(row["SocietyId"]),
                    Title = row["Title"].ToString() ?? "",
                    Description = row["Description"].ToString() ?? "",
                    EventDate = DateTime.Parse(row["EventDate"].ToString() ?? DateTime.Now.ToString()),
                    Venue = row["Venue"].ToString() ?? "",
                    Capacity = Convert.ToInt32(row["Capacity"]),
                    Status = row["Status"].ToString() ?? "pending"
                });
            }
        }

        // ====================== PUBLIC METHODS ======================
        
        public static User? GetUserById(int userId)
        {
            return Users.FirstOrDefault(u => u.UserId == userId);
        }

        public static DataTable GetAllSocieties()
        {
            string query = "SELECT SocietyId, Name, Category, Description, HeadUserId FROM Societies";
            return ExecuteQuery(query);
        }

        public static DataTable GetApprovedSocieties()
        {
            string query = "SELECT SocietyId, Name, Category, Description FROM Societies";
            return ExecuteQuery(query);
        }

        public static bool ApplyForMembership(int studentId, int societyId)
        {
            string query = @"INSERT INTO Memberships (StudentId, SocietyId, JoinDate, Status) 
                           VALUES (@sid, @socid, datetime('now'), 'pending')";
            
            var parameters = new[]
            {
                new SqliteParameter("@sid", studentId),
                new SqliteParameter("@socid", societyId)
            };

            ExecuteNonQuery(query, parameters);
            return true;
        }

        public static void LogActivity(int userId, string action, string description)
        {
            string query = @"INSERT INTO ActivityLogs (UserId, Action, Description, Timestamp) 
                            VALUES (@uid, @act, @desc, datetime('now'))";
            
            var parameters = new[]
            {
                new SqliteParameter("@uid", userId),
                new SqliteParameter("@act", action),
                new SqliteParameter("@desc", description)
            };
            
            ExecuteNonQuery(query, parameters);
        }

        public static void AddTask(TaskItem task)
        {
            string query = @"INSERT INTO Tasks (SocietyId, Title, Description, AssignedTo, AssignedBy, DueDate, Status) 
                            VALUES (@sid, @title, @desc, @assignedTo, @assignedBy, @dueDate, @status)";
            
            var parameters = new[]
            {
                new SqliteParameter("@sid", task.SocietyId),
                new SqliteParameter("@title", task.Title),
                new SqliteParameter("@desc", task.Description),
                new SqliteParameter("@assignedTo", task.AssignedTo),
                new SqliteParameter("@assignedBy", task.AssignedBy),
                new SqliteParameter("@dueDate", task.DueDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqliteParameter("@status", task.Status)
            };
            
            ExecuteNonQuery(query, parameters);
            task.TaskId = Tasks.Count + 1;
            Tasks.Add(task);
        }

        public static void UpdateTaskStatus(int taskId, string status)
        {
            string query = "UPDATE Tasks SET Status = @status WHERE TaskId = @tid";
            var parameters = new[]
            {
                new SqliteParameter("@status", status),
                new SqliteParameter("@tid", taskId)
            };
            
            ExecuteNonQuery(query, parameters);
            
            var task = Tasks.FirstOrDefault(t => t.TaskId == taskId);
            if (task != null) task.Status = status;
        }

        // ====================== DATABASE EXECUTION METHODS ======================
        
        public static DataTable ExecuteQuery(string query, SqliteParameter[]? parameters = null)
        {
            DataTable dt = new DataTable();
            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    using (var reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);  // This replaces SqliteDataAdapter - NO ERROR NOW
                    }
                }
            }
            return dt;
        }

        public static int ExecuteNonQuery(string query, SqliteParameter[]? parameters = null)
        {
            using (var conn = new SqliteConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqliteCommand(query, conn))
                {
                    if (parameters != null) cmd.Parameters.AddRange(parameters);
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}