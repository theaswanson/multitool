using Spectre.Console;
using Spectre.Console.Cli;

namespace AdamsMultiTool.CLI.Commands;

public class HelloCommand : Command<HelloCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[Name]")]
        public string? Name { get; set; }
    }


    public override int Execute(CommandContext context, Settings settings)
    {
        var name = settings.Name != null ? Markup.Escape(settings.Name) : "stranger";
        
        AnsiConsole.MarkupLine($"Hello, [blue]{name}[/]!");
        return 0;
    }
}