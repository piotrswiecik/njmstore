namespace NjmStore.ProductService.Models;

public class Artist
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public virtual required List<Album> Albums { get; set; } = [];
}