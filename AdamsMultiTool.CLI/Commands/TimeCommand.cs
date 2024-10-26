using System.Globalization;
using Spectre.Console;
using Spectre.Console.Cli;

namespace AdamsMultiTool.CLI.Commands;

public class TimeCommand(TimeProvider timeProvider) : Command<TimeCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var currentTime = timeProvider.GetLocalNow();
        
        AnsiConsole.WriteLine(currentTime.ToString(CultureInfo.InvariantCulture));
        return 0;
    }
}