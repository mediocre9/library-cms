using MySql.Data.MySqlClient;
using LibraryCMS.Config;

namespace Services
{
    /// <summary>
    /// A singleton database connection to communicate 
    /// with only single open instance.
    /// </summary>
    /// 
    /// <remarks>
    /// Use pool connections for database, if there are 
    /// multiple connections.
    /// </remarks>
    public class DBConnection
    {
        /// <returns>
        /// Returns a single <code>MySqlConnection</code> instance.
        /// </returns>
        public static MySqlConnection GetInstance()
        {
            try
            {
                instance = new MySqlConnection(Config.ADDRESS);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return instance!;
        }

        private DBConnection() { }

        private static MySqlConnection? instance;
    }
}
