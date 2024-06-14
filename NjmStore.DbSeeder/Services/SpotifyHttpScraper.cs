using System.Net.Http.Headers;
using System.Text.Json;
using NjmStore.DbSeeder.DTO;
using Spectre.Console;

namespace NjmStore.DbSeeder.Services;

public class SpotifyHttpScraper(IHttpClientFactory factory) : ISpotifyScraper
{
    /// <summary>
    /// Get access token from Spotify API using client credentials flow.
    /// </summary>
    /// <param name="clientCredentials">Client ID and client secret.</param>
    public async Task<SpotifyAccessToken> GetAccessTokenAsync(SpotifyClientCredentials clientCredentials)
    {
        var authClient = factory.CreateClient("SpotifyAuth");
        var content = new FormUrlEncodedContent(new Dictionary<string, string>()
        {
            { "grant_type", "client_credentials" }
        });
        var payload = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(
            $"{clientCredentials.ClientId}:{clientCredentials.ClientSecret}"));
        authClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", payload);
        var res = await authClient.PostAsync("token", content);
        
        AnsiConsole.MarkupLine(await res.Content.ReadAsStringAsync());
        
        var token = await JsonSerializer.DeserializeAsync<SpotifyAccessToken>(
            await res.Content.ReadAsStreamAsync());
        
        if (token != null)
        {
            return token;
        }
    
        throw new Exception("Failed to get access token from Spotify API.");
    }

    public Task GetAlbumRecommendations(string genre)
    {
        throw new NotImplementedException();
    }

    private async Task<SpotifyTrackObject[]> GetTrackRecommendations(string genre)
    {
        throw new NotImplementedException();
    }

    public Task GetAlbumTracks(string albumId)
    {
        throw new NotImplementedException();
    }
}