#region Using Directives
using System.Text.RegularExpressions;
#endregion

// Set up some variables used in all parts
string input;
int    potionsRequired;

// These are the monsters we'll face, and the number of potions required to defeat them.
List<Monster> monsters =
[
    new ("Ancient Ant", 0),
    new ("Badass Beetle", 1),
    new ("Creepy Cockroach", 3)
];

RunPart1();
RunPart2();
RunPart3();
return;

void RunPart1()
{
    // Part 1
    input = File.ReadAllText("input1.txt");
    var characters = input.ToCharArray();
    potionsRequired = monsters.Sum(monster => characters.Count(c => c.Equals(monster.Symbol)) * monster.NumberOfPotions);
    Console.WriteLine($"Part 1: {potionsRequired} potions required.");
    Pause();
}

void RunPart2()
{
    // Monsters can pair up, and will require +1 potion for each monster in a pair.
    input = File.ReadAllText("input2.txt");

    // A new monster is introduced: The Diabolical Dragonfly
    monsters.Add(new Monster("Diabolical Dragonfly", 5));

    // Split the input into pairs of monsters
    var pairs = MonsterPairRegex().Matches(input).Select(m => m.Value);
    potionsRequired = CalculatePotionsRequired(pairs);
    Console.WriteLine($"Part 2: {potionsRequired} potions required");
    Pause();
}

void RunPart3()
{
    // Monsters can now form triplets, and will require +2 potions for each monster in a triplet.
    input = File.ReadAllText("input3.txt");
    var triplets = MonsterTripletRegex().Matches(input).Select(m => m.Value);
    potionsRequired = CalculatePotionsRequired(triplets);
    Console.WriteLine($"Part 3: {potionsRequired} potions required");
}

int CalculatePotionsRequired(IEnumerable<string> monsterGroup)
{
    {
        var numberOfPotionsRequired = 0;
        foreach (var groupOfMonsters in monsterGroup)
        {
            var subtotal       = 0;
            var monsterSymbols = ExtractMonsterSymbols(monsters);
            var currentGroup   = groupOfMonsters.Where(x => monsterSymbols.Contains(x)).Select(c => monsters.First(m => m.Symbol == c)).ToList();
            foreach (var monster in currentGroup)
            {
                var numberOfPotionsToOrder = currentGroup.Count switch
                {
                    3 => monster.NumberOfPotionsTriplet,
                    2 => monster.NumberOfPotionsPaired,
                    _ => monster.NumberOfPotions
                };
                subtotal += numberOfPotionsToOrder;
            }

            Console.WriteLine($"{subtotal} : {string.Join(',', currentGroup.Select(m => m.Name))}");
            numberOfPotionsRequired += subtotal;
        }

        return numberOfPotionsRequired;
    }
}

void Pause()
{
    Console.WriteLine("Press any key to continue...");
    Console.ReadKey();
}

char[] ExtractMonsterSymbols(List<Monster> list)
{
    return list.Select(m => m.Symbol).ToArray();
}

internal partial class Program
{
    [GeneratedRegex(".{2}")]
    private static partial Regex MonsterPairRegex();

    [GeneratedRegex(".{3}")]
    private static partial Regex MonsterTripletRegex();
}

internal class Monster(string name, int numberOfPotions)
{
    #region Properties
    public string Name                   {get;} = name;
    public int    NumberOfPotions        {get;} = numberOfPotions;
    public int    NumberOfPotionsPaired  {get;} = numberOfPotions + 1;
    public int    NumberOfPotionsTriplet {get;} = numberOfPotions + 2;
    public char   Symbol                 {get;} = name[0];
    #endregion
}