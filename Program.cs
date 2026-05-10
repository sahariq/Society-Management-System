namespace SocietiesManagementSystem;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // Create default accounts on startup
        DatabaseHelper.CreateDefaultAccounts();

        Application.Run(new Form1());
    }  
}