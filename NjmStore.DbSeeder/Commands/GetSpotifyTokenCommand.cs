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
        
        AnsiConsole.MarkupLine($"Token: {res.AccessToken}");

        return 0;
    }
}