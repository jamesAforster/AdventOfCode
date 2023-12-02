using System.Text.RegularExpressions;
using Library;

namespace Day1
{
    public static class Solution
    {
        public static void BothParts()
        {
            var total = 0;
            var input = Helpers.ReadInputLines();

            var lines = input.Select(str => numberRegex.Matches(str));

            foreach (MatchCollection l in lines)
            {
                var first = int.TryParse(l.First().Value, out int f) ? f : TryGetValueFromDictionary(l.First().Value);
                var last = int.TryParse(l.Last().Value, out int s) ? s : TryGetValueFromDictionary(l.Last().Value);
                
                total += int.Parse(first.ToString() + last.ToString());
            }
            
            Console.WriteLine(total); // Count not quite right, need to debug more
        }
        
        public static void TerribleSolution()
        {
            var results = new List<List<int>>();
            
            var input = Helpers.ReadInputLines();

            foreach (string s in input) 
            { 
                var subStrings = Helpers.ExtractAllSubstringsWithLookahead(s);

                foreach (string innerS in subStrings)
                {
                    bool stopOuterLoop = false;
                    var toAdd = new List<int>();
                    
                    if (int.TryParse(innerS, out int numberFromInt))
                    {
                        toAdd.Add(numberFromInt);

                        var reverseSubstrings = Helpers.ExtractAllSubstringsWithLookaheadInReverseOrder(s);

                        foreach (string reversedInnerS in reverseSubstrings)
                        {
                            bool stopLoop = false;
                            
                            if (int.TryParse(reversedInnerS, out int numberFromInt2))
                            {
                                toAdd.Add(numberFromInt2);
                                results.Add(toAdd);
                                stopLoop = true;
                            }
                            if (numberDict.TryGetValue(reversedInnerS, out var numberFromString))
                            {
                                toAdd.Add(numberFromString);
                                results.Add(toAdd);
                                stopLoop = true;
                            }
                            
                            if (stopLoop)
                            {
                                stopOuterLoop = true;
                                break;
                            }
                        }
                    }
                    else if (numberDict.TryGetValue(innerS, out var numberFromString2))
                    {
                        toAdd.Add(numberFromString2);
                        var reverseSubstrings = Helpers.ExtractAllSubstringsWithLookaheadInReverseOrder(s);

                        bool stopLoop = false;
                        
                        foreach (string reversedInnerS in reverseSubstrings)
                        {
                            if (int.TryParse(reversedInnerS, out int numberFromInt3))
                            {
                                toAdd.Add(numberFromInt3);
                                results.Add(toAdd);
                                stopLoop = true;
                            }
                            if (numberDict.TryGetValue(reversedInnerS, out var numberFromString3))
                            {
                                toAdd.Add(numberFromString3);
                                results.Add(toAdd);
                                stopLoop = true;
                            }

                            if (stopLoop)
                            {
                                stopOuterLoop = true;
                                break;
                            }
                        }
                    }

                    if (stopOuterLoop)
                    {
                        break;
                    }
                }
            }

            var total = 0;

            foreach (List<int> i in results)
            {
                var s = i[0].ToString() + i[1].ToString();
                total += int.Parse(s);
            }
            
            Console.WriteLine(total);
        }

        private static int TryGetValueFromDictionary(string s)
        {
            return numberDict.TryGetValue(s, out var number) ? number : 0;
        }
        
        private static Regex numberRegex = new Regex("\\d|(one|two|three|four|five|six|seven|eight|nine)");
        
        private static Dictionary<string, int> numberDict = 
            new Dictionary<string, int>()
        {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 }
        };
    }
}