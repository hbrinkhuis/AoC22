using AoC22.Solvers;

namespace AoC22.Tests;

public class DayOneTests
{
    private const string SampleInput = @"1000
2000
3000

4000

5000
6000

7000
8000
9000

10000";

    private readonly IAoCSolver _sut;

    public DayOneTests()
    {
        _sut = new DayOneSolver();
    }
    
    [Fact]
    public void DayOneTest_NoInput_ShouldThrowArgumentNullException()
    {
         var action = () => _sut.SolvePartOne(Array.Empty<string>());

         action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DayOneTest_PartOneSampleInput_ShouldReturnAnswer()
    {
        const string expected = "24000";
        using var sr = new StringReader(SampleInput);

        var lines = new List<string>();
        string? line = string.Empty;
        while (line != null)
        {
            lines.Add(line);
            line = sr.ReadLine();
        }
        
        var result = _sut.SolvePartOne(lines.ToArray()[1..]);

        result.Should().Be(expected);
    }
}