using System;

namespace SocietiesManagementSystem
{
    public class TaskModel
    {
        public int Id { get; set; }
        public int SocietyId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AssignedTo { get; set; }
        public int AssignedBy { get; set; }
        public DateTime Deadline { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
