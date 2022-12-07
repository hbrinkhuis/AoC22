using AoC22.Solvers;

namespace AoC22.Tests;

internal class FileInputData : TheoryData<IAoCSolver, string, string, string>
{
    private const string BasePath = "./inputs/";
    
    public FileInputData()
    {
        Add(new DayOneSolver(), $"{BasePath}dayone.txt", "73211", "213958");
        Add(new DayTwoSolver(), $"{BasePath}daytwo.txt", "14531", "11258");
    }
}