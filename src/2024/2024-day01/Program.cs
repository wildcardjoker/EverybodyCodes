var input      = File.ReadAllText("input.txt");
var characters = input.ToCharArray();

List<Monster> monsters =
[
    new ("A", 0),
    new ("B", 1),
    new ("C", 3)
];

var potionsRequired = monsters.Sum(SumPotionsRequired);
Console.WriteLine($"Part 1: {potionsRequired} potions required.");
return;

int SumPotionsRequired(Monster monster)
{
    return characters.Count(c => c.Equals(monster.Symbol)) * monster.NumberOfPotions;
}

internal class Monster(string name, int numberOfPotions)
{
    #region Properties
    public string Name            {get;} = name;
    public int    NumberOfPotions {get;} = numberOfPotions;
    public char   Symbol          {get;} = name[0];
    #endregion
}