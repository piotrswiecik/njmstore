using System.Text.Json.Serialization;

namespace NjmStore.DbSeeder.DTO;

public record SpotifySimplifiedArtistObject
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }
}