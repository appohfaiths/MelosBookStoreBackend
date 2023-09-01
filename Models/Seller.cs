namespace MelosBookStore.Models
{
    public class Seller: User
    {
        public required string ShopName { get; set; }
        public ICollection<BookSeller>? BookSellers { get; set; }
    }
}