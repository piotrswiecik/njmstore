namespace NjmStore.ProductService.Models;

public class Variant
{
    public Guid Id { get; set; }
    public required AlbumFormat Format { get; set; }
    public required float Price { get; set; }
    public required int Stock { get; set; }
    public required Album Album { get; set; }
}