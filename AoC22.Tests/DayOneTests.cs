using AoC22.Solvers;

namespace AoC22.Tests;

public class DayOneTests
{
    [Fact]
    public void DayOneTest_NoInput_ShouldThrowArgumentNullException()
    {
        IAoCSolver solver = new DayOneSolver();

         var action = () => solver.Solve(string.Empty);

         action.Should().Throw<ArgumentNullException>();
    }
}