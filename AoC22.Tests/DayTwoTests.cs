using AoC22.Solvers;

namespace AoC22.Tests;

public class DayTwoTests
{
    private const string SampleInput = @"A Y
B X
C Z";

    private const string SampleExpected = "15";

    private readonly IAoCSolver _sut;

    public DayTwoTests()
    {
        _sut = new DayTwoSolver();
    }
    
    [Fact]
    public void DayTwoTest_NoInput_ShouldThrowArgumentNullException()
    {
         var action = () => _sut.SolvePartOne(Array.Empty<string>());

         action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DayTwoTest_PartOneSampleInput_ShouldReturnAnswer()
    {
        using var tr = new StringReader(SampleInput);
        var lines = tr.GetLinesFromReader();

        var result = _sut.SolvePartOne(lines);

        result.Should().Be(SampleExpected);
    }

    [Fact]
    public void DayTwoTest_PartOneFileInput_ShouldReturnAnswer()
    {
        using var sr = new StreamReader("./inputs/daytwo.txt");
        var lines = sr.GetLinesFromReader();
        
        var result = _sut.SolvePartOne(lines);

        result.Should().Be("73211");
    }

    [Fact]
    public void DayOneTest_PartTwoSampleInput_ShouldReturnAnswer()
    {
        using var tr = new StringReader(SampleInput);
        var lines = tr.GetLinesFromReader();

        var result = _sut.SolvePartTwo(lines);

        result.Should().Be("45000");
    }
    
    [Fact]
    public void DayOneTest_PartTwoFileInput_ShouldReturnAnswer()
    {
        using var tr = new StreamReader("./inputs/daytwo.txt");
        var lines = tr.GetLinesFromReader();

        var result = _sut.SolvePartTwo(lines);

        result.Should().Be("213958");
    }
}