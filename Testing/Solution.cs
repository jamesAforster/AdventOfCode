namespace Solution
{
    public static class Test
    {
        public static void Splitter()
        {
            var s = "123onee1d";

            var numberDict = new Dictionary<string, int>()
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
            
            ExtractSubstrings(s);
        }

        public static void ExtractSubstrings(string input)
        {
            for (var i = 1; i <= input.Length; i++)
            {
                for (var j = 0; j <= input.Length - i; j++)
                {  
                    Console.WriteLine(input.Substring(j, i));
                }
            }
        }
    }
}