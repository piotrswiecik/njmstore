namespace NjmStore.ProductService.Models;

public class Collection
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public virtual required ICollection<Album> Albums { get; set; } = [];
}