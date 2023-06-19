namespace HomeworkPustok.Models
{
    public class BookTag
    {
        public int BookId { get; set; }
        public Book book { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }

    }
}
