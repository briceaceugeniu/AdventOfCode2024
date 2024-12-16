using CommonImplementations;

namespace Day1;
class Program
{
    static async Task Main()
    {
        try
        {
            var inputLines = await ReadingPuzzleOperations.GetInputLinesAsync();
            var numbersPairs = new List<(int Left, int Right)>();
            
            // an input line looks like this: "97924   12015"
            foreach (var line in inputLines)
            {
                var numbers = line.Split(["   "], StringSplitOptions.RemoveEmptyEntries);
                if (numbers.Length != 2 ||
                    !int.TryParse(numbers[0], out int left) ||
                    !int.TryParse(numbers[1], out int right))
                {
                    throw new ArgumentException($"Invalid numbers: {string.Join(", ", numbers)}"); 
                }
                
                numbersPairs.Add((left, right));
            }
            
            // Part 1
            var sortedLeft = numbersPairs.Select(pair => pair.Left).OrderBy(x => x).ToList();
            var sortedRight = numbersPairs.Select(pair => pair.Right).OrderBy(x => x).ToList();

            var result1 = sortedLeft
                .Zip(sortedRight, (left, right) => Math.Abs(left - right))
                .Sum();
            
            Console.WriteLine($"Part 1: {result1}");
            
            // Part 2
            var groupedRight = sortedRight
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());
            
            var groupedLeft = sortedLeft
                .GroupBy(x => x)
                .ToDictionary(x => x.Key, x => x.Count());

            var result2 = 0;
            foreach (var group in groupedLeft)
            {
                var valRight = groupedRight.GetValueOrDefault(group.Key, 0);
                result2 += group.Key * group.Value * valRight;
            }

            Console.WriteLine($"Part 2: {result2}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Console.ReadLine();        
    }
}