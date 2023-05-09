using LibraryCMS.Models;
using MySql.Data.MySqlClient;
using Services;
using System.Data;

namespace LibraryCMS.Controller
{
    public class AuthorController<T> : IController<Author>
    {
        public AuthorController() { }

        public void AddRecord(Author author)
        {
            string query = $"INSERT INTO author (name, age, gender, email, contact, bio) VALUES ('{author.name}', '{author.age}', '{author.gender}', '{author.email}', '{author.contact}', '{author.bio}')";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void DeleteRecord(string email)
        {
            string query = $"DELETE FROM author WHERE email='{email}'";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable GetAllRecords()
        {
            string query = $"SELECT name, age, gender, email, contact, bio FROM author";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        public DataTable SearchRecord(string name)
        {
            string query = $"SELECT * FROM author WHERE lower(name)='{name}'";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        public void UpdateRecord(string id)
        {
            
        }
    }
}
