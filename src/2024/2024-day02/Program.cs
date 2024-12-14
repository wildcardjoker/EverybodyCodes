// Example input
//string[] words = ["THE", "OWE", "MES", "ROD", "HER"];
//var      inscription     = "AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE".Split(' ');
//var inscription     = "THE FLAME SHIELDED THE HEART OF THE KINGS".Split(' ');
//var inscription     = "POWE PO WER P OWE R".Split(' ');
//var inscription     = "THERE IS THE END".Split(' ');

Part1();
Part2();
Part3();
return;

void Part1()
{
    var input       = GetInput("input1.txt");
    var words       = GetWords(input);
    var inscription = input[1].Split(' ');

    WriteWords(1, words);
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
    //words.AddRange(words.Select(word => new string(word.Reverse().ToArray())).ToArray());
    //words = words.Distinct().OrderBy(x => x).ToList();
    var input       = GetInput("input2.txt");
    var words       = GetWords(input);
    var inscription = input[1..];

    var totalRunicSymbols = 0;
    Console.WriteLine();
    WriteWords(2, words);

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
    var input       = GetInput("input3-example.txt");
    var words       = GetWords(input);
    var inscription = input[1..];

    var grid        = inscription.Select(s => s.ToCharArray()).ToArray();
    var columns     = grid[0].Length;
    var gridSymbols = new HashSet<(int row, int col)>();

    Console.WriteLine();
    WriteWords(3, words);

    // Check for runes in the grid using a sliding window and wrapping around the grid
    for (var row = 0; row < grid.Length; row++) // Check each row
    {
        for (var col = 0; col < columns; col++) // Check each column
        {
            foreach (var word in words) // Check each word
            {
                // Check horizontally
                var found = true;
                for (var i = 0; i < word.Length; i++)
                {
                    // Check (row,column+i) for a matching character, wrapping around the grid if necessary
                    // Mod columns will wrap the last column to the first column
                    if (grid[row][(col + i) % columns] != word[i])
                    {
                        found = false;
                        break;
                    }
                }

                if (found)
                {
                    // Add the coordinates of the matching characters to the gridSymbols hashset
                    for (var i = 0; i < word.Length; i++)
                    {
                        gridSymbols.Add((row, (col + i) % columns));
                    }
                }

                // Check vertically
                if (row + word.Length <= grid.Length)
                {
                    found = true;
                    for (var i = 0; i < word.Length; i++)
                    {
                        // Check (row+i,column) for a matching character
                        // Do not wrap vertically, so no need to mod rows
                        if (grid[row + i][col] != word[i])
                        {
                            found = false;
                            break;
                        }
                    }

                    if (found)
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

    // Display gridSymbols, using a 2D array to display the grid
    for (var row = 0; row < grid.Length; row++)
    {
        for (var col = 0; col < columns; col++)
        {
            Console.Write(gridSymbols.Contains((row, col)) ? '*' : ".");
        }

        Console.WriteLine("");
    }

    Console.WriteLine();
    foreach (var symbol in gridSymbols)
    {
        Console.WriteLine($"({symbol.row},{symbol.col})");
    }

    Console.WriteLine($"Total scales (part 3): {gridSymbols.Count}");
}

void WriteWords(int part, IEnumerable<string> words)
{
    Console.WriteLine($"Part {part} Words: {string.Join(',', words)}");
}

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

string[] GetWords(string[] strings) => strings[0].Replace("WORDS:", string.Empty).Split(',');