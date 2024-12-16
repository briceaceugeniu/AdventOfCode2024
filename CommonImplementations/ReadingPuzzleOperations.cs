namespace CommonImplementations;

public static class ReadingPuzzleOperations
{
    public static async Task<string[]> GetInputLinesAsync(string fileName = "input.txt")
    {
        if (!File.Exists(fileName))
        {
            throw new ArgumentException($"Input file {fileName} does not exist.");
        }
        
        return await File.ReadAllLinesAsync(fileName);
    }
}