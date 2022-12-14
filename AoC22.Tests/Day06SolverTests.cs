using AoC22.Solvers;

namespace AoC22.Tests;

public class Day06SolverTests
{
    private class PartOneData : TheoryData<IAoCSingleSolver<int>, string, int>
    {
        public PartOneData()
        {
            Add(new Day06Solver(), "mjqjpqmgbljsphdztnvjfqwrcgsmlb", 7);
            Add(new Day06Solver(), "bvwbjplbgvbhsrlpgdmjqwftvncz", 5);
            Add(new Day06Solver(), "nppdvjthqldpwncqszvftbrmjlhg", 6);
            Add(new Day06Solver(), "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10);
            Add(new Day06Solver(), "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11);
        }
    }

    private class PartTwoData : TheoryData<IAoCSingleSolver<int>, string, int>
    {
        public PartTwoData()
        {
            Add(new Day06Solver(), "mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19);
            Add(new Day06Solver(), "bvwbjplbgvbhsrlpgdmjqwftvncz", 23);
            Add(new Day06Solver(), "nppdvjthqldpwncqszvftbrmjlhg", 23);
            Add(new Day06Solver(), "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29);
            Add(new Day06Solver(), "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26);
        }
    }

    [Theory]
    [ClassData(typeof(PartOneData))]
    public void Day06Solver_PartOne_SampleInput_ShouldReturnAnswer(IAoCSingleSolver<int> solver, string input, int expected)
    {
        var result = solver.SolvePartOne(input);
        
        result.Should().Be(expected);
    }

    [Fact]
    public void Day06Solver_PartOne_FileInput_ShouldReturnAnswer()
    {
        var sut = new Day06Solver();
        using var tr = new StreamReader("./inputs/day06.txt");
        var input = tr.ReadToEnd();
        var result = sut.SolvePartOne(input);
        
        result.Should().Be(1238);
    }
    
    [Theory]
    [ClassData(typeof(PartTwoData))]
    public void Day06Solver_PartTwo_SampleInput_ShouldReturnAnswer(IAoCSingleSolver<int> solver, string input, int expected)
    {
        var result = solver.SolvePartTwo(input);
        
        result.Should().Be(expected);
    }
    
    [Fact]
    public void Day06Solver_PartTwo_FileInput_ShouldReturnAnswer()
    {
        var sut = new Day06Solver();
        using var tr = new StreamReader("./inputs/day06.txt");
        var input = tr.ReadToEnd();
        var result = sut.SolvePartTwo(input);
        
        result.Should().Be(3037);
    }
}