using AdamsMultiTool.Core.Services;
using Spectre.Console;
using Spectre.Console.Cli;

namespace AdamsMultiTool.CLI.Commands;

public class NatoCommand(NatoService natoService) : Command<NatoCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "<input>")]
        public string Input { get; set; } = "";
    }

    public override int Execute(CommandContext context, Settings settings)
    {
        natoService.ConvertStringToNatoWords(settings.Input)
            .ToList()
            .ForEach(AnsiConsole.WriteLine);
        
        return 0;
    }
}