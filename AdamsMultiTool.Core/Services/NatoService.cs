using System.Text.RegularExpressions;

namespace AdamsMultiTool.Core.Services;

public partial class NatoService
{
    private readonly Dictionary<char, string> _alphabet = new()
    {
        { 'A', "Alfa" },
        { 'B', "Bravo" },
        { 'C', "Charlie" },
        { 'D', "Delta" },
        { 'E', "Echo" },
        { 'F', "Foxtrot" },
        { 'G', "Golf" },
        { 'H', "Hotel" },
        { 'I', "India" },
        { 'J', "Juliett" },
        { 'K', "Kilo" },
        { 'L', "Lima" },
        { 'M', "Mike" },
        { 'N', "November" },
        { 'O', "Oscar" },
        { 'P', "Papa" },
        { 'Q', "Quebec" },
        { 'R', "Romeo" },
        { 'S', "Sierra" },
        { 'T', "Tango" },
        { 'U', "Uniform" },
        { 'V', "Victor" },
        { 'W', "Whiskey" },
        { 'X', "Xray" },
        { 'Y', "Yankee" },
        { 'Z', "Zulu" },
        { '1', "One" },
        { '2', "Two" },
        { '3', "Three" },
        { '4', "Four" },
        { '5', "Five" },
        { '6', "Six" },
        { '7', "Seven" },
        { '8', "Eight" },
        { '9', "Nine" },
        { '0', "Zero" }
    };

    public string[] ConvertStringToNatoWords(string? input)
    {
        input = NonAlphaNumericRegex().Replace(input ?? string.Empty, string.Empty);
        input = input.Trim().ToUpper();
        
        if (string.IsNullOrWhiteSpace(input))
        {
            return [];
        }
        
        var words = input.Split(" ");

        var natoWords = new List<string>();

        for (var index = 0; index < words.Length; index++)
        {
            var word = words[index];
            var characters = word.ToCharArray();

            var foundWords = characters
                .Select(character => _alphabet.TryGetValue(character, out var natoWord) ? natoWord : string.Empty)
                .Where(foundWord => !string.IsNullOrEmpty(foundWord));

            natoWords.AddRange(foundWords);
            
            if (index < words.Length - 1)
            {
                natoWords.Add(string.Empty);
            }
        }

        return natoWords.ToArray();
    }

    [GeneratedRegex("[^a-zA-Z0-9 ]")]
    private static partial Regex NonAlphaNumericRegex();
}