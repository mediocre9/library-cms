using MySql.Data.MySqlClient;
using System.Data;
using LibraryCMS.Models;
using Services;

namespace LibraryCMS.Controller
{
    public class PublisherController<T> : IController<Publisher>
    {
        public PublisherController() { }

        public void AddRecord(Publisher publisher)
        {
            string query = $"INSERT INTO publisher (name, address) VALUES ('{publisher.name}', '{publisher.address}')";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void DeleteRecord(string data)
        {
            string query = $"DELETE FROM publisher WHERE id='{data}'";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable GetAllRecords()
        {
            string query = $"SELECT * FROM publisher";
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
            string query = $"SELECT * FROM publisher WHERE lower(name)='{name}'";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        public void UpdateRecord(string name)
        {
            throw new NotImplementedException();
        }
    }
}
