using Library;

namespace Day4
{
    public static class Solution
    {
        public static int TotalCards;
        public static List<Card> Cards = new List<Card>();
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
        
        public static void Part2()
        {
            var input = Helpers.ReadInputLines();
            
            foreach (string line in input)
            {
                Cards.Add(CreateCard(line));
            }

            TotalCards = Cards.Count;
            
            PlayGame(Cards);

            Console.WriteLine(TotalCards);
        }

        public static void PlayGame(List<Card> cards)
        {
            foreach (Card card in cards)
            {
                int wins = 0;
                
                foreach (var number in card.ScratchedNumbers)
                {
                    if (card.WinningNumbers.Contains(number))
                    {
                        wins += 1;

                        var newCard = Cards.Find(c => c.CardNumber == card.CardNumber + wins);
                        
                        card.InnerCards.Add(newCard);
                    }
                }

                TotalCards += wins;
                PlayGame(card.InnerCards);
            }
        }

        private static Card CreateCard(string rawCard)
        {
            var cardNumber = int.Parse(rawCard
                .Split(":")
                .First()
                .Split(" ")
                .Last());
                
            var scratchedNumbers = rawCard
                .Split(" |")
                .First()
                .Split(": ")
                .Last()
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s));
                
            var winningNumbers = rawCard
                .Split("| ")
                .Last()
                .Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s));

            return new Card()
            {
                CardNumber = cardNumber,
                ScratchedNumbers = scratchedNumbers.ToList(),
                WinningNumbers = winningNumbers.ToList()
            };
        }

        public class Card
        {
            public int CardNumber { get; set; }
            public List<string> ScratchedNumbers { get; set; }
            public List<string> WinningNumbers { get; set; }
            public List<Card> InnerCards = new List<Card>();
        }
    }
}
    