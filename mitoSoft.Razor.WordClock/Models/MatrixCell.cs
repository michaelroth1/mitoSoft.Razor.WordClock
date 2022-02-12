namespace mitoSoft.Razor.WordClock.Models
{
    public class MatrixCell
    {
        public int Row { get; set; } = default!;

        public int Col { get; set; } = default!;

        public string Letter { get; set; } = default!;

        public MatrixCell(int row, int col, string letter)
        {
            this.Row = row;
            this.Col = col;
            this.Letter = letter;
        }
    }
}