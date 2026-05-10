using System;

namespace SocietiesManagementSystem
{
    public class EventRegistrationModel
    {
        public int RegistrationId { get; set; }
        public int StudentId { get; set; }
        public int EventId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string TicketNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
