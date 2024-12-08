var input      = File.ReadAllText("input.txt");
var characters = input.ToCharArray();

(char monster, int numberOfPotionsPerMonster)[] monsters        = [('A', 0), ('B', 1), ('C', 3)];
var                                             potionsRequired = monsters.Sum(tuple => SumPotionsRequired(tuple.monster, tuple.numberOfPotionsPerMonster));
Console.WriteLine($"Part 1: {potionsRequired} potions required.");
return;

int SumPotionsRequired(char monster, int numberOfPotionsPerMonster)
{
    return characters.Count(c => c.Equals(monster)) * numberOfPotionsPerMonster;
}