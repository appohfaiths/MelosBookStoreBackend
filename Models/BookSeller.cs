namespace MelosBookStore.Models
{
    public class BookSeller{
        public int BookId { get; set; }
        public required Book Book { get; set; }
        public int SellerId { get; set; }
        public required Seller Seller { get; set; }
    }
}