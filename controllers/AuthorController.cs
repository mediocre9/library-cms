
using _11939_Major_Agmnt_.models;
using _11939_Major_Agmnt_.service;
using MySql.Data.MySqlClient;
using System.Data;

namespace _11939_Major_Agmnt_.controllers
{
    public class AuthorController<T> : IController<Author>
    {
        public AuthorController() { }

        public void addRecord(Author author)
        {
            string query = $"INSERT INTO author (name, age, gender, email, contact, bio) VALUES ('{author.name}', '{author.age}', '{author.gender}', '{author.email}', '{author.contact}', '{author.bio}')";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void deleteRecord(int id)
        {
            string query = $"DELETE FROM author WHERE id='{id}'";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable getAllRecords()
        {
            string query = $"SELECT * FROM author";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        public DataTable searchRecord(string name)
        {
            string query = $"SELECT * FROM author WHERE name='{name}'";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        public void updateRecord(string name)
        {
            throw new NotImplementedException();
        }
    }
}
