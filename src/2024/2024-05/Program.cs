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

void ProcessColumns(List<List<int>> columns, List<string> results)
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

KeyValuePair<string, int> ProcessColumnsPart2(List<List<int>> columns, List<string> results)
{
    var       clapIndex  = 0;
    var       shouts     = new Dictionary<string, int>();
    const int count      = 2024;
    var       finalShout = shouts.FirstOrDefault(x => x.Value == count); // Find the first shout that has been shouted 2024 times

    // Keep going until we find the shout that has been shouted 2024 times
    // This isn't a very efficient way to do this, but it works for the input size
    // Ideally, I'd use a custom class to keep track of the number of times each shout has been shouted
    while (finalShout.Equals(default(KeyValuePair<string, int>)))
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
        if (!shouts.TryAdd(number, 1))
        {
            shouts[number]++;
        }

        finalShout = shouts.FirstOrDefault(kvp => kvp.Value == count);
    }

    return finalShout;
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

    const int numRounds = int.MaxValue;
    var       results   = new List<string>();
    var       lastShout = ProcessColumnsPart2(columns, results);
    Console.WriteLine($"Part 2 result: {lastShout.Key} x {results.Count} = {Convert.ToInt32(lastShout.Key) * results.Count}");
}

void SolvePart3()
{
    var input  = File.ReadAllText("input3.txt");
    var result = 0;
    Console.WriteLine($"Part 3 result: {result}");
}

string GenerateNumber(List<List<int>> list) => string.Join(string.Empty, list.Select(col => col[0].ToString()));