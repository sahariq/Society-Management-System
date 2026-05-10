using System;

namespace SocietiesManagementSystem
{
    public class MembershipModel
    {
        public int MembershipId { get; set; }
        public int StudentId { get; set; }
        public int SocietyId { get; set; }
        public string Role { get; set; }
        public DateTime JoinDate { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
