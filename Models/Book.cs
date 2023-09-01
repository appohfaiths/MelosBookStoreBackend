namespace MelosBookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Description { get; set; }
        public required float Price { get; set; }
        public string ? ImageUrl { get; set; }
        public ICollection<BookAuthor>? BookAuthors { get; set; }
        public ICollection<BookSeller>? BookSellers { get; set; }
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }


}