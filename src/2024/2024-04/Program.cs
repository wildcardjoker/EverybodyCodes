SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var result = CalculateStrikes("input1.txt");
    Console.WriteLine($"Part 1 result: {result}");
}

void SolvePart2()
{
    var result = CalculateStrikes("input2.txt");
    Console.WriteLine($"Part 2 result: {result}");
}

void SolvePart3()
{
    var input  = File.ReadAllText("input3.txt");
    var result = 0;
    Console.WriteLine($"Part 3 result: {result}");
}

int CalculateStrikes(string inputFile)
{
    var input = File.ReadAllLines(inputFile).Select(int.Parse).ToArray();
    var min   = input.Min();
    return input.Sum(x => x - min);
}