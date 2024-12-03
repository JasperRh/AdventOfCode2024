// https://adventofcode.com/2024/day/3
// https://adventofcode.com/2024/day/3#part2

using System.Text.RegularExpressions;

var input = File.ReadAllText("../../../input.txt");
Part1();
Part2();

void Part1()
{
    var matches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)");
    var sum = matches.Select(match => int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value)).Sum();
    Console.WriteLine("Part1: Sum of multiplications: " + sum);
}

void Part2()
{
    var matches = Regex.Matches(input, @"mul\((\d{1,3}),(\d{1,3})\)|do\(\)|don't\(\)");
    var enabled = true;
    var sum = 0;
    foreach (Match match in matches)
    {
        switch (match.Value)
        {
            case "do()":
                enabled = true;
                continue;
            case "don't()":
                enabled = false;
                continue;
            default:
                sum += enabled ? int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[2].Value) : 0;
                continue;
        }
    }
    
    Console.WriteLine("Part2: Sum of multiplications: " + sum);
}


