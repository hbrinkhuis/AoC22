using System.Text;
using System.Text.RegularExpressions;

namespace AoC22.Solvers;

public class Day05Solver : IAoCSolver
{
    private Stack<char>[] _stacks;
    
    public string SolvePartOne(string[] input)
    {
        var (numberOfStacks, stackLine) = ParseStacksAndBoxes(input);

        // go forward from the stack line to the bottom of the file, parsing and executing all instructions
        foreach (var line in input.AsSpan(stackLine + 2))
        {
            var match = Regex.Match(line, @"^move (\d+) from (\d+) to (\d+)");
            if (!match.Success || match.Groups.Count < 4)
            {
                continue;
            }
            
            var numberOfBoxes = int.Parse(match.Groups[1].Value);
            var source = int.Parse(match.Groups[2].Value) - 1;
            var target = int.Parse(match.Groups[3].Value) - 1;

            // move boxes according to instructions
            for (var i = 0; i < numberOfBoxes; i++)
            {
                _stacks[target].Push(_stacks[source].Pop());
            }
        }
        
        return GetResult(numberOfStacks);
    }

    public string SolvePartTwo(string[] input)
    {
        var (numberOfStacks, stackLine) = ParseStacksAndBoxes(input);
        
        // go forward from the stack line to the bottom of the file, parsing and executing all instructions
        foreach (var line in input.AsSpan(stackLine + 2))
        {
            var match = Regex.Match(line, @"^move (\d+) from (\d+) to (\d+)");
            if (!match.Success || match.Groups.Count < 4)
            {
                continue;
            }
            
            var numberOfBoxes = int.Parse(match.Groups[1].Value);
            var source = int.Parse(match.Groups[2].Value) - 1;
            var target = int.Parse(match.Groups[3].Value) - 1;
            
            var boxes = new char[numberOfBoxes];
            for (var i = 0; i < numberOfBoxes; i++)
            {
                boxes[i] = _stacks[source].Pop();
            }

            // flip result for every instruction
            var reversePopOrder = boxes.Reverse();
            
            // move boxes according to instructions
            foreach (var box in reversePopOrder)
            {
                _stacks[target].Push(box);
            }
        }
        return GetResult(numberOfStacks);
    }

    private static (int numberOfStacks, int index) FindNumberOfStacksAndLineNumber(string[] input)
    {
        foreach(var (line, i) in input.Select((line, i) => (line, i)))
        {
            var matches = Regex.Matches(line, @" \d ");
            
            if (matches.Count > 0)
            {
                return (int.Parse(matches.Last().Value), i);
            }
        }

        return (0, 0);
    }

    private string GetResult(int numberOfStacks)
    {
        // get all boxes on top of the stacks as a string
        var result = new StringBuilder();
        for (var i = 0; i < numberOfStacks; i++)
        {
            result.Append(_stacks[i].Peek());
        }

        return result.ToString();
    }

    private (int numberOfStacks, int stackLine) ParseStacksAndBoxes(string[] input)
    {
        var (numberOfStacks, stackLine) = FindNumberOfStacksAndLineNumber(input);

        // initialize stacks
        _stacks = new Stack<char>[numberOfStacks];
        for (var i = 0; i < numberOfStacks; i++)
        {
            _stacks[i] = new Stack<char>();
        }

        // go back from the stack line to the top of the file, parsing all boxes
        for (var i = stackLine - 1; i >= 0; i--)
        {
            var line = input[i].AsSpan();
            for (var j = 1; j < line.Length; j += 4)
            {
                var asciiValue = (int) line[j];
                if (asciiValue >= 65 && asciiValue <= 90)
                {
                    _stacks[j / 4].Push(line[j]);
                }
            }
        }

        return (numberOfStacks, stackLine);
    }
}