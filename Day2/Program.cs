using CommonImplementations;

namespace Day2;

static class Program
{
    static async Task Main()
    {
        try
        {
            var inputLines = await ReadingPuzzleOperations.GetInputLinesAsync();
            var counter = 0;

            foreach (var inputLine in inputLines)
            {
                var reportLine = inputLine
                    .Split([" "], StringSplitOptions.RemoveEmptyEntries)
                    .StringToIntArray();
                if (reportLine.Length < 2)
                {
                    throw new Exception($"Invalid input: {inputLine}");
                }

                if (AreNumbersIncreasing(reportLine) || AreNumbersDecreasing(reportLine))
                {
                    counter++;
                }
            }
            Console.WriteLine($"Part 1: {counter}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Console.ReadLine();
    }

    private static int[] StringToIntArray(this string[] input) => input.Select(int.Parse).ToArray();

    private static bool AreNumbersMatchingCondition(int[] numbers, Func<int, int, bool> comparison)
    {
        for (int i = numbers.Length - 1; i > 0; i--)
        {
            if (!comparison(numbers[i], numbers[i - 1]) || Math.Abs(numbers[i] - numbers[i - 1]) > 3)
            {
                return false;
            }
        }
        return true;
    }
    
    private static bool AreNumbersIncreasing(int[] numbers) =>
        AreNumbersMatchingCondition(numbers, (current, previous) => current > previous);
    private static bool AreNumbersDecreasing(int[] numbers) =>
        AreNumbersMatchingCondition(numbers, (current, previous) => current < previous);
}