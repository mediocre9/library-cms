using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11939_Major_Agmnt_.models
{
    public struct Publisher
    {
        public string name { get; set; }
        public string address { get; set; }
        public Publisher(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public Publisher(Publisher publisher)
        {
            this.name = publisher.name;
            this.address = publisher.address;
        }
    }
}
