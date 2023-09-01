namespace MelosBookStore.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public ICollection<Book>? Books { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}