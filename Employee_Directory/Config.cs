namespace Employee_Directory
{
    internal static class Config
    {
        internal static readonly string Base = AppDomain.CurrentDomain.BaseDirectory;

        public static string ConnStr       = $"Data Source={Path.Combine(Base, "employee.db")}";
        public static string LogPath       = Path.Combine(Base, "logs", "app.log");
        public static string PhotosDir     = Path.Combine(Base, "photos");
        public static string NullImagePath = Path.Combine(Base, "photos", "NullImage.jpg");
    }
}
