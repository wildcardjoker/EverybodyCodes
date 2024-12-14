// Example input
//string[] words = ["THE", "OWE", "MES", "ROD", "HER"];
//var      inscription     = "AWAKEN THE POWER ADORNED WITH THE FLAMES BRIGHT IRE".Split(' ');
//var inscription     = "THE FLAME SHIELDED THE HEART OF THE KINGS".Split(' ');
//var inscription     = "POWE PO WER P OWE R".Split(' ');
//var inscription     = "THERE IS THE END".Split(' ');

Part1();
return;

void Part1()
{
    var input1          = File.ReadAllLines("input1.txt").Where(x => !string.IsNullOrEmpty(x)).ToArray();
    var words           = input1[0].Replace("WORDS:", string.Empty).Split(',');
    var inscription     = input1[1].Split(' ');
    var totalRunicWords = 0;
    var maxLength       = inscription.Max(x => x.Length);

    Console.WriteLine($"Words: {string.Join(',', words)}");
    foreach (var word in inscription)
    {
        var subtotal = words.Count(rune => word.Contains(rune));
        Console.WriteLine($"{word.PadRight(maxLength)} {subtotal}");
        totalRunicWords += subtotal;
    }

    Console.WriteLine($"Total runic words: {totalRunicWords}");
}