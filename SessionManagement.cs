namespace SocietiesManagementSystem
{
    public static class SessionManagement
    {
        public static int UserId { get; set; }
        public static string Role { get; set; }
        public static SessionUser CurrentUser { get; set; } = new SessionUser();
    }

    public class SessionUser
    {
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}