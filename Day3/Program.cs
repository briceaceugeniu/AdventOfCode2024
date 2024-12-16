using System.Text.RegularExpressions;
using CommonImplementations;

namespace Day3;

class Program
{
    static async Task Main()
    {
        try
        {
            var inputText = await ReadingPuzzleOperations.GetInputTextAsync();
            var inputTextWithoutDonts = RemoveDonts(inputText);
            
            Console.WriteLine($"Part 1: {CalculateMulFunctions(inputText)}");
            Console.WriteLine($"Part 2: {CalculateMulFunctions(inputTextWithoutDonts)}");
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private static int CalculateMulFunctions(string inputText)
    {
        var pattern = @"mul\((\d{1,3},\d{1,3})\)";
        var options = RegexOptions.Multiline;
        var result = 0;
        
        foreach (Match m in Regex.Matches(inputText, pattern, options))
        {
            var numbers = m.Groups[1].Value.Split(",");

            if (numbers.Length != 2
                || !int.TryParse(numbers[0], out var number1)
                || !int.TryParse(numbers[1], out var number2))
            {
                throw new ArgumentException($"Invalid numbers: {string.Join(", ", numbers)}");
            }
                
            result += number1 * number2;
        }
        return result;
    }
    
    private static string RemoveDonts(string inputText)
    {
        var pattern = @"don't\(\).*?do\(\)";
        RegexOptions options = RegexOptions.Singleline | RegexOptions.Multiline;
        return Regex.Replace(inputText, pattern, string.Empty, options);
    }
}