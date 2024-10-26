using Spectre.Console;

namespace AdamsMultiTool.CLI;

internal static class Program
{
    private static void Main(string[] args)
    {
        AnsiConsole.Markup("[underline red]Hello[/] World!");
    }
}