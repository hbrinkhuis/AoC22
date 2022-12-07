using AoC22.Solvers;

namespace AoC22.Tests;

internal class SampleInputData : TheoryData<IAoCSolver, string, string, string>
{
    public SampleInputData()
    {
        Add(
            new Day01Solver(), 
            "1000\n2000\n3000\n\n4000\n\n5000\n6000\n\n7000\n8000\n9000\n\n10000", 
            "24000", "45000");
        Add(new Day02Solver(), "A Y\nB X\nC Z", "15", "12");
        Add(new Day03Solver(), 
            "vJrwpWtwJgWrhcsFMMfFFhFp\njqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL\nPmmdzqPrVvPwwTWBwg\n" +
            "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn\nttgJtRGJQctTZtZT\nCrZsJsPPZsGzwwsLwLmpwMDw",
            "157", "70");
        Add(new Day04Solver(), "2-4,6-8\n2-3,4-5\n5-7,7-9\n2-8,3-7\n6-6,4-6\n2-6,4-8", 
            "2", "4");
        Add(new Day05Solver(), @"    [D]    
[N] [C]    
[Z] [M] [P]
 1   2   3 

move 1 from 2 to 1
move 3 from 1 to 3
move 2 from 2 to 1
move 1 from 1 to 2", "CMZ", "220");
    }
}