﻿// https://adventofcode.com/2024/day/1
// https://adventofcode.com/2024/day/1#part2

var input = File.ReadAllLines("../../../input.txt");
var columns = input.Select(line => line.Split("   ")).ToList();

// Part 1
var leftColumn = columns
    .Select(column => int.Parse(column[0]))
    .Order()
    .ToList();
var rightColumn = columns
    .Select(column => int.Parse(column[1]))
    .Order()
    .ToList();

var sum = leftColumn.Select((number, index) => Math.Abs(number - rightColumn.ElementAt(index))).Sum();

Console.WriteLine("Total sum: " + sum);

// Part 2
var rightColumnGrouped = rightColumn.ToLookup(number => number);
var similarityScore = leftColumn.Select(number => number * rightColumnGrouped[number].Count())
    .Sum();

Console.WriteLine("Similarity score: " + similarityScore);
Console.ReadLine();