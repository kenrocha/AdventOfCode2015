Console.WriteLine("Advent of Code 2015 - Day 2\n");

// Get puzzle input
var dimensions = File.ReadAllLines("Aoc2015Day02-Input.txt");

// Part One:  How many square feet of wrapping paper should the elves order?
var paperOrder = dimensions
    .Select(d => d.Split('x'))
    .Select(d => new
    {
        Length = int.Parse(d[0]),
        Width = int.Parse(d[1]),
        Height = int.Parse(d[2])
    })
    .Select(d => new
    {
        SurfaceArea = 2 * ((d.Length * d.Width) + (d.Width * d.Height) + (d.Length * d.Height)),
        MinSideArea = Math.Min(d.Length * d.Width, Math.Min(d.Width * d.Height, d.Length * d.Height))
    })
    .Sum(d => d.SurfaceArea + d.MinSideArea);
Console.WriteLine("Part One:");
Console.WriteLine($"The elves should order {paperOrder} square feet of wrapping paper\n");

// Part Two:  How many feet of ribbon should the elves order?
var ribbonOrder = dimensions
    .Select(d => d.Split('x'))
    .Select(d => new
    {
        Length = int.Parse(d[0]),
        Width = int.Parse(d[1]),
        Height = int.Parse(d[2])
    })
    .Select(d => new
    {
        MinPerimeter = Math.Min(2 * (d.Length + d.Width),
            Math.Min(2 * (d.Width + d.Height), 2 * (d.Length + d.Height))),
        Volume = d.Length * d.Width * d.Height
    })
    .Sum(d => d.MinPerimeter + d.Volume);
Console.WriteLine("Part Two:");
Console.WriteLine($"The elves should order {ribbonOrder} feet of ribbon\n");
