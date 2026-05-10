using System;
using System.Security.Cryptography;
using System.Text;

namespace SocietiesManagementSystem
{
    public static class SessionManager
    {
        public static int UserId { get; set; }
        public static string Role { get; set; } = "";
        public static string FullName { get; set; } = "";
    }

    public class AuthService
    {

        public bool Login(string usernameOrEmail, string password, string role)
        {
            string hashedPassword = HashPassword(password);
            var user = DatabaseHelper.GetUser(usernameOrEmail, hashedPassword);

            if (user != null && user.Role.Equals(role, StringComparison.OrdinalIgnoreCase))
            {
                SessionManager.UserId = user.UserId;
                SessionManager.Role = user.Role;
                SessionManager.FullName = user.FullName;
                return true;
            }

            return false;
        }

        // Register method for future use
        public bool Register(string username, string email, string password, string fullName, string role = "student")
        {
            string hashedPassword = HashPassword(password);

            // Check if user already exists
            if (DatabaseHelper.Users.Any(u => u.Username == username || u.Email == email))
            {
                return false;
            }

            DatabaseHelper.AddUser(username, hashedPassword, fullName, email);
            return true;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes)
                    sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}