var input           = File.ReadAllText("input.txt").ToCharArray();
var potionsRequired = 0;

// No potions required for Ancient Ants
potionsRequired += input.Count(c => c.Equals('B'));     // 1 potion for each Badass Beetle
potionsRequired += input.Count(c => c.Equals('C')) * 3; // 3 potions for each Creepy Cockroach

Console.WriteLine($"Part 1: {potionsRequired} potions required.");