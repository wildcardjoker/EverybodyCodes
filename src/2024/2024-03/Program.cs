SolvePart1();
SolvePart2();
SolvePart3();

void SolvePart1()
{
    var result = RemoveBlocks("input1.txt");
    Console.WriteLine($"Part 1 result: {result}");
}

// Check each cell and count the number of occupied seats

void SolvePart2()
{
    var result = RemoveBlocks("input2.txt");
    Console.WriteLine($"Part 2 result: {result}");
}

void SolvePart3()
{
    var result = RemoveBlocks("input3.txt", true);
    Console.WriteLine($"Part 3 result: {result}");
}

int RemoveBlocks(string fileName, bool part3 = false)
{
    var input          = File.ReadAllLines(fileName);
    var excavatedCells = new List<Cell>();
    var rows           = input.Length;
    var columns        = input[0].Length;
    for (var rowIndex = 0; rowIndex < input.Length; rowIndex++)
    {
        for (var colIndex = 0; colIndex < input[rowIndex].Length; colIndex++)
        {
            var value = input[rowIndex][colIndex].Equals('.') ? 0 : 1;
            if (value != 0)
            {
                excavatedCells.Add(new Cell(rowIndex, colIndex, value));
            }
        }
    }

    //DisplayGrid(grid, excavatedCells);
    bool changesMade;
    do
    {
        changesMade = false;
        foreach (var cell in excavatedCells.Where(cell => part3 ? CanDigPart3(excavatedCells, cell, rows, columns) : CanDig(excavatedCells, cell)))
        {
            //Console.WriteLine($"{cell} +1");
            cell.Value++;
            changesMade = true;
        }
    }
    while (changesMade);

    //DisplayGrid(grid, excavatedCells);

    //foreach (var cell in excavatedCells)
    //{
    //    Console.WriteLine(cell);
    //}

    //DisplayGrid(grid, excavatedCells);

    return excavatedCells.Sum(cell => cell.Value);
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

bool CanDig(List<Cell> excavatedCells, Cell cell)
{
    // return true if the cells above, below, and adjacent to the cell have the same value
    var canDig = excavatedCells.Any(
        c => c.Row                   == cell.Row - 1
             && c.Column             == cell.Column
             && c.Value - cell.Value >= 0
             && c.Value - cell.Value <= 1
             && excavatedCells.Any(block => block.Row == cell.Row + 1 && block.Column == cell.Column     && block.Value              == cell.Value)
             && excavatedCells.Any(block => block.Row == cell.Row     && block.Column == cell.Column - 1 && block.Value - cell.Value >= 0 && block.Value - cell.Value <= 1)
             && excavatedCells.Any(block => block.Row == cell.Row     && block.Column == cell.Column + 1 && block.Value              == cell.Value));
    return canDig;
}

bool CanDigPart3(List<Cell> excavatedCells, Cell cell, int rows, int cols)
{
    // return true if the cells above, below, and adjacent to the cell have the same value
    var canDig = excavatedCells.Any(
        c => c.Row                   == cell.Row % rows - 1
             && c.Column             == cell.Column % cols
             && c.Value - cell.Value >= 0
             && c.Value - cell.Value <= 1
             && excavatedCells.Any(block => block.Row == cell.Row % rows + 1 && block.Column == cell.Column % cols && block.Value == cell.Value)
             && excavatedCells.Any(
                 block => block.Row == cell.Row % rows && block.Column == cell.Column % cols - 1 && block.Value - cell.Value >= 0 && block.Value - cell.Value <= 1)
             && excavatedCells.Any(block => block.Row % rows == cell.Row % rows && block.Column == cell.Column % cols + 1 && block.Value == cell.Value));

    var royalPond = excavatedCells.Any(
        c => c.Row       == cell.Row    % rows - 1
             && c.Column == cell.Column % cols - 1
             && c.Value                        - cell.Value >= 0
             && c.Value                        - cell.Value <= 1
             && excavatedCells.Any(
                 block => block.Row == cell.Row % rows - 1 && block.Column == cell.Column % cols + 1 && block.Value - cell.Value >= 0 && block.Value - cell.Value <= 1)
             && excavatedCells.Any(block => block.Row == cell.Row % rows + 1 && block.Column == cell.Column % cols - 1 && block.Value == cell.Value)
             && excavatedCells.Any(block => block.Row == cell.Row % rows + 1 && block.Column == cell.Column % cols + 1 && block.Value == cell.Value));
    return canDig && royalPond;
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