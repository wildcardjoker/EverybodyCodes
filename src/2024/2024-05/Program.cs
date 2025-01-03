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
    var       results   = new List<string>();
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
    foreach (var line in lines)
    {
        var values = line.Split(' ').Select(int.Parse).ToArray();

        // Read each value in the line
        for (var i = 0; i < values.Length; i++)
        {
            // Add the value to the appropriate column
            columns[i].Add(values[i]);
        }
    }
}

void ProcessColumns(List<List<int>> columns, List<string> results)
{
    var clapIdx = 0;
    for (var r = 0; r < 10; r++)
    {
        var clapper = columns[clapIdx][0];
        columns[clapIdx].RemoveAt(0);
        var targetColumn = columns[(clapIdx + 1) % 4];
        var moves        = Math.Abs(clapper % (targetColumn.Count * 2) - 1);
        if (moves > targetColumn.Count)
        {
            moves = targetColumn.Count * 2 - moves;
        }

        targetColumn.Insert(moves, clapper);
        clapIdx = (clapIdx + 1) % columns.Count;

        var number = string.Join(string.Empty, columns.Select(col => col[0].ToString()));
        results.Add(number);
    }
}

void DisplayResults(int numRounds, List<string> results)
{
    for (var i = 0; i < numRounds; i++)
    {
        Console.WriteLine($"{i + 1}: {results[i]}");
    }
}

void SolvePart2()
{
    var lines   = File.ReadAllLines("input-example2.txt").ToList();
    var columns = InitializeColumns(lines[0].Split(' ').Length);

    PopulateColumns(lines, columns);

    const int numRounds = 10;
    var       results   = new List<string>();
    while (results.Count < numRounds)
    {
        ProcessColumns(columns, results);
    }

    DisplayResults(numRounds, results);
}

void SolvePart3()
{
    var input  = File.ReadAllText("input3.txt");
    var result = 0;
    Console.WriteLine($"Part 3 result: {result}");
}