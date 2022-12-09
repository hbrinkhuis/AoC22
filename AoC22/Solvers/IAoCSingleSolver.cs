namespace AoC22.Solvers;

public interface IAoCSingleSolver<T>
{
    T SolvePartOne(string input);
    
    T SolvePartTwo(string input);
}