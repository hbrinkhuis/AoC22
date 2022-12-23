using AoC22.Solvers;

namespace AoC22.Tests;

public class Day07SolverTests
{
    private readonly Day07Solver _sut;

    private const string SampleInput = @"$ cd /
$ ls
dir a
14848514 b.txt
8504156 c.dat
dir d
$ cd a
$ ls
dir e
29116 f
2557 g
62596 h.lst
$ cd e
$ ls
584 i
$ cd ..
$ cd ..
$ cd d
$ ls
4060174 j
8033020 d.log
5626152 d.ext
7214296 k";

    private const string SampleInputExpectedPartOne = "95437";
    private const string SampleInputExpectedPartTwo = "24933642";

    public Day07SolverTests()
    {
        _sut = new Day07Solver();
    }

    [Fact]
    public void PartOneSampleInput_ShouldReturnAnswer()
    {
        using var tr = new StringReader(SampleInput);
        var lines = tr.GetLinesFromReader();

        var result = _sut.SolvePartOne(lines);

        result.Should().Be(SampleInputExpectedPartOne);
    }

    [Fact]
    public void PartOneFileInput_ShouldReturnAnswer()
    {
        using var fr = new StreamReader("./inputs/day07.txt");
        var lines = fr.GetLinesFromReader();

        var result = _sut.SolvePartOne(lines);

        result.Should().Be("144896");
    }
    
    [Fact]
    public void PartTwoSampleInput_ShouldReturnAnswer()
    {
        using var tr = new StringReader(SampleInput);
        var lines = tr.GetLinesFromReader();

        var result = _sut.SolvePartTwo(lines);

        result.Should().Be(SampleInputExpectedPartTwo);
    }
    
    [Fact]
    public void PartTwoFileInput_ShouldReturnAnswer()
    {
        using var fr = new StreamReader("./inputs/day07.txt");
        var lines = fr.GetLinesFromReader();

        var result = _sut.SolvePartTwo(lines);

        result.Should().Be("404395");
    }
    
}