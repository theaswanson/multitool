using AdamsMultiTool.CLI.Commands;
using AdamsMultiTool.CLI.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console.Cli;

namespace AdamsMultiTool.CLI;

internal static class Program
{
    private static async Task Main(string[] args) =>
        await BuildApp(GetServices()).RunAsync(args);

    private static ServiceCollection GetServices() => [];

    private static CommandApp BuildApp(IServiceCollection services)
    {
        var app = new CommandApp(new TypeRegistrar(services));

        app.Configure(config => config.AddCommand<HelloCommand>("hello"));

        return app;
    }
}