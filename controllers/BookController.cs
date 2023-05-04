using _11939_Major_Agmnt_.models;
using _11939_Major_Agmnt_.service;
using MySql.Data.MySqlClient;
using System.Data;
using System.Xml.Linq;

namespace _11939_Major_Agmnt_.controllers
{
    public class BookController<T> : IController<Book>
    {
        public BookController() { }

        public void addRecord(Book book)
        {
            string query = $"INSERT INTO book (author_fk_id, publisher_fk_id, title, price) VALUES ('{int.Parse(book.authorId)}','{int.Parse(book.publisherId)}','{book.title}', '{int.Parse(book.price)}')";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public void deleteRecord(int id)
        {
            string query = $"DELETE FROM book WHERE id='{id}'";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);
            connection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read()) { }
            connection.Close();
        }

        public DataTable getAllRecords()
        {
            string query = "SELECT `a`.`name`, `a`.`email`, `a`.`contact`, `a`.`gender`, `p`.`name`, `p`.`address`, `b`.`title`, `b`.`price` FROM author a JOIN book b ON a.id=b.author_fk_id JOIN publisher p ON p.id=b.publisher_fk_id";
            MySqlConnection connection = DBConnection.getInstance();
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
            MySqlConnection connection = DBConnection.getInstance();
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
            MySqlConnection connection = DBConnection.getInstance();
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

        public DataTable searchRecord(string data)
        {
            string query = $"SELECT * FROM book WHERE title='{data}'";
            MySqlConnection connection = DBConnection.getInstance();
            MySqlCommand mySqlCommand = new(query, connection);

            MySqlDataAdapter mySqlDataAdapter = new();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            DataTable dataTable = new();
            mySqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public void updateRecord(string name)
        {
            throw new NotImplementedException();
        }
    }
}
