using System.Text.Json.Serialization;

namespace NjmStore.DbSeeder.DTO;

public record SpotifyTrackObject
{
    public required string Id { get; init; }
    
    public required double DurationMs { get; init; }
    
    public required string Name { get; init; }
    
    public required string Uri { get; init; }
}