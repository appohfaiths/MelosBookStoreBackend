namespace MelosBookStore.Models;

public class Review
{
    public int Id { get; set; }
    public required string ReviewerName { get; set; }
    public required string Comment { get; set; }
    public int ? Rating { get; set; }
    public required int BookId { get; set; }
    public required Book Book { get; set; }
}