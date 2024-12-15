namespace Day1;

class Program
{
    static async Task Main()
    {
        try
        {
            const string inputFilePath = @"input.txt";
            if (!File.Exists(inputFilePath))
            {
                throw new ArgumentException($"Input file {inputFilePath} does not exist.");
            }
        
            var inputLines = await File.ReadAllLinesAsync(inputFilePath);
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
            
            var sortedLeft = numbersPairs.Select(pair => pair.Left).OrderBy(x => x).ToList();
            var sortedRight = numbersPairs.Select(pair => pair.Right).OrderBy(x => x).ToList();

            var result = sortedLeft
                .Zip(sortedRight, (left, right) => Math.Abs(left - right))
                .Sum();
            
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Console.ReadLine();        
    }
}