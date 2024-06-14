namespace NjmStore.ProductService.Models;

public class Track
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public string? Url { get; set; }
    
    // skip navigation + track number is stored on join table
    public virtual required ICollection<Album> Albums { get; set; } = [];
    public virtual required ICollection<AlbumTrack> AlbumTracks { get; set; } = [];
}