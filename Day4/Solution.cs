using Library;

namespace Day4
{
    public static class Solution
    {
        public static void Part1()
        {
            var input = Helpers.ReadInputLines();
            
            int totalScore = 0;
            
            foreach (string line in input)
            {
                var numbers = line
                    .Split(" |")
                    .First()
                    .Split(": ")
                    .Last()
                    .Split(" ")
                    .Where(s => !string.IsNullOrWhiteSpace(s));
                
                var winningNumbers = line
                    .Split("| ")
                    .Last()
                    .Split(" ")
                    .Where(s => !string.IsNullOrWhiteSpace(s));

                int gameScore = 0;
                
                foreach (var number in numbers)
                {
                    if (winningNumbers.Contains(number))
                    {
                        gameScore = gameScore == 0 ? 1 : gameScore * 2;
                    }
                }

                totalScore += gameScore;
            }
            
            Console.WriteLine(totalScore);
        }
    }
}
    