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
    var result = CalculateStrikes("input3.txt", true);
    Console.WriteLine($"Part 3 result: {result}");
}

// function to calculate the median value in the array
int GetMedian(int[] input)
{
    Array.Sort(input);
    return input[input.Length / 2];
}

int CalculateStrikes(string inputFile, bool useMedian = false)
{
    var input = File.ReadAllLines(inputFile).Select(int.Parse).ToArray();
    if (useMedian)
    {
        var median          = GetMedian(input);
        var numberOfStrikes = input.Where(x => x > median).Sum(x => x - median);
        numberOfStrikes += input.Where(x => x < median).Sum(x => median - x);
        return numberOfStrikes;
    }

    var min = input.Min();
    return input.Sum(x => x - min);
}