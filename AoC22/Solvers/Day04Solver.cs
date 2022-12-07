namespace AoC22.Solvers;

public class Day04Solver : IAoCSolver
{
    public string SolvePartOne(string[] input)
    {
        var fullyOverlapped = 0;
        foreach (var line in input)
        {
            var sections = line.Split(',');
            var (sectionA, sectionB) = ParseSections(sections);

            if (CheckIfFullyOverlapped(sectionA, sectionB))
            {
                fullyOverlapped++;    
            }
        }

        return fullyOverlapped.ToString();
    }

    public string SolvePartTwo(string[] input)
    {
        var overlapped = 0;
        foreach (var line in input)
        {
            var sections = line.Split(',');
            var (sectionA, sectionB) = ParseSections(sections);

            if (CheckIfOverlapped(sectionA, sectionB))
            {
                overlapped++;    
            }
        }

        return overlapped.ToString();
    }

    private static bool CheckIfFullyOverlapped(Section a, Section b) => 
        (a.Start <= b.Start && a.End >= b.End) || (b.Start <= a.Start && b.End >= a.End);
    
    private static bool CheckIfOverlapped(Section a, Section b) => 
        (a.Start <= b.Start && a.End >= b.Start) || (b.Start <= a.Start && b.End >= a.Start);

    private static (Section, Section) ParseSections(IReadOnlyList<string> sectionStrings)
    {
        var sectionA = sectionStrings[0].Split('-');
        var sectionB = sectionStrings[1].Split('-');
        return (
            new Section {Start = int.Parse(sectionA[0]), End = int.Parse(sectionA[1])},
            new Section {Start = int.Parse(sectionB[0]), End = int.Parse(sectionB[1])});
    }
    
    private struct Section
    {
        public int Start { get; set; }

        public int End { get; set; }
    }
}