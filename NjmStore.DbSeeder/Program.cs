// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using NjmStore.DbSeeder.Commands;
using NjmStore.DbSeeder.Services;
using Spectre.Console.Cli;
using Spectre.Console.Cli.Extensions.DependencyInjection;

// Spectre.Console.Cli.Extensions.DependencyInjection package is used to provide DI
var services = new ServiceCollection();

services.AddHttpClient("SpotifyApi", c =>
{
    c.BaseAddress = new Uri("https://api.spotify.com/v1/");
});

services.AddHttpClient("SpotifyAuth", c =>
{
    c.BaseAddress = new Uri("https://accounts.spotify.com/api/");
});

services.AddSingleton<ISpotifyScraper, SpotifyHttpScraper>();

using var registrar = new DependencyInjectionRegistrar(services);

var app = new CommandApp(registrar);

app.Configure(cfg =>
{
    cfg.AddCommand<SeedCommand>("seed");
    cfg.AddCommand<GetSpotifyTokenCommand>("get-token");
    cfg.AddCommand<GetSpotifyRecommendationsCommand>("get-recommendations");
});

return app.Run(args);