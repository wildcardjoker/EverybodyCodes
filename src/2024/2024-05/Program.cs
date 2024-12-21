#region Using Directives
#endregion

SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var lines   = File.ReadAllLines("input1.txt").Select(s => s.Replace(" ", "")).ToList();
    var columns = new List<List<int>>();

    for (var i = 0; i < lines[0].Length; i++)
    {
        columns.Add([]);
    }

    foreach (var line in lines)
    {
        for (var i = 0; i < line.Length; i++)
        {
            columns[i].Add(int.Parse(line[i].ToString()));
        }
    }

    const int numRounds = 10;
    var       results   = new List<string>();
    while (results.Count < numRounds)
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
            DisplayColumns(columns);
            results.Add(number);
        }
    }

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

void DisplayColumns(List<List<int>> columns)
{
    foreach (var column in columns)
    {
        Console.WriteLine(string.Join(" ", column));
    }

    Console.WriteLine();
}