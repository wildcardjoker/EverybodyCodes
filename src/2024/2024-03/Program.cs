SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var result = ExtensionMethods.RemoveBlocks("input1.txt");
    Console.WriteLine($"Part 1 result: {result}");
}

void SolvePart2()
{
    var result = ExtensionMethods.RemoveBlocks("input2.txt");
    Console.WriteLine($"Part 2 result: {result}");
}

void SolvePart3()
{
    var result = ExtensionMethods.RemoveBlocks("input3.txt", true);
    Console.WriteLine($"Part 3 result: {result}");
}