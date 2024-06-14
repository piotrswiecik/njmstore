namespace NjmStore.ProductService.Models;

public class Review
{
    public Guid Id { get; set; }
    public required string Author { get; set; }
    public required string Headline { get; set; }
    public required string Content { get; set; }
    public required int Rating { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public required Album Album { get; set; }
}