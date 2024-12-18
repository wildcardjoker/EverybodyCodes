// 2024-03

internal record Cell(int Row, int Column, int Value)
{
    #region Fields
    public readonly int Column = Column;
    public readonly int Row    = Row;
    public          int Value  = Value;
    #endregion

    public override string ToString() => $"Row: {Row}, Column: {Column}, Value: {Value}";
}