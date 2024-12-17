using System.ComponentModel;
using CommonImplementations;

namespace Day4;

class Program
{
    static async Task Main()
    {
        try
        {
            var inputText = await ReadingPuzzleOperations.GetInputTextAsync();
            
            var inputArray = inputText
                .Split('\n')
                .Select(line => line.ToCharArray())
                .ToArray();
            
            var part1Counter = 0;
            var part2Counter = 0;

            for (int y = 0; y < inputArray.Length; y++)
            {
                for (int x = 0; x < inputArray[y].Length; x++)
                {
                    if (MatchWest(x, inputArray[y]))  part1Counter++;
                    if (MatchEast(x, inputArray[y]))  part1Counter++;
                    if (MatchNorth(x, y, inputArray)) part1Counter++;
                    if (MatchSouth(x, y, inputArray)) part1Counter++;
                    if (MatchNWest(x, y, inputArray)) part1Counter++;
                    if (MatchNEast(x, y, inputArray)) part1Counter++;
                    if (MatchSWest(x, y, inputArray)) part1Counter++;
                    if (MatchSEast(x, y, inputArray)) part1Counter++;
                    
                    if (MatchXMas(x, y, inputArray)) part2Counter++;
                }
            }

            Console.WriteLine($"Part 1: {part1Counter}");
            Console.WriteLine($"Part 2: {part2Counter}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    
    private static bool MatchXMas(int iX, int iY, char[][] array)
    {
        try
        {
            var first = array[iX][iY].ToString() + array[iX + 1][iY + 1] + array[iX + 2][iY + 2];
            var second = array[iX + 2][iY].ToString() + array[iX + 1][iY + 1] + array[iX][iY + 2];
            
            return first is "MAS" or "SAM" && second is "MAS" or "SAM";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchWest(int iX, char[] array)
    {
        try
        {
            return array[iX].ToString() + 
                   array[iX - 1] + 
                   array[iX - 2] +
                   array[iX - 3] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchEast(int iX, char[] array)
    {
        try
        {
            return array[iX].ToString() + 
                   array[iX + 1] + 
                   array[iX + 2] +
                   array[iX + 3] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchNorth(int iX, int iY, char[][] array)
    {
        try
        {
            return array[iY][iX].ToString() + 
                   array[iY - 1][iX] + 
                   array[iY - 2][iX] +
                   array[iY - 3][iX] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchSouth(int iX, int iY, char[][] array)
    {
        try
        {
            return array[iY][iX].ToString() + 
                   array[iY + 1][iX] + 
                   array[iY + 2][iX] +
                   array[iY + 3][iX] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchNWest(int iX, int iY, char[][] array)
    {
        try
        {
            return array[iY][iX].ToString() + 
                   array[iY - 1][iX - 1] + 
                   array[iY - 2][iX - 2] +
                   array[iY - 3][iX - 3] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchNEast(int iX, int iY, char[][] array)
    {
        try
        {
            return array[iY][iX].ToString() + 
                   array[iY - 1][iX + 1] + 
                   array[iY - 2][iX + 2] +
                   array[iY - 3][iX + 3] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchSWest(int iX, int iY, char[][] array)
    {
        try
        {
            return array[iY][iX].ToString() + 
                   array[iY + 1][iX - 1] + 
                   array[iY + 2][iX - 2] +
                   array[iY + 3][iX - 3] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
    
    private static bool MatchSEast(int iX, int iY, char[][] array)
    {
        try
        {
            return array[iY][iX].ToString() + 
                   array[iY + 1][iX + 1] + 
                   array[iY + 2][iX + 2] +
                   array[iY + 3][iX + 3] == "XMAS";
        }
        catch (IndexOutOfRangeException)
        {
            return false;
        }
    }
}