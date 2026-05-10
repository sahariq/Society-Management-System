using System;

namespace SocietiesManagementSystem
{
    public class AnnouncementModel
    {
        public int AnnouncementId { get; set; }
        public int SocietyId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int PostedBy { get; set; }
        public DateTime PostDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
