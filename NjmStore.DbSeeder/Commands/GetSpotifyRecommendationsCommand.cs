using NjmStore.DbSeeder.DTO;
using NjmStore.DbSeeder.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NjmStore.DbSeeder.Commands;

public class GetSpotifyRecommendationsCommand(ISpotifyScraper scraper) : AsyncCommand<GetSpotifyRecommendationsCommand.Settings>
{
    public sealed class Settings : SpotifyGenericCommandSettings
    {
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        AnsiConsole.MarkupLine("Requesting Spotify API token...");

        var token = await scraper.GetAccessTokenAsync(new SpotifyClientCredentials(
            settings.ClientId, settings.ClientSecret));

        var albums = await scraper.GetAlbumRecommendationsAsync("rock", token, 1);

        var testAlbum = albums[0];

        var tracks = await scraper.GetAlbumTracksAsync(testAlbum!.Id, token);
        
        AnsiConsole.MarkupLine(tracks[0].ToString());
        
        return 0;
    }
}