SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var input  = File.ReadAllLines("input1.txt").Select(int.Parse).ToArray();
    var min    = input.Min();
    var result = input.Sum(x => x - min);

    Console.WriteLine($"Part 1 result: {result}");
}

void SolvePart2()
{
    var input  = File.ReadAllText("input2.txt");
    var result = 0;
    Console.WriteLine($"Part 2 result: {result}");
}

void SolvePart3()
{
    var input  = File.ReadAllText("input3.txt");
    var result = 0;
    Console.WriteLine($"Part 3 result: {result}");
}