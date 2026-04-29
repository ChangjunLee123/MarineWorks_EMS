namespace Employee_Directory
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Employee_Directory.DB.DBservice.Initialize(); // DB파일 이니셜라이즈 
            Application.Run(new Employee_Directory.Forms.LoginForm());
        }
    }
}