using System;
using System.Data;
using System.Text;
using System.Security.Cryptography;
using Microsoft.Data.Sqlite;

namespace SocietiesManagementSystem
{
    

    public static class SessionManagement
    {
        public static int CurrentUserId { get; private set; }
        public static string CurrentRole { get; private set; } = "";
        public static string CurrentFullName { get; private set; } = "";
        public static bool IsLoggedIn => CurrentUserId > 0;

        public static void SetSession(int userId, string role, string fullName)
        {
            CurrentUserId = userId;
            CurrentRole = role.ToLower();
            CurrentFullName = fullName;
        }

        public static void ClearSession()
        {
            CurrentUserId = 0;
            CurrentRole = "";
            CurrentFullName = "";
        }

        public static User? GetCurrentUser()
        {
            return DatabaseHelper.GetUserById(CurrentUserId);
        }
    }

    public class AuthService
    {
        public bool Login(string usernameOrEmail, string password, string requestedRole)
        {
            if (string.IsNullOrWhiteSpace(usernameOrEmail) || string.IsNullOrWhiteSpace(password))
                return false;

            string hashedPassword = HashPassword(password);
            var user = GetUser(usernameOrEmail, hashedPassword);

            if (user != null && 
                user.Role.Equals(requestedRole, StringComparison.OrdinalIgnoreCase) &&
                user.Status == "active")
            {
                SessionManagement.SetSession(user.UserId, user.Role, user.FullName);
                DatabaseHelper.LogActivity(user.UserId, "LOGIN", $"User logged in as {user.Role}");
                return true;
            }

            return false;
        }

        public bool Register(string username, string email, string password, string fullName, string role = "student")
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                return false;

            if (UserExists(username, email))
                return false;

            string hashedPassword = HashPassword(password);
            return AddUser(username, hashedPassword, fullName, email, role);
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        public static void Logout()
        {
            if (SessionManagement.IsLoggedIn)
            {
                DatabaseHelper.LogActivity(SessionManagement.CurrentUserId, "LOGOUT", "User logged out");
            }
            SessionManagement.ClearSession();
        }

        public static User? GetUser(string usernameOrEmail, string passwordHash)
        {
            string query = @"SELECT UserId, Username, PasswordHash, FullName, Email, Role, Status 
                            FROM Users 
                            WHERE (Username = @login OR Email = @login) 
                            AND PasswordHash = @hash 
                            AND Status = 'active'";

            var parameters = new[]
            {
                new SqliteParameter("@login", usernameOrEmail),
                new SqliteParameter("@hash", passwordHash)
            };

            var dt = DatabaseHelper.ExecuteQuery(query, parameters);
            
            if (dt.Rows.Count > 0)
            {
                var row = dt.Rows[0];
                return new User
                {
                    UserId = Convert.ToInt32(row["UserId"]),
                    Username = row["Username"].ToString() ?? "",
                    PasswordHash = row["PasswordHash"].ToString() ?? "",
                    FullName = row["FullName"].ToString() ?? "",
                    Email = row["Email"].ToString() ?? "",
                    Role = row["Role"].ToString() ?? "",
                    Status = row["Status"].ToString() ?? ""
                };
            }
            
            return null;
        }

        public static User? GetUserById(int userId)
        {
            return DatabaseHelper.GetUserById(userId);
        }

        private static bool UserExists(string username, string email)
        {
            string query = "SELECT COUNT(*) FROM Users WHERE Username = @u OR Email = @e";
            var parameters = new[]
            {
                new SqliteParameter("@u", username),
                new SqliteParameter("@e", email)
            };
            
            var dt = DatabaseHelper.ExecuteQuery(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        private static bool AddUser(string username, string passwordHash, string fullName, string email, string role)
        {
            string query = @"INSERT INTO Users (Username, PasswordHash, FullName, Email, Role, Status) 
                            VALUES (@u, @h, @n, @e, @r, 'active')";
            
            var parameters = new[]
            {
                new SqliteParameter("@u", username),
                new SqliteParameter("@h", passwordHash),
                new SqliteParameter("@n", fullName),
                new SqliteParameter("@e", email),
                new SqliteParameter("@r", role)
            };
            
            int result = DatabaseHelper.ExecuteNonQuery(query, parameters);
            
            if (result > 0)
            {
                string getIdQuery = "SELECT last_insert_rowid()";
                var dt = DatabaseHelper.ExecuteQuery(getIdQuery);
                int userId = Convert.ToInt32(dt.Rows[0][0]);
                DatabaseHelper.LogActivity(userId, "REGISTER", $"New {role} account created");
                return true;
            }
            
            return false;
        }
    }
}