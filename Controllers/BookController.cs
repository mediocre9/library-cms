using LibraryCMS.Models;
using MySql.Data.MySqlClient;
using Services;
using System.Data;

namespace LibraryCMS.Controller
{
    public class BookController<T> : IController<Book>
    {
        public BookController() { }

        public void AddRecord(Book book)
        {
            string query = $"INSERT INTO book (author_fk_id, publisher_fk_id, title, price) VALUES ('{int.Parse(book.authorId)}','{int.Parse(book.publisherId)}','{book.title}', '{int.Parse(book.price)}')";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void DeleteRecord(string data)
        {
            string query = $"DELETE FROM book WHERE id='{data}'";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable GetAllRecords()
        {
            string query = "SELECT `a`.`name`, `a`.`email`, `a`.`contact`, `a`.`gender`, `p`.`name`, `p`.`address`, `b`.`title`, `b`.`price` FROM author a JOIN book b ON a.id=b.author_fk_id JOIN publisher p ON p.id=b.publisher_fk_id";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable data = new();
            mySqlDataAdapter.Fill(data);
            return data;
        }

        // Serious code refactoring needed!
        public List<Dictionary<string, string>> getAuthorRecord()
        {
            string authorQuery = $"SELECT * FROM author";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand authorCommand = new(authorQuery, connection);
            connection.Open();

            List<Dictionary<string, string>> authors = new List<Dictionary<string, string>>();
            
            var authorReader = authorCommand.ExecuteReader();

            while (authorReader.Read())
            {
                authors.Add(
                    new Dictionary<string, string>
                    {
                        {authorReader[0].ToString()!, authorReader[1].ToString()!}
                    }
                );
            }

            return authors; 
        }

        public List<Dictionary<string, string>> getPublisherRecord()
        {
            string authorQuery = $"SELECT * FROM publisher";
            MySqlConnection connection = DBConnection.GetInstance();
            MySqlCommand publisherCommand = new(authorQuery, connection);
            connection.Open();

            List<Dictionary<string, string>> publishers = new List<Dictionary<string, string>>();

            var publisherReader = publisherCommand.ExecuteReader();

            while (publisherReader.Read())
            {
                publishers.Add(
                    new Dictionary<string, string>
                    {
                        {publisherReader[0].ToString()!, publisherReader[1].ToString()!}
                    }
                );
            }

            return publishers;
        }

        public DataTable SearchRecord(string data)
        {
            string query = $"SELECT * FROM book WHERE lower(title)='{data}'";
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
