#region Using Directives
using System.Text.RegularExpressions;
#endregion

var input      = File.ReadAllText("input1.txt");
var characters = input.ToCharArray();

List<Monster> monsters =
[
    new ("Ancient Ant", 0),
    new ("Badass Beetle", 1),
    new ("Creepy Cockroach", 3)
];

// Part 1
var potionsRequired = monsters.Sum(SumPotionsRequired);
Console.WriteLine($"Part 1: {potionsRequired} potions required.");

// Part 2
// Monsters can pair up, and will require +1 potion for each monster in a pair.

// Different input!
input = File.ReadAllText("input2.txt");

// A new monster is introduced: The Diabolical Dragonfly
monsters.Add(new Monster("Diabolical Dragonfly", 5));

// Create a collection of monster symbols
var monsterSymbols = monsters.Select(m => m.Symbol).ToArray();

// Split the input into pairs of monsters
var pairs = MonsterPairRegex().Matches(input).Select(m => m.Value);
potionsRequired = CalculatePotionsRequired(pairs);
Console.WriteLine($"Part 2: {potionsRequired} potions required");

// Part 3
// Monsters can now form triplets, and will require +2 potions for each monster in a triplet.
input = File.ReadAllText("input3.txt");
var triplets = MonsterTripletRegex().Matches(input).Select(m => m.Value);

potionsRequired = CalculatePotionsRequired(triplets);
Console.WriteLine($"Part 3: {potionsRequired} potions required");

return;

int SumPotionsRequired(Monster monster)
{
    return characters.Count(c => c.Equals(monster.Symbol)) * monster.NumberOfPotions;
}

int CalculatePotionsRequired(IEnumerable<string> monsterGroup)
{
    {
        var numberOfPotionsRequired = 0;
        foreach (var groupOfMonsters in monsterGroup)
        {
            //Console.Write($"{groupOfMonsters}: ");

            var subtotal     = 0;
            var currentGroup = groupOfMonsters.Where(x => monsterSymbols.Contains(x)).Select(c => monsters.First(m => m.Symbol == c)).ToList();
            foreach (var monster in currentGroup)
            {
                var numberOfPotionsToOrder = currentGroup.Count switch
                {
                    3 => monster.NumberOfPotionsTriplet,
                    2 => monster.NumberOfPotionsPaired,
                    _ => monster.NumberOfPotions
                };
                subtotal += numberOfPotionsToOrder;

                //Console.Write($"{monster.Name} ({numberOfPotionsToOrder}) ");
            }

            numberOfPotionsRequired += subtotal;

            //Console.WriteLine($" ### {subtotal} ###");
        }

        return numberOfPotionsRequired;
    }
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