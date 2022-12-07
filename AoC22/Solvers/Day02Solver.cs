namespace AoC22.Solvers;

public class Day02Solver : IAoCSolver
{
    public string SolvePartOne(string[] input)
    {
        var finalScore = (from line in input
            let opponentHand = ParseOpponentHand(line[0])
            let hand = line[2] switch
            {
                'X' => Hand.Rock,
                'Y' => Hand.Paper,
                'Z' => Hand.Scissor,
                _ => throw new IndexOutOfRangeException("Don't know what '{b}' is.")
            }
            select CalculateScore(opponentHand, hand))
            .Sum();

        return finalScore.ToString();
    }

    public string SolvePartTwo(string[] input)
    {
        var finalScore = (from line in input
                let opponentHand = ParseOpponentHand(line[0])
                let hand = line[2] switch
                {
                    'X' => ParseHandByStrategy(Strategy.Lose, opponentHand),
                    'Y' => ParseHandByStrategy(Strategy.Draw, opponentHand),
                    'Z' => ParseHandByStrategy(Strategy.Win, opponentHand),
                    _ => throw new IndexOutOfRangeException("Don't know what '{b}' is.")
                }
                select CalculateScore(opponentHand, hand))
            .Sum();

        return finalScore.ToString();
    }

    private enum Hand
    {
        Rock = 1,
        Paper = 2,
        Scissor = 3
    }

    private enum Strategy
    {
        Lose = 0,
        Draw = 3,
        Win = 6
    }
    
    private static Hand ParseOpponentHand(char handStrategy)
    {
        return handStrategy switch
        {
            'A' => Hand.Rock,
            'B' => Hand.Paper,
            'C' => Hand.Scissor,
            _ => throw new ArgumentOutOfRangeException(nameof(handStrategy), handStrategy, 
                "don't know what this is")
        };
    }

    private static Hand ParseHandByStrategy(Strategy strategy, Hand opponentHand)
    {
        return strategy switch
        {
            Strategy.Lose => opponentHand switch
            {
                Hand.Rock => Hand.Scissor,
                Hand.Paper => Hand.Rock,
                Hand.Scissor => Hand.Paper,
                _ => throw new ArgumentOutOfRangeException(nameof(opponentHand), opponentHand,
                    "don't know what this is")
            },
            Strategy.Draw => opponentHand,
            Strategy.Win => opponentHand switch
            {
                Hand.Rock => Hand.Paper,
                Hand.Paper => Hand.Scissor,
                Hand.Scissor => Hand.Rock,
                _ => throw new ArgumentOutOfRangeException(nameof(opponentHand), opponentHand,
                    "don't know what this is")
            },
            _ => throw new ArgumentOutOfRangeException(nameof(strategy), strategy,
                "don't know what this is")
        };
    }
    
    private static int CalculateScore(Hand opponentHand, Hand hand)
    {
        return opponentHand switch
        {
            Hand.Rock => hand switch
            {
                Hand.Rock => 1 + 3, // draw
                Hand.Paper => 2 + 6, // win
                Hand.Scissor => 3 + 0, // loss
            },
            Hand.Paper => hand switch
            {
                Hand.Rock => 1 + 0, // loss
                Hand.Paper => 2 + 3, // draw
                Hand.Scissor => 3 + 6, // win
            },
            Hand.Scissor => hand switch
            {
                Hand.Rock => 1 + 6, // win
                Hand.Paper => 2 + 0, // loss
                Hand.Scissor => 3 + 3, // draw
            }
        };
    }
}