using System.ComponentModel;
using NjmStore.DbSeeder.DTO;
using NjmStore.DbSeeder.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NjmStore.DbSeeder.Commands;

public class GetSpotifyTokenCommand(ISpotifyScraper scraper) : AsyncCommand<GetSpotifyTokenCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [Description("Client ID for Spotify API.")]
        [CommandOption("--client-id")]
        public required string ClientId { get; set; }

        [Description("Client secret for Spotify API.")]
        [CommandOption("--client-secret")]
        public required string ClientSecret { get; set; }

        // CommandOptions can't be simply set as required in Spectre.Console.Cli
        // follow https://github.com/spectreconsole/spectre.console/discussions/538
        public override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(ClientId))
            {
                return ValidationResult.Error("Client ID is required");
            }

            if (string.IsNullOrWhiteSpace(ClientSecret))
            {
                return ValidationResult.Error("Client secret is required");
            }

            return base.Validate();
        }
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