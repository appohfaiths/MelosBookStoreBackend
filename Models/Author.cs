namespace MelosBookStore.Models
{
    public class Author
    {
        public int Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}