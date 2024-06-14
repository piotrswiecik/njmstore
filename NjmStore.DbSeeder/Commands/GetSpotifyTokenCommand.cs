using NjmStore.DbSeeder.DTO;
using NjmStore.DbSeeder.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NjmStore.DbSeeder.Commands;

public class GetSpotifyTokenCommand(ISpotifyScraper scraper) : AsyncCommand<GetSpotifyTokenCommand.Settings>
{
    public sealed class Settings : SpotifyGenericCommandSettings
    {
    }
    
    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        AnsiConsole.MarkupLine("Requesting Spotify API token...");

        var res = await scraper.GetAccessTokenAsync(
            new SpotifyClientCredentials(
                ClientId: settings.ClientId,
                ClientSecret: settings.ClientSecret));

        if (!string.IsNullOrWhiteSpace(res.AccessToken))
        {
            AnsiConsole.MarkupLine("Token received successfully.");
            AnsiConsole.MarkupLine(res.AccessToken);
            return 0;
        }
        else
        {
            AnsiConsole.MarkupLine("Failed to get token from Spotify API.");
            return 1;
        }
        
        
    }
}