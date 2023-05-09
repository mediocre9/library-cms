using LibraryCMS.Models;
using MySql.Data.MySqlClient;
using Services;
using System.Data;


namespace LibraryCMS.Controller
{
    public class MemberController<T> : IController<Member>
    {
        public MemberController() { }

        public void AddRecord(Member member)
        {
            string query = $"INSERT INTO member (name, address) VALUES ('{member.name}', '{member.address}')";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void DeleteRecord(string data)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllRecords()
        {
            string query = $"SELECT * FROM member";
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
            string query = $"SELECT * FROM member WHERE lower(name)='{name}'";
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
