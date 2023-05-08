namespace LibraryCMS.Models
{
    public class BookIssue
    {
        public string authorId { get; set; }

        public string memberId { get; set; }

        public string dueDate { get; set; }


        public BookIssue(BookIssue book)
        {
            authorId = book.authorId;
            memberId = book.memberId;
            dueDate = book.dueDate;
        }

        public BookIssue(string authorId, string memberId, string dueDate)
        {
            this.authorId = authorId;
            this.memberId = memberId;
            this.dueDate = dueDate;
        }
    }
}
