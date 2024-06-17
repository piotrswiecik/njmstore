using Microsoft.EntityFrameworkCore;

namespace NjmStore.ProductService.Models;

[PrimaryKey(nameof(TrackId), nameof(AlbumId))]
public class AlbumTrack
{
    public Guid TrackId { get; set; }
    public Guid AlbumId { get; set; }
    public int TrackNumber { get; set; } // join table payload
}