using Library;

namespace Day2
{
    public static class Solution
    {
        public static void Part1()
        {
            var input = Helpers.ReadInputLines();
            int total = 0;
            
            Dictionary<string, int> MaxCubes = new Dictionary<string, int>()
            {
                { "red", 12 },
                { "green", 13 },
                { "blue", 14 }
            };

            for (int i = 1; i <= input.Length; i++)
            {
                var validGame = true;
                var game = input[i - 1].Split(": ").Last();
                var individualGames = game.Split("; ");

                foreach (string g in individualGames)
                {
                    var scores = g.Split(", ");

                    foreach (var individualScores in scores)
                    {
                        var colour = individualScores.Split(" ")[1].Replace(",", "");
                        var count = int.Parse(individualScores.Split(" ")[0]);

                        if (MaxCubes[colour] < count)
                        {
                            validGame = false;
                            break;
                        }
                    }

                    if (!validGame)
                    {
                        break;
                    }
                }

                if (validGame)
                {
                    total += i;
                }
            }

            Console.WriteLine(total);
        }
        
        public static void Part2()
        {
            var input = Helpers.ReadInputLines();
            int total = 0;

            for (int i = 1; i <= input.Length; i++)
            {
                var game = input[i - 1].Split(": ").Last();
                var individualGames = game.Split("; ");
                
                Dictionary<string, int> TotalCubes = new Dictionary<string, int>()
                {
                    { "red", 0 },
                    { "green", 0 },
                    { "blue", 0 }
                };

                foreach (string g in individualGames)
                {
                    var scores = g.Split(", ");

                    foreach (var individualScores in scores)
                    {
                        var colour = individualScores.Split(" ")[1].TrimEnd(',');
                        var count = int.Parse(individualScores.Split(" ")[0]);
                        TotalCubes[colour] = TotalCubes[colour] < count ? count : TotalCubes[colour];
                    }
                }

                total += (TotalCubes["red"] * TotalCubes["green"] * TotalCubes["blue"]);
            }

            Console.WriteLine(total);
        }
    }
}