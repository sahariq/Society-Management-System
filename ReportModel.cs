using System;

namespace SocietiesManagementSystem
{
    public class ReportModel
    {
        public int TotalStudents { get; set; }
        public int TotalSocieties { get; set; }
        public int TotalEvents { get; set; }
        public string MostActiveSociety { get; set; }
        public int MostActiveSocietyEvents { get; set; }
        public int MostActiveSocietyMembers { get; set; }
    }
}
