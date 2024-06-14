using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
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
        
        var token = await JsonSerializer.DeserializeAsync<SpotifyAccessToken>(
            await res.Content.ReadAsStreamAsync());
        
        if (token != null)
        {
            AnsiConsole.MarkupLine("Access token received successfully.");
            return token;
        }
    
        throw new Exception("Failed to get access token from Spotify API.");
    }

    /// <summary>
    /// Fetch album recommendations using Spotify track recommender API.
    /// </summary>
    /// <param name="genre">Genre name (identifier).</param>
    /// <param name="token">Spotify bearer access token.</param>
    /// <param name="limit">Maximum number of recommendations.</param>
    /// <returns>List of recommended album DTOs.</returns>
    public async Task<List<SpotifyAlbumObject?>> GetAlbumRecommendationsAsync(string genre, SpotifyAccessToken token,
        int limit)
    {
        var apiClient = factory.CreateClient("SpotifyApi");
        apiClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        var queryBuilder = new StringBuilder();
        queryBuilder.Append("recommendations?seed_genres=");
        queryBuilder.Append(genre);
        queryBuilder.Append("&limit=");
        queryBuilder.Append(limit);
        
        var res = await apiClient.GetAsync(queryBuilder.ToString());

        if (res.StatusCode != HttpStatusCode.OK)
        {
            throw new HttpRequestException($"HTTP request failed with status code {res.StatusCode}.");
        }
        
        var responseContent = JsonNode.Parse(await res.Content.ReadAsStringAsync());

        if (responseContent == null)
        {
            throw new InvalidOperationException("Recommendation API response content is null.");
        }
        
        var tracks = responseContent["tracks"]?.AsArray();

        if (tracks == null)
        {
            throw new InvalidOperationException("Recommendation API response contains empty track list.");
        }

        return tracks
            .Select(track => track?["album"].Deserialize<SpotifyAlbumObject>())
            .Select(albumDto => albumDto)
            .ToList();
    }

    public Task GetAlbumTracks(string albumId)
    {
        throw new NotImplementedException();
    }
}