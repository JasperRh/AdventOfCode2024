// https://adventofcode.com/2024/day/2
// https://adventofcode.com/2024/day/2#part2

var input = File.ReadAllLines("../../../input.txt");
var reports = input.Select(line => line.Split(' ').Select(int.Parse).ToArray());

Console.WriteLine("Number of safe reports: " + reports.Count(IsSafe));
Console.WriteLine("Number of safe dampened reports: " + reports.Count(IsSafeDampened));
Console.ReadLine();

bool IsSafe(int[] report)
{
    var isIncreasing = report[0] < report[1];
    for (var i = 0; i < report.Length - 1; i++)
    {
        var difference = Math.Abs(report[i] - report[i + 1]);
        if (difference < 1 || difference > 3)
        {
            return false;
        }
        
        if ((isIncreasing && report[i] > report[i + 1]) ||
            (!isIncreasing && report[i] < report[i + 1]))
        {
            return false;
        }
    }

    return true;
}

bool IsSafeDampened(int[] report)
{
    var reportList = new List<int>();
    if (IsSafe(report))
    {
        return true;
    }
    
    for (var i = 0; i < report.Length; i++)
    {
        reportList.Clear();
        reportList.AddRange(report);
        reportList.RemoveAt(i);
        if (IsSafe(reportList.ToArray()))
        {
            return true;
        }
    }

    return false;
}