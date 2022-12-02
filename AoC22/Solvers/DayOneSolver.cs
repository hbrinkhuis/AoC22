namespace AoC22.Solvers;

public class DayOneSolver : IAoCSolver
{
    private struct Elve
    {
        public int CaloricValue;

        public Elve()
        {
            CaloricValue = 0;
        }
    }
    public string SolvePartOne(IEnumerable<string> input)
    {
        if (input == null || !input.Any())
            throw new ArgumentNullException(nameof(input));

        var elves = new List<Elve>();
        var currentElve = new Elve();
        foreach (var line in input)
        {
            if (string.IsNullOrEmpty(line))
            {
                elves.Add(currentElve);
                currentElve = new Elve();
                
            }
            else
            {
                if (int.TryParse(line, out var result))
                {
                    currentElve.CaloricValue += result;
                }
            }
        }

        var maxCaloricValue = elves.MaxBy(c => c.CaloricValue).CaloricValue;

        return maxCaloricValue.ToString();
    }
}