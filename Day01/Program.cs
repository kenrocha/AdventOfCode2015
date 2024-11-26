using MoreLinq;

Console.WriteLine("Advent of Code 2015 - Day 1\n");

// Get puzzle input
var floorDirections = File.ReadAllText("Aoc2015Day01-Input.txt");

// Part One:  To what floor do the directions take Santa?
var floor = floorDirections
    .Sum(dir => dir == '(' ? 1 : -1);
Console.WriteLine("Part One:");
Console.WriteLine($"The directions take Santa to floor {floor}.\n");

// Part Two:  On which direction does Santa first visit the basement?
var directionIndex = floorDirections
    .Scan(0, (accum, next) => next == '(' ? accum + 1 : accum - 1)
    .Select((f, i) => new
    {
        Floor = f,
        Index = i
    })
    .First(f => f.Floor == -1);
Console.WriteLine("Part Two:");
Console.WriteLine($"Santa first visits the basement on direction {directionIndex.Index}.\n");
