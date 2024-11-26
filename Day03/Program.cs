using MoreLinq;

Console.WriteLine("Advent of Code 2015 - Day 3\n");

// Get puzzle input
var directions = File.ReadAllText("Aoc2015Day03-Input.txt");

// Part One:  How many houses receive at least one present?
var uniqueVisits = directions
    .Scan(0, (accum, next) => next == '^' || next == 'v' || next == '<' || next == '>' ? accum + 1 : 0)
    .Select((accum, next) => new
    {
        NumVisits = accum,
        House = next
    });
Console.WriteLine("Part One:");
Console.WriteLine($"{uniqueVisits} houses received at least one present.\n");
