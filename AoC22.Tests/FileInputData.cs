using AoC22.Solvers;

namespace AoC22.Tests;

internal class FileInputData : TheoryData<IAoCSolver, string, string, string>
{
    private const string BasePath = "./inputs/";
    
    public FileInputData()
    {
        Add(new Day01Solver(), $"{BasePath}day01.txt", "73211", "213958");
        Add(new Day02Solver(), $"{BasePath}day02.txt", "14531", "11258");
        Add(new Day03Solver(), $"{BasePath}day03.txt", "7821", "2752");
        Add(new Day04Solver(), $"{BasePath}day04.txt", "305", "811");
        Add(new Day05Solver(), $"{BasePath}day05.txt", "QNHWJVJZW", "BPCZJLFJW");
    }
}