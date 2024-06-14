using NjmStore.DbSeeder.DTO;

namespace NjmStore.DbSeeder.Services;

public interface ISpotifyScraper
{
    public Task<SpotifyAccessToken> GetAccessTokenAsync(SpotifyClientCredentials clientCredentials);
    public Task<List<SpotifyAlbumObject?>> GetAlbumRecommendationsAsync(string genre, SpotifyAccessToken token, int limit);
    public Task GetAlbumTracks(string albumId);
}