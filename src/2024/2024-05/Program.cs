#region Using Directives
using System.Text.RegularExpressions;
using Humanizer;
#endregion

SolvePart1();
SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var       regex     = SplitInputRegex();
    var       columns   = File.ReadAllLines("input-example1.txt").Select(s => regex.Matches(s).Select(m => int.Parse(m.Value)).ToList()).ToList();
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
                Console.WriteLine(count.ToWords());
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

            //Console.WriteLine($"Round {numRounds}: {number}");
            results.Add(number);

            //DisplayColumns(columns);
        }
    }

    for (var i = 0; i < results.Count; i++)
    {
        Console.WriteLine($"{i + 1}: {results[i]}");
    }

    //Console.WriteLine($"Part 1 result: {result}");
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

internal partial class Program
{
    [GeneratedRegex(@"\d")]
    private static partial Regex SplitInputRegex();
}