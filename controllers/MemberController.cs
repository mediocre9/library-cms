using _11939_Major_Agmnt_.models;
using _11939_Major_Agmnt_.service;
using MySql.Data.MySqlClient;
using System.Data;


namespace _11939_Major_Agmnt_.controllers
{
    public class MemberController<T> : IController<Member>
    {
        public MemberController() { }

        public void addRecord(Member member)
        {
            string query = $"INSERT INTO member (name, address) VALUES ('{member.name}', '{member.address}')";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void deleteRecord(int id)
        {
            string query = $"DELETE FROM member WHERE id='{id}'";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable getAllRecords()
        {
            string query = $"SELECT * FROM member";
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
            string query = $"SELECT * FROM member WHERE name='{name}'";
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
