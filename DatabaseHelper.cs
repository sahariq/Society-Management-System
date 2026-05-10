using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public static class DatabaseHelper
    {
        // In-memory storage
        public static List<User> Users { get; private set; } = new List<User>();
        public static List<ActivityLog> ActivityLogs { get; private set; } = new List<ActivityLog>();

        public class User
        {
            public int UserId { get; set; }
            public string Username { get; set; } = "";
            public string PasswordHash { get; set; } = "";
            public string FullName { get; set; } = "";
            public string Email { get; set; } = "";
            public string Role { get; set; } = "student";
            public string Status { get; set; } = "active";
        }

        public class ActivityLog
        {
            public int LogId { get; set; }
            public int UserId { get; set; }
            public string Action { get; set; } = "";
            public string Description { get; set; } = "";
            public DateTime Timestamp { get; set; } = DateTime.Now;
        }

        // ====================== Core Methods ======================

        public static void AddUser(string username, string passwordHash, string fullName, string email)
        {
            int newId = Users.Count + 1;
            Users.Add(new User
            {
                UserId = newId,
                Username = username,
                PasswordHash = passwordHash,
                FullName = fullName,
                Email = email,
                Role = "student",
                Status = "active"
            });
        }

        public static void AddUser(string username, string passwordHash, string fullName, string email, string role = "student")
        {
            int newId = Users.Count + 1;
            Users.Add(new User
            {
                UserId = newId,
                Username = username,
                PasswordHash = passwordHash,
                FullName = fullName,
                Email = email,
                Role = role,
                Status = "active"
            });
        }

        public static User? GetUser(string usernameOrEmail, string passwordHash)
        {
            return Users.FirstOrDefault(u =>
                (u.Username.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase) ||
                 u.Email.Equals(usernameOrEmail, StringComparison.OrdinalIgnoreCase)) &&
                u.PasswordHash == passwordHash);
        }

        // Fake methods for compatibility with other forms
        public static DataTable ExecuteQuery(string query, object? parameters = null)
        {
            return new DataTable(); // Return empty table for now
        }

                // ====================== Society CRUD ======================
        public static void AddSociety(string name, string category, string description)
        {
            // For now, just log it (we'll expand later)
            Console.WriteLine($"Society Added: {name} ({category})");
        }

        public static DataTable GetAllSocieties()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("society_id", typeof(int));
            dt.Columns.Add("name", typeof(string));
            dt.Columns.Add("category", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("status", typeof(string));
            dt.Columns.Add("member_count", typeof(int));

            dt.Rows.Add(1, "FAST Programming Club", "Technical", "Coding and development club", "approved", 45);
            dt.Rows.Add(2, "Drama Society", "Cultural", "Theater and performing arts", "approved", 32);
            dt.Rows.Add(3, "Robotics Club", "Technical", "Robotics and automation", "approved", 28);
            dt.Rows.Add(4, "Debate Club", "Literary", "Public speaking and debate", "approved", 35);

            return dt;
        }

        public static int ExecuteNonQuery(string query, object? parameters = null)
        {
            return 1; // Simulate success
        }

        public static object ExecuteScalar(string query, object? parameters = null)
        {
            return 0;
        }

                // ====================== Default Accounts ======================
        public static void CreateDefaultAccounts()
        {
            // Clear existing users (for testing)
            Users.Clear();

            // Admin Account
            AddUser("admin", AuthService.HashPassword("admin123"), "System Administrator", "admin@fast.edu.pk", "admin");

            // Society Head Account
            AddUser("head", AuthService.HashPassword("head123"), "Ahmed Khan", "ahmed.khan@fast.edu.pk", "society_head");

            // Sample Student
            AddUser("student", AuthService.HashPassword("student123"), "Ali Hassan", "ali.hassan@fast.edu.pk", "student");

            Console.WriteLine("Default accounts created successfully!");
        }

        public static void LogActivity(int userId, string actionType, string description)
        {
            ActivityLogs.Add(new ActivityLog
            {
                LogId = ActivityLogs.Count + 1,
                UserId = userId,
                Action = actionType,
                Description = description,
                Timestamp = DateTime.Now
            });
        }
    }
}