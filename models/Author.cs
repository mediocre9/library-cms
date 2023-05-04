using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11939_Major_Agmnt_.models
{
    public struct Author
    {
        public string name { get; set; }
        public int age { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string contact { get; set; }

        public string bio { get; set; }

        public Author(Author model)
        {
            this.name = model.name;
            this.age = model.age;
            this.email = model.email;
            this.contact = model.contact;
            this.gender = model.gender;
            this.bio = model.bio;
        }
        public Author(string name, int age, string gender, string email, string contact, string bio) {
            this.name = name;
            this.age = age;
            this.email = email;
            this.contact = contact;
            this.gender = gender;
            this.bio = bio;
        }
    }
}
