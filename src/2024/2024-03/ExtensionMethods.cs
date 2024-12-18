// 2024-03

internal static class ExtensionMethods
{
    #region Fields
    // Create functions to check whether previous cell value is within range (was updated previously, should be same or 1 higher than current cell value)
    // or the same as the current cell value

    private static readonly Func<int, int, bool> DiffInRange = (a, b) => a - b >= 0 && a - b <= 1;
    private static readonly Func<int, int, bool> ValueMatch  = (a, b) => a == b;
    #endregion

    public static int RemoveBlocks(string fileName, bool part3 = false)
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

        bool changesMade;
        do
        {
            changesMade = false;
            foreach (var cell in excavatedCells.Where(cell => part3 ? CanDigPart3(excavatedCells, cell, rows, columns) : CanDig(excavatedCells, cell)))
            {
                cell.Value++;
                changesMade = true;
            }
        }
        while (changesMade);

        return excavatedCells.Sum(cell => cell.Value);
    }

    private static bool CanDig(this List<Cell> excavatedCells, Cell cell) =>
        IsAdjacentCellValid(excavatedCells,    cell, cell.Row - 1, cell.Column,     DiffInRange)
        && IsAdjacentCellValid(excavatedCells, cell, cell.Row + 1, cell.Column,     ValueMatch)
        && IsAdjacentCellValid(excavatedCells, cell, cell.Row,     cell.Column - 1, DiffInRange)
        && IsAdjacentCellValid(excavatedCells, cell, cell.Row,     cell.Column + 1, ValueMatch);

    private static bool CanDigPart3(this List<Cell> excavatedCells, Cell cell, int rows, int cols)
    {
        return IsAdjacentCellValid(excavatedCells,    cell, ModRow(cell.Row) - 1, ModCol(cell.Column),     DiffInRange)
               && IsAdjacentCellValid(excavatedCells, cell, ModRow(cell.Row) + 1, ModCol(cell.Column),     ValueMatch)
               && IsAdjacentCellValid(excavatedCells, cell, ModRow(cell.Row),     ModCol(cell.Column) - 1, DiffInRange)
               && IsAdjacentCellValid(excavatedCells, cell, ModRow(cell.Row),     ModCol(cell.Column) + 1, ValueMatch)
               && IsDiagonalCellValid(excavatedCells, cell, ModRow(cell.Row)                          - 1, ModCol(cell.Column - 1), DiffInRange)
               && IsDiagonalCellValid(excavatedCells, cell, ModRow(cell.Row)                          - 1, ModCol(cell.Column) + 1, DiffInRange)
               && IsDiagonalCellValid(excavatedCells, cell, ModRow(cell.Row)                          + 1, ModCol(cell.Column) - 1, ValueMatch)
               && IsDiagonalCellValid(excavatedCells, cell, ModRow(cell.Row)                          + 1, ModCol(cell.Column) + 1, ValueMatch);

        int ModRow(int row) => (row + rows) % rows;

        int ModCol(int col) => (col + cols) % cols;
    }

    private static bool IsAdjacentCellValid(List<Cell> excavatedCells, Cell cell, int adjRow, int adjCol, Func<int, int, bool> cellCheckFunc)
    {
        var adjacentCell = excavatedCells.FirstOrDefault(c => c.Row == adjRow && c.Column == adjCol);
        return adjacentCell != null && cellCheckFunc(adjacentCell.Value, cell.Value);
    }

    private static bool IsDiagonalCellValid(this List<Cell> excavatedCells, Cell cell, int diagonalRow, int diagonalCol, Func<int, int, bool> cellCheckFunc)
    {
        var diagonalCell = excavatedCells.FirstOrDefault(c => c.Row == diagonalRow && c.Column == diagonalCol);
        return diagonalCell != null && cellCheckFunc(diagonalCell.Value, cell.Value); //Math.Abs(diagonalCell.Value - cell.Value) <= 1;
    }
}