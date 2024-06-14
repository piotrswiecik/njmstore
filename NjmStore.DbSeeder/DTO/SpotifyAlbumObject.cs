using System.Text.Json.Serialization;

namespace NjmStore.DbSeeder.DTO;

public record SpotifyAlbumObject
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("images")]
    public required List<SpotifyImageObject> Images { get; init; }
    
    [JsonPropertyName("release_date")]
    public required string ReleaseDate { get; init; }
    
    [JsonPropertyName("release_date_precision")]
    public required string ReleaseDatePrecision { get; init; }
    
    [JsonPropertyName("total_tracks")]
    public required int TotalTracks { get; init; }
    
    [JsonPropertyName("artists")]
    public required List<SpotifySimplifiedArtistObject> Artists { get; init; }
}