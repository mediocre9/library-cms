namespace LibraryCMS.Models
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
