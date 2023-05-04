using _11939_Major_Agmnt_.config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11939_Major_Agmnt_.service
{
    public class DBConnection
    {
        public static MySqlConnection? instance;
        private static string
            databaseAddress =
            $"Server={Config.HOST};Database={Config.DATABASE};Uid={Config.USER};Pwd={Config.PASSWORD}";
        private DBConnection() { }

        public static MySqlConnection getInstance()
        {
            try
            {
                instance = new MySqlConnection(databaseAddress);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }

            return instance!;
        }
    }
}
