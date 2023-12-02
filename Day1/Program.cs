using System.Diagnostics;
using Day1;

var sw1 = new Stopwatch();
var sw2 = new Stopwatch();

sw1.Start();
Solution.PartOne();
sw1.Stop();

sw2.Start();
Solution.PartTwo();
sw2.Stop();

Console.WriteLine("Part 1: "  + sw1.ElapsedMilliseconds + "ms");
Console.WriteLine("Part 2: "  + sw2.ElapsedMilliseconds + "ms");