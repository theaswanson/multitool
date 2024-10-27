using System.Globalization;
using AdamsMultiTool.Core.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace AdamsMultiTool.CLI.Commands;

public class TimeCommand(TimeService timeService) : Command<TimeCommand.Settings>
{
    public class Settings : CommandSettings
    {
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        var currentTime = timeService.GetCurrentTimeString(TimeFormat.Default);
        
        AnsiConsole.WriteLine(currentTime.ToString(CultureInfo.InvariantCulture));
        return 0;
    }
}