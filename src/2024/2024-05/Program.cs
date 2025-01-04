#region Using Directives
using System.Diagnostics;
#endregion

SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var lines   = File.ReadAllLines("input1.txt").ToList();
    var columns = InitializeColumns(lines[0].Split(' ').Length);

    PopulateColumns(lines, columns);

    const int numRounds = 10;
    var       results   = new List<ulong>();
    while (results.Count < numRounds)
    {
        ProcessColumns(columns, results);
    }

    Console.WriteLine($"Round 1: {results.Last()}");
}

List<List<int>> InitializeColumns(int length)
{
    // Create a column for each character
    var columns = new List<List<int>>();
    for (var i = 0; i < length; i++)
    {
        columns.Add([]);
    }

    return columns;
}

void PopulateColumns(List<string> lines, List<List<int>> columns)
{
    // Read each line
    foreach (var values in lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()))
    {
        // Read each value in the line
        for (var i = 0; i < values.Length; i++)
        {
            // Add the value to the appropriate column
            columns[i].Add(values[i]);
        }
    }
}

void ProcessColumns(List<List<int>> columns, List<ulong> results)
{
    var clapIndex = 0;
    for (var round = 0; round < 10; round++)
    {
        var clapper = columns[clapIndex][0];
        columns[clapIndex].RemoveAt(0);
        var targetColumn = columns[(clapIndex + 1) % 4];
        var moves        = Math.Abs(clapper % (targetColumn.Count * 2) - 1);
        if (moves > targetColumn.Count)
        {
            moves = targetColumn.Count * 2 - moves;
        }

        targetColumn.Insert(moves, clapper);
        clapIndex = (clapIndex + 1) % columns.Count;

        var number = GenerateNumber(columns);
        results.Add(number);
    }
}

Shout ProcessColumnsPart2(List<List<int>> columns, List<ulong> results)
{
    var       clapIndex  = 0;
    var       shouts     = new List<Shout>();
    const int count      = 2024;
    var       finalShout = shouts.FirstOrDefault(x => x.Count == count); // Find the first shout that has been shouted 2024 times
    var       sw         = Stopwatch.StartNew();

    // Keep going until we find the shout that has been shouted 2024 times
    while (finalShout == null)
    {
        // Same processing as for Part 1
        var clapper = columns[clapIndex][0];
        columns[clapIndex].RemoveAt(0);
        var targetColumn = columns[(clapIndex + 1) % 4];
        var moves        = Math.Abs(clapper % (targetColumn.Count * 2) - 1);
        if (moves > targetColumn.Count)
        {
            moves = targetColumn.Count * 2 - moves;
        }

        targetColumn.Insert(moves, clapper);
        clapIndex = (clapIndex + 1) % columns.Count;

        var number = GenerateNumber(columns);
        results.Add(number);
        var shout = shouts.FirstOrDefault(x => x.ShoutValue == number);
        if (shout == null)
        {
            shouts.Add(new Shout(number));
        }
        else
        {
            shout.Count++;
        }

        finalShout = shouts.FirstOrDefault(x => x.Count == count);
    }

    sw.Stop();
    return finalShout;
}

void SolvePart2()
{
    var lines   = File.ReadAllLines("input2.txt").ToList();
    var columns = InitializeColumns(lines[0].Split(' ').Length);

    PopulateColumns(lines, columns);

    const int numRounds = int.MaxValue;
    var       results   = new List<ulong>();
    var       lastShout = ProcessColumnsPart2(columns, results);
    Console.WriteLine($"Part 2 result: {lastShout.ShoutValue} x {results.Count} = {lastShout.ShoutValue * (ulong) results.Count}");
}

void SolvePart3()
{
    var input  = File.ReadAllText("input3.txt");
    var result = 0;
    Console.WriteLine($"Part 3 result: {result}");
}

ulong GenerateNumber(List<List<int>> list) => Convert.ToUInt64(string.Join(string.Empty, list.Select(col => col[0].ToString())));

internal class Shout(ulong shoutValue)
{
    #region Properties
    public ulong Count      {get; set;} = 1;
    public ulong ShoutValue {get;}      = shoutValue;
    #endregion
}