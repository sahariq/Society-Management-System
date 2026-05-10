using System;

namespace SocietiesManagementSystem
{
    public class TaskComment
    {
        public int Id { get; set; }
        public int TaskId { get; set; }
        public string Comment { get; set; }
        public int CommentedBy { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
