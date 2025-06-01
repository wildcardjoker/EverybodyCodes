#region Using Directives
using System.Diagnostics;
#endregion

//SolvePart1();
//SolvePart2();
SolvePart3();
return;

void SolvePart1()
{
    var lines   = File.ReadAllLines("input1.txt").ToList();
    var columns = InitializeColumns(lines[0].Split(' ').Length);

    PopulateColumns(lines, columns);

    const int numRounds = 10;
    var       results   = new List<ulong>();
    while (results.Count < numRounds)
    {
        ProcessColumns(columns, results);
    }

    Console.WriteLine($"Round 1: {results.Last()}");
}

List<List<int>> InitializeColumns(int length)
{
    var columns = new List<List<int>>();
    for (var i = 0; i < length; i++)
    {
        columns.Add(new List<int>());
    }

    return columns;
}

void PopulateColumns(List<string> lines, List<List<int>> columns)
{
    foreach (var values in lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()))
    {
        for (var i = 0; i < values.Length; i++)
        {
            columns[i].Add(values[i]);
        }
    }
}

void ProcessColumns(List<List<int>> columns, List<ulong> results)
{
    var clapIndex = 0;
    for (var round = 0; round < 10; round++)
    {
        var clapper = columns[clapIndex][0];
        columns[clapIndex].RemoveAt(0);
        var targetColumn = columns[(clapIndex + 1) % columns.Count];
        var moves        = CalculateMoves(clapper, targetColumn.Count);

        targetColumn.Insert(moves, clapper);
        clapIndex = (clapIndex + 1) % columns.Count;

        var number = GenerateNumber(columns);
        results.Add(number);
    }
}

int CalculateMoves(int clapper, int targetColumnCount)
{
    var moves = Math.Abs(clapper % (targetColumnCount * 2) - 1);
    if (moves > targetColumnCount)
    {
        moves = targetColumnCount * 2 - moves;
    }

    return moves;
}

Shout ProcessColumnsPart2(List<List<int>> columns, List<ulong> results)
{
    var       clapIndex  = 0;
    var       shouts     = new List<Shout>();
    const int count      = 2024;
    var       finalShout = shouts.FirstOrDefault(x => x.Count == count);
    var       sw         = Stopwatch.StartNew();

    while (finalShout == null)
    {
        var clapper = columns[clapIndex][0];
        columns[clapIndex].RemoveAt(0);
        var targetColumn = columns[(clapIndex + 1) % columns.Count];
        var moves        = CalculateMoves(clapper, targetColumn.Count);

        targetColumn.Insert(moves, clapper);
        clapIndex = (clapIndex + 1) % columns.Count;

        var number = GenerateNumber(columns);
        results.Add(number);
        var shout = shouts.FirstOrDefault(x => x.ShoutValue == number);
        if (shout == null)
        {
            shouts.Add(new Shout(number));
        }
        else
        {
            shout.Count++;
        }

        finalShout = shouts.FirstOrDefault(x => x.Count == count);
    }

    sw.Stop();
    return finalShout;
}

void SolvePart2()
{
    var lines   = File.ReadAllLines("input2.txt").ToList();
    var columns = InitializeColumns(lines[0].Split(' ').Length);

    PopulateColumns(lines, columns);

    var results   = new List<ulong>();
    var lastShout = ProcessColumnsPart2(columns, results);
    Console.WriteLine($"Part 2 result: {lastShout.ShoutValue} x {results.Count} = {lastShout.ShoutValue * (ulong) results.Count}");
}

void SolvePart3()
{
    // Modified using code from https://github.com/CodingAP/everybody-codes/blob/main/quests/2024/quest05/solution.js
    var result = Part3(File.ReadAllText("input3.txt"));
    Console.WriteLine($"Part 3 result: {result}");
}

string Part3(string input)
{
    var dance = ParseInput(input);

    // find the biggest number shouted out
    // 10000 is arbitrary, but should be enough to find the maximum
    var max = "0";

    for (var i = 0; i < 10000; i++)
    {
        var turn = i % dance.Length;
        DoDance(dance, turn);

        var code = ShoutCode(dance);
        max = long.Parse(code) > long.Parse(max) ? code : max;
    }

    return max;
}

static int[][] ParseInput(string input)
{
    var lines  = input.Replace("\r", "").Split('\n');
    var matrix = lines.Select(line => line.Split(' ').Select(int.Parse).ToArray()).ToArray();

    // transpose
    var rowCount = matrix.Length;
    var colCount = matrix[0].Length;
    var dance    = new int[colCount][];
    for (var i = 0; i < colCount; i++)
    {
        dance[i] = new int[rowCount];
        for (var j = 0; j < rowCount; j++)
        {
            dance[i][j] = matrix[j][i];
        }
    }

    return dance;
}

static void DoDance(int[][] dance, int turn)
{
    var next = (turn + 1) % dance.Length;

    var num = dance[turn][0];
    dance[turn] = dance[turn].Skip(1).ToArray();

    var side = (int) Math.Ceiling((double) num / dance[next].Length) % 2 == 0;

    var index = num % dance[next].Length;
    index =  index == 0 ? dance[next].Length : index;
    index -= 1;

    var list = dance[next].ToList();
    list.Insert(side ? list.Count - index : index, num);
    dance[next] = list.ToArray();
}

static string ShoutCode(int[][] dance)
{
    return string.Concat(dance.Select(arr => arr[0].ToString()));
}

ulong GenerateNumber(List<List<int>> list) => Convert.ToUInt64(string.Join(string.Empty, list.Select(col => col[0].ToString())));

internal class Shout(ulong shoutValue)
{
    #region Properties
    public ulong Count      {get; set;} = 1;
    public ulong ShoutValue {get;}      = shoutValue;
    #endregion
}