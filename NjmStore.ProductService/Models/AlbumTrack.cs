namespace NjmStore.ProductService.Models;

public class AlbumTrack
{
    public Guid TrackId { get; set; }
    public Guid AlbumId { get; set; }
    public int TrackNumber { get; set; } // join table payload
}