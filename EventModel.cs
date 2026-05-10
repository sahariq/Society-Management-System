using System;

namespace SocietiesManagementSystem
{
    public class EventModel
    {
        public int EventId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Venue { get; set; }
        public int Capacity { get; set; }
        public int SocietyId { get; set; }
        public string ApprovalStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
