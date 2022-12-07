﻿using AoC22.Solvers;

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
            "157", string.Empty);
    }
}