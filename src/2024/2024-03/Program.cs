var excavatedCells = new List<Cell>();

SolvePart1();
SolvePart2();
SolvePart3();

void SolvePart1()
{
    var input  = File.ReadAllLines("input1.txt");
    var grid   = new int[input.Length, input[0].Length];
    var result = 0;
    for (var i = 0; i < input.Length; i++)
    {
        for (var j = 0; j < input[i].Length; j++)
        {
            var value = input[i][j].Equals('.') ? 0 : 1;
            grid[i, j] = value;
            if (value != 0)
            {
                excavatedCells.Add(new Cell(i, j, value));
            }
        }
    }

    DisplayGrid(grid, excavatedCells);
    bool changesMade;
    do
    {
        changesMade = false;
        foreach (var cell in excavatedCells.Where(CanDig))
        {
            Console.WriteLine($"{cell} +1");
            cell.Value++;
            changesMade = true;
        }
    }
    while (changesMade);

    Console.WriteLine();
    DisplayGrid(grid, excavatedCells);

    foreach (var cell in excavatedCells)
    {
        Console.WriteLine(cell);
    }

    DisplayGrid(grid, excavatedCells);

    result = excavatedCells.Sum(cell => cell.Value);
    Console.WriteLine($"Part 1 result: {result}");
}

// Check each cell and count the number of occupied seats

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

bool CanDig(Cell cell)
{
    // return true if the cells above, below, and adjacent to the cell have the same value
    return excavatedCells.Any(
        c => c.Row                   == cell.Row - 1
             && c.Column             == cell.Column
             && c.Value - cell.Value >= 0
             && c.Value - cell.Value <= 1
             && excavatedCells.Any(c => c.Row == cell.Row + 1 && c.Column == cell.Column && c.Value == cell.Value)
             && excavatedCells.Any(
                 c => c.Row       == cell.Row
                      && c.Column == cell.Column - 1
                      && c.Value                 - cell.Value >= 0
                      && c.Value                 - cell.Value <= 1
                      && excavatedCells.Any(c => c.Row == cell.Row && c.Column == cell.Column + 1 && c.Value == cell.Value)));
}

void DisplayGrid(int[,] grid, List<Cell> cells)
{
    for (var i = 0; i < grid.GetLength(0); i++)
    {
        for (var j = 0; j < grid.GetLength(1); j++)
        {
            var cell = cells.FirstOrDefault(c => c.Row == i && c.Column == j);
            Console.Write(cell?.Value.ToString() ?? ".");
        }

        Console.WriteLine();
    }
}

internal record Cell(int Row, int Column, int Value)
{
    #region Fields
    public readonly int Column = Column;
    public readonly int Row    = Row;
    public          int Value  = Value;
    #endregion

    public override string ToString() => $"Row: {Row}, Column: {Column}, Value: {Value}";
}