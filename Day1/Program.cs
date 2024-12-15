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
        
            var input = await File.ReadAllLinesAsync(inputFilePath);
            var leftList = new int[input.Length];
            var rightList = new int[input.Length];
            var index = 0;
            var result = 0;    
            
            // an input line looks like this: "97924   12015"
            foreach (var line in input)
            {
                var numbers = line.Split("   ");
                leftList[index] = int.Parse(numbers[0]);
                rightList[index] = int.Parse(numbers[1]);
                index++;
            }
            
            Array.Sort(leftList);
            Array.Sort(rightList);

            for (int i = 0; i < input.Length; i++)
            {
                result += Math.Abs(leftList[i] - rightList[i]); 
            }
            
            Console.WriteLine(result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
        
        Console.ReadLine();        
    }
}