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

    private const string SampleExpected = "24000";

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
        using var tr = new StringReader(SampleInput);
        var lines = GetLinesFromReader(tr);

        var result = _sut.SolvePartOne(lines);

        result.Should().Be(SampleExpected);
    }

    [Fact]
    public void DayOneTest_PartOneFileInput_ShouldReturnAnswer()
    {
        using var sr = new StreamReader("./inputs/dayone.txt");
        var lines = GetLinesFromReader(sr);
        
        var result = _sut.SolvePartOne(lines);

        result.Should().Be("73211");
    }

    [Fact]
    public void DayOneTest_PartTwoSampleInput_ShouldReturnAnswer()
    {
        using var tr = new StringReader(SampleInput);
        var lines = GetLinesFromReader(tr);

        var result = _sut.SolvePartTwo(lines);

        result.Should().Be("45000");
    }
    
    [Fact]
    public void DayOneTest_PartTwoFileInput_ShouldReturnAnswer()
    {
        using var tr = new StreamReader("./inputs/dayone.txt");
        var lines = GetLinesFromReader(tr);

        var result = _sut.SolvePartTwo(lines);

        result.Should().Be("213958");
    }
    
    private static string[] GetLinesFromReader(TextReader tr)
    {
        var lines = new List<string>();
        string? line = string.Empty;
        while (line != null)
        {
            lines.Add(line);
            line = tr.ReadLine();
        }

        return lines.ToArray()[1..];
    }
}