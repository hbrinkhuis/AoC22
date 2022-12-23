using System.Text.RegularExpressions;

namespace AoC22.Solvers;

public class Day07Solver : IAoCSolver
{
    public string SolvePartOne(string[] input)
    {
        var rootDir = ParseStatements(input[1..]); // ignore first line, since it's always 'cd /'

        var sum = 0;
        var _ = CalculateSum(rootDir, ref sum);

        return sum.ToString();
    }

    public string SolvePartTwo(string[] input)
    {
        var rootDir = ParseStatements(input[1..]); // ignore first line, since it's always 'cd /'
        
        List<int> directorySizes = new List<int>();
        var totalSize = GetDirectorySizes(rootDir, ref directorySizes);

        var target = 3e7 - (7e7 - totalSize);

        var result = directorySizes.Where(c => c >= target).Min();

        return result.ToString();
    }

    private static int GetDirectorySizes(Directory dir, ref List<int> directorySizes)
    {
        var currentLevelSum = 0;
        if (dir.SubDirectories.Any())
        {
            foreach (var subDir in dir.SubDirectories)
            {
                currentLevelSum += GetDirectorySizes(subDir, ref directorySizes);
            }
        }

        currentLevelSum += dir.Files.Sum(c => c.Size);
        
        directorySizes.Add(currentLevelSum);
        return currentLevelSum;
    }

    private static int CalculateSum(Directory rootDir, ref int sum)
    {
        var currentLevelSum = 0;
        if (rootDir.SubDirectories.Any())
        {
            foreach (var subDir in rootDir.SubDirectories)
            {
                currentLevelSum += CalculateSum(subDir, ref sum);
            }
        }

        currentLevelSum += rootDir.Files.Sum(c => c.Size);
        if (currentLevelSum <= 1e5)
        {
            sum += currentLevelSum;
        }
        
        return currentLevelSum;
    }

    private static Directory ParseStatements(string[] input)
    {
        var rootDir = new Directory {Name = "/"};
        var currentDir = rootDir;
        foreach (var line in input[1..])
        {
            var arguments = line.Split(' ');
            currentDir = arguments[0] switch
            {
                "$" =>
                    ParseCommand(arguments, currentDir),
                "dir" =>
                    ParseDirectory(arguments, currentDir),
                { } s when Regex.IsMatch(s, @"^\d+$") =>
                    ParseFile(arguments, currentDir),
                _ => throw new Exception("Unknown entry")
            };
        }

        return rootDir;
    }

    private static Directory ParseDirectory(string[] arguments, Directory currentDir)
    {
        currentDir.CreateSubDirectory(arguments[1]);
        return currentDir;
    }

    private static Directory ParseFile(string[] arguments, Directory currentDir)
    {
        if(!int.TryParse(arguments[0], out var size))
            throw new ArgumentException("File size is not a number");
        
        currentDir.Files.Add(new File {Size = size});
        return currentDir;
    }

    private static Directory ParseCommand(string[] arguments, Directory currentDir)
    {
        return arguments[1] switch
        {
            "cd" =>
                arguments[2] == ".."
                    ? currentDir.Parent
                    : currentDir.SubDirectories.Single(c => c.Name == arguments[2]),
            "ls" => currentDir,
            _ => throw new Exception("Unknown command"),
        };
    }

    private class Directory
    {
        public string Name { get; init; }
        
        public List<Directory> SubDirectories { get; } = new List<Directory>();

        public List<File> Files { get; set; } = new List<File>();
        
        public Directory Parent { get; set; }
        
        public void CreateSubDirectory(string directoryName)
        {
            var directory = new Directory {Name = directoryName, Parent = this};
            SubDirectories.Add(directory);
        }
    }

    private class File
    {
        public int Size { get; set; }
    }
}