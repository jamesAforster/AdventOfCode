namespace Library;

public static class Helpers
{
    private static string _filepath = new FileInfo(Path.Combine(Environment.CurrentDirectory, "Input.txt")).FullName;
    
    public static string[] ReadInputLines()
    {
        return File.ReadAllLines(_filepath);
    }
    
    public static string ReadInputText()
    {
        return File.ReadAllText(_filepath);
    }
    
    /// <summary>
    /// Reads the input file and returns an array containing sub arrays of a defined size.
    /// </summary>
    /// <param name="subArraySize">Desired size of the sub arrays.</param>
    /// <returns>string[][]</returns>
    public static string[][] ReadInputLinesAsGroups(int subArraySize)
    {
        List<string[]> arrayList = new List<string[]>();

        var input = ReadInputLines();

        int addeditems = 0;
        List<string> subArray = new List<string>(); 

        foreach (string line in input)
        {
            subArray.Add(line);
            
            addeditems++;
            
            if (addeditems == subArraySize)
            {
                arrayList.Add(subArray.ToArray());
                addeditems = 0;
                subArray.Clear();
            }
        }
        
        return arrayList.ToArray();
    }
    
    public static string Reverse(string s)
    {
        char[] charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }
    
    // This extracts all potential substrings, character priority
    public static List<string> ExtractAllSubstrings(string input)
    {
        List<string> subStrings = new List<string>();
        
        for (var i = 1; i <= input.Length; i++)
        {
            for (var j = 0; j <= input.Length - i; j++)
            {  
                subStrings.Add(input.Substring(j, i));
            }
        }

        return subStrings;
    }
    
    // This extracts all substrings, lookahead priority
    public static List<string> ExtractAllSubstringsWithLookahead(string input)
    {
        List<string> subStrings = new List<string>();
        
        for (var i = 0; i <= input.Length; i++)
        {
            for (var j = 1; j <= input.Length - i; j++)
            {  
                subStrings.Add(input.Substring(i, j));
            }
        }

        return subStrings;
    }
    
    // This extracts all substrings, lookahead priority, in reverse order
    public static List<string> ExtractAllSubstringsWithLookaheadInReverseOrder(string input)
    {
        List<string> subStrings = new List<string>();

        for (var totalLength = input.Length; totalLength >= 0; totalLength--)
        {
            for (var length = 1; length <= totalLength; length++)
            {
                for (var index = totalLength - 1; index >= 0; index--)
                {
                    subStrings.Add(input.Substring(index, length));
                    length++;
                }
            }
        }
        
        return subStrings;
    }
}