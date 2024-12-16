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
            var pattern = @"mul\((\d{1,3},\d{1,3})\)";
            
            var options = RegexOptions.Multiline;
            var result = 0;

            foreach (Match m in Regex.Matches(inputText, pattern, options))
            {
                Console.WriteLine($"Value: {m.Value} Index: {m.Index} >> {m.Groups[1].Value}");
                var numbers = m.Groups[1].Value.Split(",");

                if (numbers.Length != 2
                    || !int.TryParse(numbers[0], out var number1)
                    || !int.TryParse(numbers[1], out var number2))
                {
                    throw new ArgumentException($"Invalid numbers: {string.Join(", ", numbers)}");
                }
                
                result += number1 * number2;
            }

            Console.WriteLine($"Part 1: {result}");
            
            Console.ReadLine();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}