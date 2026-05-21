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
        public string Status { get; set; } = "pending";
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
        public int? CreatorUserId { get; set; }
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
        public static string ConnectionString => "Data Source=SocietiesDB.db;";
        
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
                // Users
                InsertUserIfNotExists(conn, "admin", AuthService.HashPassword("admin123"), "System Administrator", "admin@fast.edu.pk", "admin");
                InsertUserIfNotExists(conn, "head", AuthService.HashPassword("head123"), "Ahmed Khan", "ahmed.khan@fast.edu.pk", "society_head");
                InsertUserIfNotExists(conn, "student", AuthService.HashPassword("student123"), "Ali Hassan", "ali.hassan@fast.edu.pk", "student");
                for (int i = 1; i <= 12; i++)
                {
                    InsertUserIfNotExists(conn, $"student{i}", AuthService.HashPassword($"pass{i}"), $"Student {i} Name", $"student{i}@fast.edu.pk", "student");
                }

                // Societies
                string checkSociety = "SELECT COUNT(*) FROM Societies";
                using (var cmd = new SqliteCommand(checkSociety, conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            string insertSociety = $@"INSERT INTO Societies (Name, Description, Category, HeadUserId) 
                                VALUES ('Society {i}', 'Description for Society {i}', 'Category {i%3}', 
                                (SELECT UserId FROM Users WHERE Username = 'head'))";
                            using (var cmd2 = new SqliteCommand(insertSociety, conn))
                            {
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Events
                string checkEvent = "SELECT COUNT(*) FROM Events";
                using (var cmd = new SqliteCommand(checkEvent, conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        for (int i = 1; i <= 15; i++)
                        {
                            string insertEvent = $@"INSERT INTO Events (SocietyId, Title, Description, EventDate, Venue, Capacity, Status) 
                                VALUES ({(i%10)+1}, 'Event {i}', 'Description for Event {i}', date('now', '+{i} days'), 'Venue {i}', {50+i*5}, 'pending')";
                            using (var cmd2 = new SqliteCommand(insertEvent, conn))
                            {
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Memberships
                string checkMembership = "SELECT COUNT(*) FROM Memberships";
                using (var cmd = new SqliteCommand(checkMembership, conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        for (int i = 1; i <= 15; i++)
                        {
                            string insertMembership = $@"INSERT INTO Memberships (StudentId, SocietyId, JoinDate, Status) 
                                VALUES ({(i%12)+2}, {(i%10)+1}, date('now', '-{i} days'), 'approved')";
                            using (var cmd2 = new SqliteCommand(insertMembership, conn))
                            {
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Tasks
                string checkTask = "SELECT COUNT(*) FROM Tasks";
                using (var cmd = new SqliteCommand(checkTask, conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        for (int i = 1; i <= 12; i++)
                        {
                            string insertTask = $@"INSERT INTO Tasks (SocietyId, Title, Description, AssignedTo, AssignedBy, DueDate, Status) 
                                VALUES ({(i%10)+1}, 'Task {i}', 'Description for Task {i}', {(i%12)+2}, 1, date('now', '+{i} days'), 'pending')";
                            using (var cmd2 = new SqliteCommand(insertTask, conn))
                            {
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                }

                // Announcements (if you have an Announcements table, add similar logic here)

                // Activity Logs
                string checkLog = "SELECT COUNT(*) FROM ActivityLogs";
                using (var cmd = new SqliteCommand(checkLog, conn))
                {
                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        for (int i = 1; i <= 10; i++)
                        {
                            string insertLog = $@"INSERT INTO ActivityLogs (UserId, Action, Description, Timestamp) 
                                VALUES ({(i%12)+2}, 'ACTION_{i}', 'Description for action {i}', datetime('now', '-{i} days'))";
                            using (var cmd2 = new SqliteCommand(insertLog, conn))
                            {
                                cmd2.ExecuteNonQuery();
                            }
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

        // Add these methods to DatabaseHelper.cs

        public static void ApproveSociety(int societyId, int adminId)
        {
            string query = "UPDATE Societies SET Status = 'approved' WHERE SocietyId = @sid";
            var parameters = new[] { new SqliteParameter("@sid", societyId) };
            ExecuteNonQuery(query, parameters);
            
            // Update in-memory list
            var society = Societies.FirstOrDefault(s => s.SocietyId == societyId);
            if (society != null) society.Status = "approved";
            
            LogActivity(adminId, "SOCIETY_APPROVED", $"Society ID {societyId} was approved");

            // Notify society head
            var societyHeadId = society?.HeadUserId;
            if (societyHeadId != null)
            {
                NotificationService.SendNotification(societyHeadId.Value,
                    "Society Approved",
                    $"Your society '{society.Name}' has been approved by admin.",
                    "success");
            }
        }

        public static (bool success, string message, int userId) CreateUser(string username, string password, string fullName, string email, string role)
        {
            try
            {
                // Check if username exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                var checkParams = new[] { new SqliteParameter("@username", username) };
                var result = ExecuteQuery(checkQuery, checkParams);
                
                if (Convert.ToInt32(result.Rows[0][0]) > 0)
                    return (false, "Username already exists", -1);
                
                string hashedPassword = AuthService.HashPassword(password);
                string insertQuery = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, Role, Status) 
                                    VALUES (@username, @hash, @fullname, @email, @role, 'active')";
                
                var parameters = new[]
                {
                    new SqliteParameter("@username", username),
                    new SqliteParameter("@hash", hashedPassword),
                    new SqliteParameter("@fullname", fullName),
                    new SqliteParameter("@email", email),
                    new SqliteParameter("@role", role)
                };
                
                ExecuteNonQuery(insertQuery, parameters);
                
                // Get the new user ID
                string getIdQuery = "SELECT last_insert_rowid()";
                var idResult = ExecuteQuery(getIdQuery);
                int newId = Convert.ToInt32(idResult.Rows[0][0]);
                
                LogActivity(SessionManagement.GetCurrentUser()?.UserId ?? 1, "USER_CREATED", $"Created user: {username}");
                
                return (true, "User created successfully", newId);
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", -1);
            }
        }

        public static (bool success, string message) UpdateUser(int userId, string fullName, string email, string role, string status)
        {
            try
            {
                string query = "UPDATE Users SET FullName = @fullname, Email = @email, Role = @role, Status = @status WHERE UserId = @userId";
                var parameters = new[]
                {
                    new SqliteParameter("@fullname", fullName),
                    new SqliteParameter("@email", email),
                    new SqliteParameter("@role", role),
                    new SqliteParameter("@status", status),
                    new SqliteParameter("@userId", userId)
                };
                
                ExecuteNonQuery(query, parameters);
                
                // Update in-memory list
                var user = Users.FirstOrDefault(u => u.UserId == userId);
                if (user != null)
                {
                    user.FullName = fullName;
                    user.Email = email;
                    user.Role = role;
                    user.Status = status;
                }
                
                LogActivity(SessionManagement.GetCurrentUser()?.UserId ?? 1, "USER_UPDATED", $"Updated user ID {userId}");
                
                return (true, "User updated successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        public static (bool success, string message) DeleteUser(int userId)
        {
            try
            {
                // Check if user exists
                var user = GetUserById(userId);
                if (user == null)
                    return (false, "User not found");
                
                // Don't delete admin if it's the only one
                if (user.Role == "admin")
                {
                    string adminCountQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'admin'";
                    var countResult = ExecuteQuery(adminCountQuery);
                    if (Convert.ToInt32(countResult.Rows[0][0]) <= 1)
                        return (false, "Cannot delete the last admin user");
                }
                
                string query = "DELETE FROM Users WHERE UserId = @userId";
                var parameters = new[] { new SqliteParameter("@userId", userId) };
                ExecuteNonQuery(query, parameters);
                
                // Remove from in-memory list
                var userToRemove = Users.FirstOrDefault(u => u.UserId == userId);
                if (userToRemove != null)
                    Users.Remove(userToRemove);
                
                LogActivity(SessionManagement.GetCurrentUser()?.UserId ?? 1, "USER_DELETED", $"Deleted user ID {userId} (Username: {user.Username})");
                
                return (true, "User deleted successfully");
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        public static DataTable GetAllUsers()
        {
            string query = "SELECT UserId, Username, FullName, Email, Role, Status FROM Users ORDER BY UserId";
            return ExecuteQuery(query);
        }

        public static DataTable GetSocietiesByHead(int headUserId)
        {
            string query = "SELECT SocietyId, Name, Description, Category, Status FROM Societies WHERE HeadUserId = @headId";
            var parameters = new[] { new SqliteParameter("@headId", headUserId) };
            return ExecuteQuery(query, parameters);
        }

        public static DataTable GetMembersBySociety(int societyId)
        {
            string query = @"SELECT u.UserId, u.FullName, u.Email, m.JoinDate, m.Status
                            FROM Memberships m
                            JOIN Users u ON m.StudentId = u.UserId
                            WHERE m.SocietyId = @socId AND m.Status = 'approved'";
            var parameters = new[] { new SqliteParameter("@socId", societyId) };
            return ExecuteQuery(query, parameters);
        }

        public static DataTable GetEventsBySociety(int societyId)
        {
            string query = "SELECT EventId, Title, Description, EventDate, Venue, Capacity, Status FROM Events WHERE SocietyId = @socId ORDER BY EventDate";
            var parameters = new[] { new SqliteParameter("@socId", societyId) };
            return ExecuteQuery(query, parameters);
        }

        public static bool CreateEvent(Event eventItem)
        {
            string query = @"INSERT INTO Events (SocietyId, Title, Description, EventDate, Venue, Capacity, Status, CreatorUserId) 
                            VALUES (@sid, @title, @desc, @date, @venue, @cap, 'pending', @creator)";
            
            var parameters = new[]
            {
                new SqliteParameter("@sid", eventItem.SocietyId),
                new SqliteParameter("@title", eventItem.Title),
                new SqliteParameter("@desc", eventItem.Description),
                new SqliteParameter("@date", eventItem.EventDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqliteParameter("@venue", eventItem.Venue),
                new SqliteParameter("@cap", eventItem.Capacity),
                new SqliteParameter("@creator", eventItem.CreatorUserId ?? SessionManagement.GetCurrentUser()?.UserId ?? 1)
            };
            
            ExecuteNonQuery(query, parameters);
            
            // Add to in-memory list
            eventItem.EventId = Events.Count + 1;
            Events.Add(eventItem);
            
            LogActivity(SessionManagement.GetCurrentUser()?.UserId ?? 1, "EVENT_CREATED", $"Created event: {eventItem.Title}");
            
            return true;
        }

        public static bool UpdateEvent(Event eventItem)
        {
            string query = @"UPDATE Events SET Title = @title, Description = @desc, EventDate = @date, 
                            Venue = @venue, Capacity = @cap WHERE EventId = @eid";
            
            var parameters = new[]
            {
                new SqliteParameter("@title", eventItem.Title),
                new SqliteParameter("@desc", eventItem.Description),
                new SqliteParameter("@date", eventItem.EventDate.ToString("yyyy-MM-dd HH:mm:ss")),
                new SqliteParameter("@venue", eventItem.Venue),
                new SqliteParameter("@cap", eventItem.Capacity),
                new SqliteParameter("@eid", eventItem.EventId)
            };
            
            ExecuteNonQuery(query, parameters);
            
            // Update in-memory list
            var existingEvent = Events.FirstOrDefault(e => e.EventId == eventItem.EventId);
            if (existingEvent != null)
            {
                existingEvent.Title = eventItem.Title;
                existingEvent.Description = eventItem.Description;
                existingEvent.EventDate = eventItem.EventDate;
                existingEvent.Venue = eventItem.Venue;
                existingEvent.Capacity = eventItem.Capacity;
            }
            
            LogActivity(SessionManagement.GetCurrentUser()?.UserId ?? 1, "EVENT_UPDATED", $"Updated event ID {eventItem.EventId}");
            
            return true;
        }

        public static bool DeleteEvent(int eventId)
        {
            string query = "DELETE FROM Events WHERE EventId = @eid";
            var parameters = new[] { new SqliteParameter("@eid", eventId) };
            ExecuteNonQuery(query, parameters);
            
            // Remove from in-memory list
            var eventToRemove = Events.FirstOrDefault(e => e.EventId == eventId);
            if (eventToRemove != null)
                Events.Remove(eventToRemove);
            
            // Also delete registrations
            string deleteRegQuery = "DELETE FROM EventRegistrations WHERE EventId = @eid";
            ExecuteNonQuery(deleteRegQuery, parameters);
            
            LogActivity(SessionManagement.GetCurrentUser()?.UserId ?? 1, "EVENT_DELETED", $"Deleted event ID {eventId}");
            
            return true;
        }

        public static DataTable GenerateSocietyReport(int societyId)
        {
            // Members count
            string membersQuery = @"SELECT COUNT(*) as MemberCount FROM Memberships 
                                WHERE SocietyId = @sid AND Status = 'approved'";
            var parameters = new[] { new SqliteParameter("@sid", societyId) };
            var membersResult = ExecuteQuery(membersQuery, parameters);
            
            // Events count
            string eventsQuery = @"SELECT COUNT(*) as EventCount, 
                                SUM(CASE WHEN Status = 'approved' THEN 1 ELSE 0 END) as ApprovedEvents,
                                SUM(CASE WHEN Status = 'pending' THEN 1 ELSE 0 END) as PendingEvents
                                FROM Events WHERE SocietyId = @sid";
            var eventsResult = ExecuteQuery(eventsQuery, parameters);
            
            // Tasks count
            string tasksQuery = @"SELECT COUNT(*) as TaskCount,
                                SUM(CASE WHEN Status = 'completed' THEN 1 ELSE 0 END) as CompletedTasks,
                                SUM(CASE WHEN Status = 'pending' THEN 1 ELSE 0 END) as PendingTasks
                                FROM Tasks WHERE SocietyId = @sid";
            var tasksResult = ExecuteQuery(tasksQuery, parameters);
            
            // Combine results
            DataTable report = new DataTable();
            report.Columns.Add("Metric");
            report.Columns.Add("Value");
            
            report.Rows.Add("Total Members", membersResult.Rows[0]["MemberCount"]);
            report.Rows.Add("Total Events", eventsResult.Rows[0]["EventCount"]);
            report.Rows.Add("Approved Events", eventsResult.Rows[0]["ApprovedEvents"]);
            report.Rows.Add("Pending Events", eventsResult.Rows[0]["PendingEvents"]);
            report.Rows.Add("Total Tasks", tasksResult.Rows[0]["TaskCount"]);
            report.Rows.Add("Completed Tasks", tasksResult.Rows[0]["CompletedTasks"]);
            report.Rows.Add("Pending Tasks", tasksResult.Rows[0]["PendingTasks"]);
            
            return report;
        }

        public static DataTable GenerateUniversityReport()
        {
            DataTable report = new DataTable();
            report.Columns.Add("Category");
            report.Columns.Add("Count");
            
            // Total students
            string studentsQuery = "SELECT COUNT(*) FROM Users WHERE Role = 'student'";
            var studentsResult = ExecuteQuery(studentsQuery);
            report.Rows.Add("Total Students", studentsResult.Rows[0][0]);
            
            // Total societies
            string societiesQuery = "SELECT COUNT(*) FROM Societies WHERE Status = 'approved'";
            var societiesResult = ExecuteQuery(societiesQuery);
            report.Rows.Add("Active Societies", societiesResult.Rows[0][0]);
            
            // Total events this month
            string eventsQuery = @"SELECT COUNT(*) FROM Events 
                                WHERE EventDate >= date('now', 'start of month') 
                                AND EventDate <= date('now', 'end of month')
                                AND Status = 'approved'";
            var eventsResult = ExecuteQuery(eventsQuery);
            report.Rows.Add("Events This Month", eventsResult.Rows[0][0]);
            
            // Total memberships
            string membershipsQuery = "SELECT COUNT(*) FROM Memberships WHERE Status = 'approved'";
            var membershipsResult = ExecuteQuery(membershipsQuery);
            report.Rows.Add("Total Memberships", membershipsResult.Rows[0][0]);
            
            // Pending approvals
            string pendingSocieties = "SELECT COUNT(*) FROM Societies WHERE Status = 'pending'";
            var pendingSocResult = ExecuteQuery(pendingSocieties);
            report.Rows.Add("Pending Societies", pendingSocResult.Rows[0][0]);
            
            string pendingEvents = "SELECT COUNT(*) FROM Events WHERE Status = 'pending'";
            var pendingEventsResult = ExecuteQuery(pendingEvents);
            report.Rows.Add("Pending Events", pendingEventsResult.Rows[0][0]);
            
            return report;
        }

        public static void RejectSociety(int societyId, int adminId, string reason = "")
        {
            string query = "UPDATE Societies SET Status = 'rejected' WHERE SocietyId = @sid";
            var parameters = new[] { new SqliteParameter("@sid", societyId) };
            ExecuteNonQuery(query, parameters);
            
            var society = Societies.FirstOrDefault(s => s.SocietyId == societyId);
            if (society != null) society.Status = "rejected";
            
            LogActivity(adminId, "SOCIETY_REJECTED", $"Society ID {societyId} was rejected. Reason: {reason}");

            // Notify society head
            var societyHeadId = society?.HeadUserId;
            if (societyHeadId != null)
            {
                NotificationService.SendNotification(societyHeadId.Value,
                    "Society Rejected",
                    $"Your society '{society.Name}' was rejected by admin. Reason: {reason}",
                    "error");
            }
        }

        public static void ApproveEvent(int eventId, int adminId)
        {
            string query = "UPDATE Events SET Status = 'approved' WHERE EventId = @eid";
            var parameters = new[] { new SqliteParameter("@eid", eventId) };
            ExecuteNonQuery(query, parameters);
            
            var event_item = Events.FirstOrDefault(e => e.EventId == eventId);
            if (event_item != null) event_item.Status = "approved";
            
            LogActivity(adminId, "EVENT_APPROVED", $"Event ID {eventId} was approved");

            // Notify event creator (assuming event_item.CreatorUserId exists)
            var creatorId = event_item?.CreatorUserId;
            if (creatorId != null)
            {
                NotificationService.SendNotification(creatorId.Value,
                    "Event Approved",
                    $"Your event '{event_item.Title}' has been approved by admin.",
                    "success");
            }
        }

        public static void RejectEvent(int eventId, int adminId, string reason = "")
        {
            string query = "UPDATE Events SET Status = 'rejected' WHERE EventId = @eid";
            var parameters = new[] { new SqliteParameter("@eid", eventId) };
            ExecuteNonQuery(query, parameters);
            
            var event_item = Events.FirstOrDefault(e => e.EventId == eventId);
            if (event_item != null) event_item.Status = "rejected";
            
            LogActivity(adminId, "EVENT_REJECTED", $"Event ID {eventId} was rejected. Reason: {reason}");

            // Notify event creator (assuming event_item.CreatorUserId exists)
            var creatorId = event_item?.CreatorUserId;
            if (creatorId != null)
            {
                NotificationService.SendNotification(creatorId.Value,
                    "Event Rejected",
                    $"Your event '{event_item.Title}' was rejected by admin. Reason: {reason}",
                    "error");
            }
        }

        public static void ApproveMembership(int membershipId, int headId)
        {
            string query = "UPDATE Memberships SET Status = 'approved' WHERE MembershipId = @mid";
            var parameters = new[] { new SqliteParameter("@mid", membershipId) };
            ExecuteNonQuery(query, parameters);
            
            var membership = Memberships.FirstOrDefault(m => m.MembershipId == membershipId);
            if (membership != null) membership.Status = "approved";
            
            LogActivity(headId, "MEMBERSHIP_APPROVED", $"Membership ID {membershipId} was approved");

            // Notify student
            var studentId = membership?.StudentId;
            if (studentId != null)
            {
                NotificationService.SendNotification(studentId.Value,
                    "Membership Approved",
                    $"Your membership request has been approved.",
                    "success");
            }
        }

        public static void RejectMembership(int membershipId, int headId, string reason = "")
        {
            string query = "UPDATE Memberships SET Status = 'rejected' WHERE MembershipId = @mid";
            var parameters = new[] { new SqliteParameter("@mid", membershipId) };
            ExecuteNonQuery(query, parameters);
            
            var membership = Memberships.FirstOrDefault(m => m.MembershipId == membershipId);
            if (membership != null) membership.Status = "rejected";

            // Notify student
            var studentId = membership?.StudentId;
            if (studentId != null)
            {
                NotificationService.SendNotification(studentId.Value,
                    "Membership Rejected",
                    $"Your membership request was rejected. Reason: {reason}",
                    "error");
            }
            
            LogActivity(headId, "MEMBERSHIP_REJECTED", $"Membership ID {membershipId} was rejected. Reason: {reason}");
        }

        public static DataTable GetPendingSocieties()
        {
            string query = "SELECT SocietyId, Name, Description, Category FROM Societies WHERE Status = 'pending'";
            return ExecuteQuery(query);
        }

        public static DataTable GetPendingEvents()
        {
            string query = "SELECT EventId, Title, Description, EventDate, SocietyId FROM Events WHERE Status = 'pending'";
            return ExecuteQuery(query);
        }

        public static DataTable GetPendingMembershipsForSociety(int societyId)
        {
            string query = @"SELECT m.MembershipId, u.FullName as StudentName, u.Email, m.JoinDate 
                            FROM Memberships m
                            JOIN Users u ON m.StudentId = u.UserId
                            WHERE m.SocietyId = @sid AND m.Status = 'pending'";
            var parameters = new[] { new SqliteParameter("@sid", societyId) };
            return ExecuteQuery(query, parameters);
        }
    }
}