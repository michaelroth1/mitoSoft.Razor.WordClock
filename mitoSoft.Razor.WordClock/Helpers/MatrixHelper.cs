using mitoSoft.Razor.WordClock.Models;

namespace mitoSoft.Razor.WordClock.Helpers
{
    internal class MatrixHelper
    {
        public MatrixHelper(List<string> matrix)
        {
            this.Matrix = GetCells(matrix);
            this.AppendEdges();
        }

        public List<MatrixCell> Matrix { get; private set; }

        public int ColumnCount => Matrix.Max(c => c.Col);

        public int RowCount => Matrix.Max(c => c.Row);

        public string GetLetter(int row, int col)
        {
            var cell = this.Matrix.FirstOrDefault(c => c.Row == row && c.Col == col);
            if (cell == null)
            {
                return string.Empty;
            }
            else
            {
                return cell.Letter;
            }
        }

        private static List<MatrixCell> GetCells(List<string> rows)
        {
            var cells = new List<MatrixCell>();

            for (int row = 0; row < rows.Count; row++)
            {
                for (int col = 0; col < rows[row].Length; col++)
                {
                    var letter = rows[row].Substring(col, 1);

                    var matrixCell = new MatrixCell(row, col, letter);

                    cells.Add(matrixCell);
                }
            }

            return cells;
        }

        private void AppendEdges()
        {
            this.Matrix.Add(new MatrixCell(-1, -1, "•"));
            this.Matrix.Add(new MatrixCell(-1, this.ColumnCount + 1, "•"));
            this.Matrix.Add(new MatrixCell(this.RowCount + 1, this.ColumnCount, "•"));
            this.Matrix.Add(new MatrixCell(this.RowCount, -1, "•"));
        }

    }
}