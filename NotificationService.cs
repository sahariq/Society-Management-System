using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SocietiesManagementSystem
{
    public static class NotificationService
    {
        private static List<Notification> Notifications = new List<Notification>();
        
        public class Notification
        {
            public int Id { get; set; }
            public int UserId { get; set; }
            public string Title { get; set; } = "";
            public string Message { get; set; } = "";
            public DateTime CreatedAt { get; set; }
            public bool IsRead { get; set; }
            public string Type { get; set; } = "info"; // success, warning, error, info
        }
        
        public static void SendNotification(int userId, string title, string message, string type = "info")
        {
            var notification = new Notification
            {
                Id = Notifications.Count + 1,
                UserId = userId,
                Title = title,
                Message = message,
                CreatedAt = DateTime.Now,
                IsRead = false,
                Type = type
            };
            
            Notifications.Add(notification);
            
            // Show popup if user is current user
            if (SessionManagement.CurrentUserId == userId)
            {
                ShowPopupNotification(title, message, type);
            }
            
            // Log notification
            DatabaseHelper.LogActivity(0, "NOTIFICATION_SENT", $"To User {userId}: {title}");
        }
        
        public static void ShowPopupNotification(string title, string message, string type)
        {
            // Use appropriate icon based on type
            MessageBoxIcon icon = MessageBoxIcon.Information;
            switch (type)
            {
                case "success": icon = MessageBoxIcon.Information; break;
                case "warning": icon = MessageBoxIcon.Warning; break;
                case "error": icon = MessageBoxIcon.Error; break;
                default: icon = MessageBoxIcon.Information; break;
            }
            
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }
        
        public static List<Notification> GetUserNotifications(int userId)
        {
            return Notifications.Where(n => n.UserId == userId).OrderByDescending(n => n.CreatedAt).ToList();
        }
        
        public static void MarkAsRead(int notificationId)
        {
            var notif = Notifications.FirstOrDefault(n => n.Id == notificationId);
            if (notif != null) notif.IsRead = true;
        }
    }
}