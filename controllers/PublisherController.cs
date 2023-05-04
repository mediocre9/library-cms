using _11939_Major_Agmnt_.service;
using _11939_Major_Agmnt_.models;
using MySql.Data.MySqlClient;
using System.Data;

namespace _11939_Major_Agmnt_.controllers
{
    public class PublisherController<T> : IController<Publisher>
    {
        public PublisherController() { }

        public void addRecord(Publisher publisher)
        {
            string query = $"INSERT INTO publisher (name, address) VALUES ('{publisher.name}', '{publisher.address}')";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void deleteRecord(int id)
        {
            string query = $"DELETE FROM publisher WHERE id='{id}'";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable getAllRecords()
        {
            string query = $"SELECT * FROM publisher";
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
            string query = $"SELECT * FROM publisher WHERE name='{name}'";
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
