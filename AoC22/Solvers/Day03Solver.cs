using System.Text;

namespace AoC22.Solvers;

public class Day03Solver : IAoCSolver
{
    public string SolvePartOne(string[] input)
    {
        var totalValue = 0;
        foreach (var line in input)
        {
            var compartmentLength = line.Length / 2;
            var firstCompartment = line[..compartmentLength];
            var secondCompartment = line[compartmentLength..];

            var duplicateItem = firstCompartment.First(secondCompartment.Contains);
            totalValue += CalculateValueOfDuplicateItem(duplicateItem);
        }

        return totalValue.ToString();
    }

    public string SolvePartTwo(string[] input)
    {
        throw new NotImplementedException();
    }

    private static int CalculateValueOfDuplicateItem(char duplicate)
    {
        var tableValue = (int) duplicate;
        return tableValue switch
        {
            >= 97 and <= 122 => tableValue - 96,
            >= 65 and <= 90 => tableValue - 38,
            _ => 0
        };
    }
}