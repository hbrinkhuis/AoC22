using AoC22.Solvers;

namespace AoC22.Tests;

public class SolverTests
{
    
    [Theory]
    [ClassData(typeof(SampleInputData))]
    public void PartOneSampleInput_ShouldReturnAnswer(IAoCSolver solver, string input, string expected, string _)
    {
        using var tr = new StringReader(input);
        var lines = tr.GetLinesFromReader();

        var result = solver.SolvePartOne(lines);

        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(FileInputData))]
    public void PartOneFileInput_ShouldReturnAnswer(IAoCSolver solver, string input, string expected, string _)
    {
        using var tr = new StreamReader(input);
        var lines = tr.GetLinesFromReader();

        var result = solver.SolvePartOne(lines);

        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(SampleInputData))]
    public void PartTwoSampleInput_ShouldReturnAnswer(IAoCSolver solver, string input, string _, string expected)
    {
        using var tr = new StringReader(input);
        var lines = tr.GetLinesFromReader();

        var result = solver.SolvePartTwo(lines);

        result.Should().Be(expected);
    }

    [Theory]
    [ClassData(typeof(FileInputData))]
    public void PartTwoFileInput_ShouldReturnAnswer(IAoCSolver solver, string input, string _, string expected)
    {
        using var tr = new StreamReader(input);
        var lines = tr.GetLinesFromReader();

        var result = solver.SolvePartTwo(lines);

        result.Should().Be(expected);
    }
}