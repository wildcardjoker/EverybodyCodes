// Example input
//string[] words = ["THE", "OWE", "MES", "ROD", "HER"];
//var      inscription     = "AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE".Split(' ');
//var inscription     = "THE FLAME SHIELDED THE HEART OF THE KINGS".Split(' ');
//var inscription     = "POWE PO WER P OWE R".Split(' ');
//var inscription     = "THERE IS THE END".Split(' ');

#pragma warning disable CS8321 // Local function is declared but never used

#region Using Directives
using System.Text;
#endregion

Part1();
Part2();
Part3();
return;

void Part1()
{
    var input       = GetInput("input1.txt");
    var words       = GetWords(input, false);
    var inscription = input[1].Split(' ');

    //WriteWords(1, words);
    var totalRunicWords = inscription.Sum(word => words.Count(word.Contains));
    Console.WriteLine($"Total runic words (part 1): {totalRunicWords}");
}

void Part2()
{
    // Example input
    //var words = "WORDS:THE,OWE,MES,ROD,HER,QAQ".Replace("WORDS:", string.Empty).Split(',').ToList();
    //var inscription = """
    //                  AWAKEN THE POWE ADORNED WITH THE FLAMES BRIGHT IRE
    //                  THE FLAME SHIELDED THE HEART OF THE KINGS
    //                  POWE PO WER P OWE R
    //                  THERE IS THE END
    //                  QAQAQ
    //                  """.Split(Environment.NewLine);
    var input       = GetInput("input2.txt");
    var words       = GetWords(input, true);
    var inscription = input[1..];

    var totalRunicSymbols = 0;

    //WriteWords(2, words);

    foreach (var line in inscription)
    {
        var reversedLine    = new string(line.Reverse().ToArray()); // Reverse the line to check for runes from right to left
        var lineMap         = CreateLineMap(line);                  // Create a map of the line to mark runes
        var reversedLineMap = CreateLineMap(reversedLine);          // Create a map of the reversed line to mark runes

        // Check for runes in the line and reversed line
        foreach (var rune in words)
        {
            MapRunes(line,         rune, ref lineMap);
            MapRunes(reversedLine, rune, ref reversedLineMap);
        }

        // Merge the line and reversed line maps
        reversedLineMap.Reverse();
        for (var i = 0; i < lineMap.Count; i++)
        {
            lineMap[i] = lineMap[i] || reversedLineMap[i];
        }

        var symbolCount = lineMap.Count(b => b);
        totalRunicSymbols += symbolCount;
    }

    Console.WriteLine($"Total runic symbols: {totalRunicSymbols}");
}

void Part3()
{
    var input       = GetInput("input3.txt");
    var words       = GetWords(input, true).ToList();
    var inscription = input[1..];
    var grid        = inscription.Select(s => s.ToCharArray()).ToArray();
    var columns     = grid[0].Length;
    var gridSymbols = new HashSet<(int row, int col)>();

    //WriteWords(3, words);
    // Check for runes in the grid using a sliding window and wrapping around the grid
    for (var row = 0; row < grid.Length; row++) // Check each row
    {
        for (var col = 0; col < columns; col++) // Check each column
        {
            foreach (var word in words) // Check each word
            {
                // Check horizontally
                var found = !word.Where((t, i) => grid[row][(col + i) % columns] != t).Any();

                if (found)
                {
                    // Add the coordinates of the matching characters to the gridSymbols hashset
                    for (var i = 0; i < word.Length; i++)
                    {
                        gridSymbols.Add((row, (col + i) % columns));
                    }
                }

                // Check vertically
                if (row + word.Length > grid.Length)
                {
                    continue;
                }

                {
                    found = !word.Where((t, i) => grid[row + i][col] != t).Any();

                    if (!found)
                    {
                        continue;
                    }

                    {
                        // Add the coordinates of the matching characters to the gridSymbols hashset
                        for (var i = 0; i < word.Length; i++)
                        {
                            gridSymbols.Add((row + i, col));
                        }
                    }
                }
            }
        }
    }

    Console.WriteLine($"Total scales (part 3): {gridSymbols.Count}");

    // Display gridSymbols, using a 2D array to display the grid
    // Output to a file as well.
    ExportGrid(grid, columns, gridSymbols);
    ExportCoordinates(gridSymbols);
}

void WriteWords(int part, IEnumerable<string> words) => Console.WriteLine($"Part {part} Words: {string.Join(',', words)}");

List<bool> CreateLineMap(string s)
{
    var list = new List<bool>();
    list.AddRange(Enumerable.Repeat(false, s.Length));
    return list;
}

void MapRunes(string s, string rune, ref List<bool> map)
{
    var index = 0;
    while ((index = s.IndexOf(rune, index, StringComparison.CurrentCultureIgnoreCase)) != -1)
    {
        for (var i = 0; i < rune.Length; i++)
        {
            map[index + i] = true;
        }

        index++;
    }
}

string[] GetInput(string fileName) => File.ReadAllLines(fileName).Where(x => !string.IsNullOrEmpty(x)).ToArray();

List<string> GetWords(string[] strings, bool reverse)
{
    var list = strings[0].Replace("WORDS:", string.Empty).Split(',').ToList();
    if (!reverse)
    {
        return list;
    }

    var reversedWords = list.Select(word => new string(word.Reverse().ToArray())).ToArray();
    list.AddRange(reversedWords);
    return list.Distinct().OrderBy(x => x).ToList();
}

void ExportGrid(char[][] chars, int columns, HashSet<(int row, int col)> valueTuples, bool writeToConsole = false)
{
    var sb = new StringBuilder();
    for (var row = 0; row < chars.Length; row++)
    {
        for (var col = 0; col < columns; col++)
        {
            var c = valueTuples.Contains((row, col)) ? '*' : '.';
            sb.Append(c);
        }

        sb.AppendLine();
    }

    var path = Path.Combine(AppContext.BaseDirectory, "output.txt");
    File.WriteAllText(path, sb.ToString());
    Console.WriteLine($"Grid exported to {path}");
    if (!writeToConsole)
    {
        return;
    }

    Console.WriteLine(sb.ToString());
    Console.WriteLine();
}

void ExportCoordinates(HashSet<(int row, int col)> valueTuples, bool writeToConsole = false)
{
    var sb = new StringBuilder();
    foreach (var symbol in valueTuples)
    {
        sb.AppendLine($"({symbol.row},{symbol.col})");
    }

    var path = Path.Combine(AppContext.BaseDirectory, "coordinates.txt");
    File.WriteAllText(path, sb.ToString());
    Console.WriteLine($"Coordinates exported to {path}");
    if (!writeToConsole)
    {
        return;
    }

    Console.WriteLine(sb.ToString());
    Console.WriteLine();
}