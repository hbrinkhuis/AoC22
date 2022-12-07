using System.IO.Compression;
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
        var totalValue = 0;
        for(var i = 0; i < input.Length; i+=3)
        {
            var firstLine = input[i];
            var secondLine = input[i + 1];
            var thirdLine = input[i + 2];

            var duplicateItem = firstLine.First(c => secondLine.Contains(c) && thirdLine.Contains(c));
            totalValue += CalculateValueOfDuplicateItem(duplicateItem);
        }

        return totalValue.ToString();
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