using NjmStore.DbSeeder.DTO;

namespace NjmStore.DbSeeder.Services;

public interface ISpotifyScraper
{
    public Task<SpotifyAccessToken> GetAccessTokenAsync(SpotifyClientCredentials clientCredentials);
    public Task GetAlbumRecommendations(string genre);
    public Task GetAlbumTracks(string albumId);
}