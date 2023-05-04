using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11939_Major_Agmnt_.models
{
    public struct Member
    {
        public string name { get; set; }
        public string address { get; set; }
        public Member(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public Member(Member member)
        {
            this.name = member.name;
            this.address = member.address;
        }
    }
}
