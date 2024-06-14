namespace NjmStore.ProductService.Models;

public class Album
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public virtual required ICollection<Artist> Artists { get; set; } = [];
    public required string CoverImageUrl { get; set; }
    public required DateOnly ReleaseDate { get; set; }
    public required AlbumGenre Genre { get; set; }
    public virtual required ICollection<Review> Reviews { get; set; } = [];
    public virtual required ICollection<Variant> Variants { get; set; } = [];
    public virtual required ICollection<Collection> Collections { get; set; } = [];
    
    // skip navigation + track number is stored on join table
    public virtual required ICollection<Track> Tracks { get; set; } = [];
    public virtual required ICollection<AlbumTrack> AlbumTracks { get; set; } = [];
}