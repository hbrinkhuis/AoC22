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
         var action = () => _sut.SolvePartOne(string.Empty);

         action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void DayOneTest_PartOneSampleInput_ShouldReturnAnswer()
    {
        const string expected = "24000";

        var result = _sut.SolvePartOne(SampleInput);

        result.Should().Be(expected);
    }
}