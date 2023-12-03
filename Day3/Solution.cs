using System.Text.RegularExpressions;
using Library;

namespace Day3
{
    public static class Solution
    {
        public static void Part1()
        {
            var lines = Helpers.ReadInputLines();

            List<Number> numberList = new List<Number>();
            List<int[]> symbolList = new List<int[]>();

            for (int lineNumber = 0; lineNumber <= lines.Length - 1; lineNumber++)
            {
                var matches = Regex.Matches(lines[lineNumber], "[\\d]*");
                foreach (Match match in matches)
                {
                    var charPositions = new List<int[]>();

                    for (int c = match.Index; c < match.Index + match.Value.Length; c++)
                    {
                        charPositions.Add(new[] { lineNumber, c });
                    }

                    if (match.Value.Length > 0) // should not be adding whitespace
                    {
                        numberList.Add(new Number()
                        {
                            Value = int.Parse(match.Value),
                            CharPositions = charPositions,
                            Adjacent = false
                        });
                    }
                }
            }

            for (int lineNumber = 0; lineNumber <= lines.Length - 1; lineNumber++)
            {
                var matches = Regex.Matches(lines[lineNumber], "[^a-zA-Z.\\d]");

                foreach (Match match in matches)
                {
                    symbolList.Add(new int[] { lineNumber, match.Index });
                }
            }

            foreach (int[] symbol in symbolList)
            {
                List<int[]> positionsToCheck = new List<int[]>();

                positionsToCheck.Add(new int[] { symbol[0] - 1, symbol[1] - 1 });
                positionsToCheck.Add(new int[] { symbol[0] - 1, symbol[1] });
                positionsToCheck.Add(new int[] { symbol[0] - 1, symbol[1] + 1 });
                positionsToCheck.Add(new int[] { symbol[0], symbol[1] - 1 });
                positionsToCheck.Add(new int[] { symbol[0], symbol[1] + 1 });
                positionsToCheck.Add(new int[] { symbol[0] + 1, symbol[1] - 1 });
                positionsToCheck.Add(new int[] { symbol[0] + 1, symbol[1] });
                positionsToCheck.Add(new int[] { symbol[0] + 1, symbol[1] + 1 });
                
                foreach (int[] p in positionsToCheck)
                {
                    foreach (Number n in numberList)
                    {
                        foreach (int[] charPosition in n.CharPositions)
                        {
                            if (charPosition[0] == p[0] && charPosition[1] == p[1])
                            {
                                n.Adjacent = true;
                            }
                        }
                    }
                }
            }

            var total = 0;

            foreach (Number number in numberList)
            {
                if (number.Adjacent)
                {
                    total += number.Value;
                }
            }

            Console.WriteLine(total);
        }
        
        public static void Part2()
        {
            var total = 0;
            var lines = Helpers.ReadInputLines();

            List<Number> numberList = new List<Number>();
            List<int[]> symbolList = new List<int[]>();

            for (int lineNumber = 0; lineNumber <= lines.Length - 1; lineNumber++)
            {
                var matches = Regex.Matches(lines[lineNumber], "[\\d]*");
                foreach (Match match in matches)
                {
                    var charPositions = new List<int[]>();

                    for (int c = match.Index; c < match.Index + match.Value.Length; c++)
                    {
                        charPositions.Add(new[] { lineNumber, c });
                    }

                    if (match.Value.Length > 0) // should not be adding whitespace, figure out why this is happening in the regex
                    {
                        numberList.Add(new Number()
                        {
                            Value = int.Parse(match.Value),
                            CharPositions = charPositions,
                            Adjacent = false
                        });
                    }
                }
            }

            for (int lineNumber = 0; lineNumber <= lines.Length - 1; lineNumber++)
            {
                var matches = Regex.Matches(lines[lineNumber], "\\*");

                foreach (Match match in matches)
                {
                    symbolList.Add(new int[] { lineNumber, match.Index });
                }
            }

            foreach (int[] symbol in symbolList) // we have all of the positions of the * characters
            {
                List<int[]> positionsToCheck = new List<int[]>();

                positionsToCheck.Add(new int[] { symbol[0] - 1, symbol[1] - 1 }); // Will probably be a nicer way to do this with a loop, also this will add out of range indexes
                positionsToCheck.Add(new int[] { symbol[0] - 1, symbol[1] });
                positionsToCheck.Add(new int[] { symbol[0] - 1, symbol[1] + 1 });
                positionsToCheck.Add(new int[] { symbol[0], symbol[1] - 1 });
                positionsToCheck.Add(new int[] { symbol[0], symbol[1] + 1 });
                positionsToCheck.Add(new int[] { symbol[0] + 1, symbol[1] - 1 });
                positionsToCheck.Add(new int[] { symbol[0] + 1, symbol[1] });
                positionsToCheck.Add(new int[] { symbol[0] + 1, symbol[1] + 1 });
                
                List<Number> toMultiply = new List<Number>();
                
                foreach (int[] p in positionsToCheck) // tidy this up
                {
                    
                    foreach (Number n in numberList)
                    {
                        foreach (int[] charPosition in n.CharPositions)
                        {
                            if (charPosition[0] == p[0] && charPosition[1] == p[1] && n.Adjacent == false)
                            {
                                n.Adjacent = true;
                                toMultiply.Add(n);
                                break;
                            }
                        }
                    }

                    if (toMultiply.Count() == 2)
                    {
                        total += (toMultiply[0].Value * toMultiply[1].Value);
                        toMultiply.Clear();
                    }
                }
            }

            Console.WriteLine(total);
        }
    }

    public class Number
    {
        public int Value { get; set; }
        public List<int[]> CharPositions { get; set; }
        public bool Adjacent = false;
    }
}
    