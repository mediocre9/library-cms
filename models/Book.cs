using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11939_Major_Agmnt_.models
{
    public struct Book
    {
        public string title { get; set; }
        public string price { get; set; }

        public string authorId { get; set; }

        public string publisherId { get; set; }


        public Book(Book book)
        {
            this.title = book.title;
            this.price = book.price;
            this.authorId = book.authorId;
            this.publisherId = book.publisherId;
            
        }

        public Book(string title, string price, string authorId, string publisherId)
        {
            this.title = title;
            this.price = price;
            this.authorId = authorId;
            this.publisherId = publisherId;


        }
    }
}
