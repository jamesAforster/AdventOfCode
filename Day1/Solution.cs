using Library;

namespace Day1
{
    public static class Solution
    {
        public static void PartOne()
        {
            var results = new List<string>();
            var input = Helpers.ReadInputLines();
            
            foreach (string s in input)
            {
                foreach (char c in s)
                {
                    if (int.TryParse(c.ToString(), out int value))
                    {
                        var toAdd = new List<int>();
                        
                        toAdd.Add(value);

                        var reversed = Helpers.Reverse(s);

                        foreach (char reversedC in reversed)
                        {
                            if (int.TryParse(reversedC.ToString(), out int reversedValue))
                            {
                                toAdd.Add(reversedValue);
                                break;
                            }
                        }
                        
                        results.Add(toAdd[0].ToString() + toAdd[1]);
                        break;
                    }
                }
            }

            int final = 0;
            
            foreach(string n in results)
            {
                final += int.Parse(n);
            }
            
            Console.WriteLine(final);
        }
        
        public static void PartTwo()
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