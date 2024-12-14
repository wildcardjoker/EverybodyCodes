// Example input
//string[] words = ["THE", "OWE", "MES", "ROD", "HER"];
//var      inscription     = "AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE".Split(' ');
//var inscription     = "THE FLAME SHIELDED THE HEART OF THE KINGS".Split(' ');
//var inscription     = "POWE PO WER P OWE R".Split(' ');
//var inscription     = "THERE IS THE END".Split(' ');

Part1();
Part2();
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