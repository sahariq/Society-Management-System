using System;

namespace SocietiesManagementSystem
{
    public class ActivityLog
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Action { get; set; }
        public DateTime Timestamp { get; set; }
        public string UserType { get; set; }
    }
}
