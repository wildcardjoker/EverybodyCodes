SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var lines   = File.ReadAllLines("input1.txt").Select(s => s.Replace(" ", "")).ToList();
    var columns = InitializeColumns(lines[0].Length);

    PopulateColumns(lines, columns);

    const int numRounds = 10;
    var       results   = new List<string>();
    while (results.Count < numRounds)
    {
        ProcessColumns(columns, results);
    }

    DisplayResults(numRounds, results);
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
        // Read each character in the line
        for (var i = 0; i < line.Length; i++)
        {
            // Add the character to the appropriate column
            columns[i].Add(int.Parse(line[i].ToString()));
        }
    }
}

void ProcessColumns(List<List<int>> columns, List<string> results)
{
    for (var column = 0; column < columns.Count; column++)
    {
        var nextColumn = (column + 1) % columns.Count;
        var clapper    = columns[column][0];
        columns[column].RemoveAt(0);
        var absorbed = false;
        var count    = 0;
        var index    = 0;
        do
        {
            if (index == columns[nextColumn].Count)
            {
                index--;
            }

            count++;

            if (count == clapper)
            {
                columns[nextColumn].Insert(index, clapper);
                absorbed = true;

                break;
            }

            index++;
        }
        while (!absorbed);

        var number = string.Join(string.Empty, columns.Select(col => col[0]));
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