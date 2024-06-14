using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace NjmStore.DbSeeder.Commands;

public class SpotifyGenericCommandSettings : CommandSettings
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