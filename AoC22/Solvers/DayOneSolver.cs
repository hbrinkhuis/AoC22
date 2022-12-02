namespace AoC22.Solvers;

public class DayOneSolver : IAoCSolver
{
    public string SolvePartOne(IEnumerable<string> input)
    {
        if (input == null || !input.Any())
            throw new ArgumentNullException(nameof(input));
        return string.Empty;
    }
}