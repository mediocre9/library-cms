using LibraryCMS.Models;
using MySql.Data.MySqlClient;
using Services;
using System.Data;

namespace LibraryCMS.Controller
{
    public class BookIssueController<T> : IController<BookIssue>
    {
        public BookIssueController() { }

        public void AddRecord(BookIssue bookIssue)
        {
            string query = $"INSERT INTO book_issue (book_fk_id, member_fk_id, due_date) VALUES ('{int.Parse(bookIssue.authorId)}','{int.Parse(bookIssue.memberId)}','{bookIssue.dueDate}')";
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
            string query = "SELECT `b`.`title`, `b`.`price`, `m`.`name`, `m`.`address`, `bi`.`due_date`, `bi`.`issue_date` FROM book b JOIN book_issue bi ON b.id=bi.book_fk_id JOIN member m ON m.id=bi.member_fk_id;";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }


        public DataTable GetAllExpiredIssueBooks()
        {
            string query = "SELECT `b`.`title`, `b`.`price`, `m`.`name`, `m`.`address`, `bi`.`due_date`, `bi`.`issue_date`, \"Expired\" AS Status FROM book b JOIN book_issue bi ON b.id=bi.book_fk_id JOIN member m ON m.id=bi.member_fk_id WHERE CURRENT_DATE > bi.due_date;";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        // Serious code refactoring needed!
        public List<Dictionary<string, string>> GetMemberRecord()
        {
            string memberQuery = $"SELECT * FROM member;";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand memberCommand = new(memberQuery, connection);
            connection.Open();

            List<Dictionary<string, string>> members = new();

            var memberReader = memberCommand.ExecuteReader();

            while (memberReader.Read())
            {
                members.Add(
                    new Dictionary<string, string>
                    {
                        {memberReader[0].ToString()!, memberReader[1].ToString()!}
                    }
                );
            }

            return members;
        }

        public List<Dictionary<string, string>> GetBookRecord()
        {
            string bookQuery = $"SELECT * FROM book;";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand booksCommand = new(bookQuery, connection);
            connection.Open();

            List<Dictionary<string, string>> books = new();

            var booksReader = booksCommand.ExecuteReader();

            while (booksReader.Read())
            {
                books.Add(
                    new Dictionary<string, string>
                    {
                        {booksReader[0].ToString()!, booksReader[3].ToString()!}
                    }
                );
            }

            return books;
        }

        public DataTable SearchRecord(string id)
        {
            string query = $"SELECT * FROM book_issue WHERE id='{id}'";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new();
            mySqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void UpdateRecord(string name)
        {
            throw new NotImplementedException();
        }
    }
}
