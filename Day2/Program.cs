using System.Diagnostics;

var st = new Stopwatch();
    
st.Start();
Day2.Solution.Part2();
st.Stop();

Console.WriteLine(st.ElapsedMilliseconds);