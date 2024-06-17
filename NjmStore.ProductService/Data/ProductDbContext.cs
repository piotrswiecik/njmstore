using Microsoft.EntityFrameworkCore;
using NjmStore.ProductService.Models;

namespace NjmStore.ProductService.Data;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Album> Albums { get; set; }
    public DbSet<AlbumTrack> AlbumTracks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Collection> Collections { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Track> Tracks { get; set; }
    public DbSet<Variant> Variants { get; set; }
    
}