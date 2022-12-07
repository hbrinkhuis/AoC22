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
    public string SolvePartOne(string[] input)
    {
        var elves = ParseElves(input);

        var maxCaloricValue = elves.MaxBy(c => c.CaloricValue).CaloricValue;

        return maxCaloricValue.ToString();
    }

    public string SolvePartTwo(string[] input)
    {
        var elves = ParseElves(input);

        var topThree = elves.OrderByDescending(c => c.CaloricValue).Take(3);
        return topThree.Sum(c => c.CaloricValue).ToString();
    }
    
    private static IEnumerable<Elve> ParseElves(IEnumerable<string> input)
    {
        var lines = input.ToList();

        var elves = new List<Elve>();
        var currentElve = new Elve();
        foreach (var line in lines)
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
        
        // add last Elve
        elves.Add(currentElve);

        return elves;
    }
}