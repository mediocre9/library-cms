namespace LibraryCMS.Config
{
    /// <summary>
    /// Database environment variables
    /// </summary>
    public class Config
    {
        private Config() { }

        private static readonly string HOST = "localhost";
        private static readonly string USER = "root";
        private static readonly string DATABASE = "library_cms";
        private static readonly string PASSWORD = "";

        public static readonly string ADDRESS =
            $"Server     = {HOST}    ;" +
            $"Database   = {DATABASE};" +
            $"Uid        = {USER}    ;" +
            $"Pwd        = {PASSWORD}";
    }
}
