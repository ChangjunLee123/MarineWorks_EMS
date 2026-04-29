namespace Employee_Directory.Helpers
{
    internal static class Logger
    {
        public static string CurrentUser { get; set; } = "unknown";

        private static readonly string LogPath = Config.LogPath;

        public static void Info(string message)  => Write("INFO",  message);
        public static void Error(string message) => Write("ERROR", message);

        private static void Write(string level, string message)
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(LogPath)!);
                File.AppendAllText(LogPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{level}] [{CurrentUser}] {message}{Environment.NewLine}");
            }
            catch
            {
                // 로그 기록 실패는 무시 (로그 때문에 앱이 죽으면 안 됨)
            }
        }
    }
}
