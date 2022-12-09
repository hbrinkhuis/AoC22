namespace AoC22.Solvers;

public class Day06Solver : IAoCSingleSolver<int>
{
    public int SolvePartOne(string input)
    {
        for (var i = 3; i < input.Length; i++)
        {
            var block = input.AsSpan(i - 3, 4);

            var hasDuplicateCharacter = CheckForDuplicateCharacter(block);

            if (!hasDuplicateCharacter)
            {
                return i + 1;
            }
        }
        
        return int.MaxValue;
    }

    private static bool CheckForDuplicateCharacter(ReadOnlySpan<char> block)
    {
        for (var i = 0; i < block.Length; i++)
        {
            for (var j = i + 1; j < block.Length; j++)
            {
                if (block[i] == block[j])
                {
                    return true;
                }
            }
        }

        return false;
    }

    public int SolvePartTwo(string input)
    {
        throw new NotImplementedException();
    }
}