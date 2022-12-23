using AoC22.Solvers;

namespace AoC22.Tests;

public class Day07SolverTests
{
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
    
    [Fact]
    public void PartOneSampleInput_ShouldReturnAnswer()
    {
        var sut = new Day07Solver();
        var expected = "95437";
        using var tr = new StringReader(SampleInput);
        var lines = tr.GetLinesFromReader();

        var result = sut.SolvePartOne(lines);

        result.Should().Be(expected);
    }
}